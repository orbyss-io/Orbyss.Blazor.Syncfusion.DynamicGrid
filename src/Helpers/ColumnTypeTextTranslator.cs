using Newtonsoft.Json.Linq;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Models;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Helpers
{
    internal static class ColumnTypeTextTranslator
    {
        internal static string StringifyColumn(DynamicColumn column, JToken rowToken)
        {
            var token = rowToken.SelectToken(column.Field, false);
            if (token is not JValue jsonValue)
            {
                return $"{token}";
            }

            return StringifyJsonValue(column.ColumnType, jsonValue);
        }

        private static string StringifyJsonValue(TableColumnType type, JValue value)
        {
            var culture = DynamicGridCulture.Instance;

            if (type == TableColumnType.DateOnlyTicks)
            {
                return new DateTime((long)value).ToString(culture.DateTimeFormat.ShortDatePattern);
            }
            if (type == TableColumnType.DateTimeTicks)
            {
                return new DateTime((long)value).ToString(culture.DateTimeFormat.FullDateTimePattern);
            }

            if (type == TableColumnType.DateOnly)
            {
                return DateTime.Parse($"{value}").ToString(culture.DateTimeFormat.ShortDatePattern);
            }
            if (type == TableColumnType.DateTime)
            {
                return DateTime.Parse($"{value}").ToString(culture.DateTimeFormat.FullDateTimePattern);
            }

            return $"{value}";
        }
    }
}