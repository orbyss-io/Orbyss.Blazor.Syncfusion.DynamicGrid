using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Models;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Grids;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Helpers
{
    public class DynamicColumnBuilder(ITableUiSchemaInterpreter interpreter, IColumnTypeProvider columnTypeProvider, IJsonPathInterpreter jsonPathInterpreter)
    {
        internal DynamicColumn[] BuildDynamicColumns(JSchema itemsJsonSchema)
        {
            return BuildDynamicColumns(
                GetDefaultTableUiSchema(itemsJsonSchema),
                itemsJsonSchema
            );
        }

        internal DynamicColumn[] BuildDynamicColumns(TableUiSchema tableUiSchema, JSchema itemsJsonSchema)
        {
            var result = new List<DynamicColumn>();

            foreach (var column in tableUiSchema.Columns.Items)
            {
                var scope = interpreter.InterpretScope(column.Scope);
                var label = interpreter.InterpretLabel(column.I18n, column.Label);
                var width = GetColumnWidth(tableUiSchema, column);
                if (string.IsNullOrWhiteSpace(width))
                {
                    width = "150";
                }
                var columnType = columnTypeProvider.GetColumnType(itemsJsonSchema, scope.AbsoluteSchemaJsonPath);

                var dynamicColumn = new DynamicColumn(
                    columnType,
                    scope,
                    jsonPathInterpreter.FromSchemaPath(scope.AbsoluteSchemaJsonPath),
                    label,
                    ParseRule(column.Filter?.Rule),
                    width,
                    GetEnumConfiguration(columnType),
                    null,
                    GetTextAlign(tableUiSchema, column),
                    null,
                    column.Sortable ?? false,
                    column.Filter?.Types?.Contains(FilterItemType.Header) == true
                );

                result.Add(dynamicColumn);
            }

            return [.. result];
        }

        private static TableUiSchema GetDefaultTableUiSchema(JSchema itemsJsonSchema)
        {
            var schemaToken = JToken.Parse($"{itemsJsonSchema}");
            var properties = (JObject?)schemaToken["properties"];
            var columns = new List<TableColumnItem>();

            if (properties is not null)
            {
                foreach(var property in properties.Properties())
                {
                    AddDefaultColumnItem(property.Name, "$", property.Value, columns);
                }
            }

            return new TableUiSchema(
                new TableColumns(null, columns.ToArray()),
                null,
                null,
                null
            );
        }

        private static void AddDefaultColumnItem(string name, string? parentPath, JToken columnSchemaToken, List<TableColumnItem> result)
        {
            var path = $"{parentPath}.properties.{name}";

            if ($"{columnSchemaToken["type"]}" == "object")
            {
                var properties = (JObject?)columnSchemaToken["properties"];
                if (properties is null)
                {
                    return;
                }

                foreach (var property in properties.Properties())
                {
                    AddDefaultColumnItem(property.Name, path, property.Value, result);
                }
            }

            else if($"{columnSchemaToken["type"]}" == "array")
            {
                var items = columnSchemaToken["items"];
                if (items is JArray)
                {
                    throw new NotSupportedException($"Items must be one object: multiple items are not supported. Schema path: {parentPath}");
                }

                if (items?["type"]?.ToString() != "string")
                {
                    throw new NotSupportedException($"Items can only be of type string. Schema path: {parentPath}");
                }

                result.Add(
                    new TableColumnItem(
                        name,
                        null,
                        path,
                        null,
                        null,
                        new TableFilterDefinition(
                            FilterItemType.Header,
                            FilterItemRule.Equals,
                            true
                        )
                    )    
                );
            }
            else
            {
                result.Add(
                    new TableColumnItem(
                        name,
                        null,
                        path,
                        null,
                        null,
                        new TableFilterDefinition(
                            FilterItemType.Header,
                            GetRuleForType($"{columnSchemaToken["type"]}"),
                            false
                        )
                    )
                );
            }
        }

        static FilterItemRule GetRuleForType(string type)
        {
            var jschemaType = Enum.Parse<JSchemaType>(type, true);
            return jschemaType switch
            {
                JSchemaType.String => FilterItemRule.Contains,
                _=> FilterItemRule.Equals                
            };
        }
        

        static string? GetColumnWidth(TableUiSchema tableUiSchema, TableColumnItem column)
        {
            if(string.IsNullOrWhiteSpace(column.Layout?.Width))
            {
                return tableUiSchema.Columns.GlobalLayout?.Width;
            }

            return column.Layout?.Width;
        }

        private static Operator? ParseRule(FilterItemRule? rule)
        {
            if (!rule.HasValue)
            {
                return null;
            }

            if (Enum.TryParse<Operator>(rule.ToString(), true, out var result))
            {
                return result;
            }

            throw new NotSupportedException($"'{rule}' rule is not supported.");
        }

        private static TextAlign GetTextAlign(TableUiSchema tableSchema, TableColumnItem column)
        {
            HorizontalAlignment horizontalAlignment;
            if (column.Layout.HasValue)
            {
                horizontalAlignment = column.Layout.Value.Alignment.Horizontal;
            }
            else
            {
                horizontalAlignment = tableSchema.Columns.GlobalLayout?.Alignment.Horizontal ?? HorizontalAlignment.Center;
            }

            return Enum.TryParse<TextAlign>($"{horizontalAlignment}", true, out var result)
                ? result
                : TextAlign.Center;
        }

        private static DynamicColumnEnumConfiguration? GetEnumConfiguration(TableColumnType tableColumnType)
        {
            if (tableColumnType is TableColumnType.Enum)
            {
                return new(false);
            }

            if (tableColumnType is TableColumnType.EnumList)
            {
                return new(true);
            }

            return null;
        }
    }
}