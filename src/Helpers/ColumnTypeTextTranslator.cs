using Newtonsoft.Json.Linq;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interfaces;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Models;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Helpers;

public sealed class ColumnValueStringifier : IColumnValueStringifier
{
    public string StringifyColumn(DynamicColumn column, JToken rowToken)
    {
        var token = rowToken.SelectToken(column.Field, false);
        if (token is not JValue jsonValue)
        {
            if (token is JArray jsonArray)
            {
                return StringifyArray(column.ColumnType, jsonArray);
            }

            return $"{token}";
        }

        return StringifyJsonValue(column.ColumnType, jsonValue);
    }

    private static string StringifyArray(TableColumnType columnType, JArray array)
    {
        var result = new List<string>();
        foreach (var item in array)
        {
            if (item is not JValue jsonValue)
            {
                result.Add($"{item}");
                continue;
            }

            result.Add(
                StringifyJsonValue(columnType, jsonValue)
            );
        }

        return string.Join(", ", result);
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