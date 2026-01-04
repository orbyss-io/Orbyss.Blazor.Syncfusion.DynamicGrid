using Syncfusion.Blazor.Data;
using System.Security.Cryptography;
using System.Text;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Helpers;

internal static class HashBuilder
{
    internal static string? Build(List<WhereFilter>? whereFilters)
    {
        if (whereFilters is null || whereFilters.Count == 0)
        {
            return null;
        }

        var whereStrings = new List<string>();

        foreach (var filter in whereFilters)
        {
            var whereString = Build(filter);
            if (!string.IsNullOrWhiteSpace(whereString))
            {
                whereStrings.Add(whereString);
            }
        }

        var result = string.Join(
            ':',
            whereStrings.OrderBy(x => x)
        );
        var hash = MD5.HashData(
            Encoding.UTF8.GetBytes(result)
        );

        return BitConverter.ToString(hash);
    }

    private static string? Build(WhereFilter? whereFilter)
    {
        if (whereFilter is null)
        {
            return null;
        }

        var result = $"where_complex_{whereFilter.IsComplex}+condition_{whereFilter.Condition}+value_{whereFilter.value}+operator_{whereFilter.Operator}";

        if (whereFilter.predicates?.Count > 0)
        {
            var predicateStrings = new List<string>();
            foreach (var predicate in whereFilter.predicates)
            {
                var predicateString = Build(predicate);
                if (!string.IsNullOrWhiteSpace(predicateString))
                {
                    predicateStrings.Add(predicateString);
                }
            }

            result += "+predicates_";
            result += string.Join(
                ":",
                predicateStrings.OrderBy(x => x)
            );
        }

        return result;
    }

    internal static string? Build(List<Sort>? sorted)
    {
        if (sorted is null || sorted.Count <= 0)
        {
            return null;
        }

        var sortedStrings = new List<string>();
        foreach (var sort in sorted)
        {
            sortedStrings.Add(
                $"name_{sort.Name}+direction_{sort.Direction}"
            );
        }

        var result = string.Join(':', sortedStrings.OrderBy(x => x));

        var hash = MD5.HashData(
            Encoding.UTF8.GetBytes(result)
        );

        return BitConverter.ToString(hash);
    }
}