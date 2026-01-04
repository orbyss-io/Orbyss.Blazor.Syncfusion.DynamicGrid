using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;

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
        if (IsDateFormat(schema.Format))
        {
            return TableColumnType.DateOnlyTicks;
        }

        if (IsDateTimeFormat(schema.Format))
        {
            return TableColumnType.DateTimeTicks;
        }

        return TableColumnType.Integer;
    }

    private static TableColumnType HandleNumber(JSchema schema)
    {
        if (IsDateFormat(schema.Format))
        {
            return TableColumnType.DateOnlyTicks;
        }

        if (IsDateTimeFormat(schema.Format))
        {
            return TableColumnType.DateTimeTicks;
        }

        return TableColumnType.Number;
    }

    private static bool IsDateTimeFormat(string? format)
    {
        if (string.IsNullOrWhiteSpace(format))
        {
            return false;
        }

        return format.Equals("datetime", StringComparison.OrdinalIgnoreCase)
            || format.Equals("date-time", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsDateFormat(string? format)
    {
        if (string.IsNullOrWhiteSpace(format))
        {
            return false;
        }

        return format.Equals("date", StringComparison.OrdinalIgnoreCase);
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

        if (!itemsSchema.Type.HasValue)
        {
            throw new InvalidOperationException($"The type of items array schema section could not be determined; was null.");
        }

        if (itemsSchema.Type.Value.HasFlag(JSchemaType.Number))
        {
            return TableColumnType.NumberList;
        }
        if (itemsSchema.Type.Value.HasFlag(JSchemaType.Integer))
        {
            return TableColumnType.IntegerList;
        }
        if (itemsSchema.Type.Value.HasFlag(JSchemaType.String))
        {
            if (itemsSchema.Enum.Count > 0)
            {
                return TableColumnType.EnumList;
            }

            return TableColumnType.TextList;
        }

        throw new NotSupportedException($"Items schema of type '{itemsSchema.Type}' is not supported for a column");
    }

    private static TableColumnType HandleStringType(JSchema schema)
    {
        if (IsDateTimeFormat(schema.Format))
        {
            return TableColumnType.DateTime;
        }
        if (IsDateFormat(schema.Format))
        {
            return TableColumnType.DateOnly;
        }

        if (schema.Enum.Count > 0)
        {
            return TableColumnType.Enum;
        }

        return TableColumnType.Text;
    }
}

public interface IColumnTypeProvider
{
    TableColumnType GetColumnType(JSchema itemsSchema, string absoluteSchemaJsonPath);
}