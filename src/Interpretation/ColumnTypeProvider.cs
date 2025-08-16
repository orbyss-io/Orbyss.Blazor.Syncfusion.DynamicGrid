using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation
{
    public sealed class ColumnTypeProvider : IColumnTypeProvider
    {
        public TableColumnType GetColumnType(JSchema itemsSchema, string absoluteSchemaJsonPath)
        {
            var itemsSchemaToken = JToken.Parse($"{itemsSchema}");
            var columnProperty = itemsSchemaToken.SelectToken(absoluteSchemaJsonPath, true);
            var columnPropertySchema = JSchema.Parse($"{columnProperty}");

            if (!columnPropertySchema.Type.HasValue)
            {
                throw new InvalidOperationException($"The column property '{columnProperty}' does not have a 'type' attribute");
            }

            if (columnPropertySchema.Type.Value.HasFlag(JSchemaType.String))
            {
                return HandleStringType(columnPropertySchema);
            }
            if (columnPropertySchema.Type.Value.HasFlag(JSchemaType.Number))
            {
                return HandleNumber(columnPropertySchema);
            }
            if (columnPropertySchema.Type.Value.HasFlag(JSchemaType.Integer))
            {
                return HandleInteger(columnPropertySchema);
            }
            if (columnPropertySchema.Type.Value.HasFlag(JSchemaType.Boolean))
            {
                return TableColumnType.Boolean;
            }
            if (columnPropertySchema.Type.Value.HasFlag(JSchemaType.Array))
            {
                return HandleArrayType(columnPropertySchema);
            }

            throw new NotSupportedException($"Schema type '{columnPropertySchema.Type}' is not supported");
        }

        private static TableColumnType HandleInteger(JSchema schema)
        {
            if (schema.Format == "date")
            {
                return TableColumnType.DateOnlyTicks;
            }

            if (schema.Format == "datetime")
            {
                return TableColumnType.DateTimeTicks;
            }

            return TableColumnType.Integer;
        }

        private static TableColumnType HandleNumber(JSchema schema)
        {
            if (schema.Format == "date")
            {
                return TableColumnType.DateOnlyTicks;
            }

            if (schema.Format == "datetime")
            {
                return TableColumnType.DateTimeTicks;
            }

            return TableColumnType.Number;
        }

        private static TableColumnType HandleArrayType(JSchema schema)
        {
            if (!schema.Items.Any())
            {
                throw new InvalidOperationException($"The schema type is '{schema.Type}', but no 'items' are specified.");
            }
            if (schema.Items.Count > 1)
            {
                throw new InvalidOperationException($"The schema type is '{schema.Type}', but more than one 'items' are specified. Only 1 is supported.");
            }

            var itemsSchema = schema.Items.First();

            if (!itemsSchema.Type.HasValue || itemsSchema.Type.Value.HasFlag(JSchemaType.String))
            {
                throw new InvalidOperationException($"The items schema of array is '{itemsSchema.Type}', however only '{JSchemaType.String}' is supported in the array control type.");
            }

            return HandleStringType(itemsSchema, schema);
        }

        private static TableColumnType HandleStringType(JSchema schema, JSchema? parentSchema = null)
        {
            var format = schema.Format?.ToLower();
            var enumItems = schema.Enum.Select(x => x.ToString());
            var isArray = parentSchema?.Type?.HasFlag(JSchemaType.Array) == true;

            if (enumItems.Any())
            {
                return isArray
                    ? TableColumnType.EnumList
                    : TableColumnType.Enum;
            }

            return format == "datetime"
                ? TableColumnType.DateTime
                : format == "date"
                    ? TableColumnType.DateOnly
                    : TableColumnType.Text;
        }
    }

    public interface IColumnTypeProvider
    {
        TableColumnType GetColumnType(JSchema itemsSchema, string absoluteSchemaJsonPath);
    }
}