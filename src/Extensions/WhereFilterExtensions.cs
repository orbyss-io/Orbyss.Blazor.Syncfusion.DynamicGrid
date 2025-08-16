using Newtonsoft.Json.Linq;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Extensions
{
    public static class WhereFilterExtensions
    {
        public static bool MatchesItem(this WhereFilter where, JToken item)
        {
            return item.MatchesWhereFilter(where);
        }

        public static bool MatchesWhereFilter(this JToken item, WhereFilter where)
        {
            if (where.predicates?.Count > 0)
            {
                // Nested condition
                var matches = where.predicates.Select(p => p.MatchesItem(item));
                return where.Condition?.ToLower() switch
                {
                    "or" => matches.Any(m => m),
                    _ => matches.All(m => m) // "and" is default
                };
            }

            var token = item.SelectToken(where.Field);
            var value = token?.ToString();
            var filterValue = $"{where.value}";

            var comparison = where.IgnoreCase
                    ? StringComparison.OrdinalIgnoreCase
                    : StringComparison.Ordinal;

            if (Enum.TryParse<Operator>(where.Operator, true, out var @operator))
            {
                return @operator switch
                {
                    Operator.Equal => string.Equals(value, filterValue, comparison),
                    Operator.NotEqual => !string.Equals(value, filterValue, comparison),
                    Operator.Contains => value?.Contains(filterValue, comparison) == true,
                    Operator.StartsWith => value?.StartsWith(filterValue, comparison) == true,
                    Operator.EndsWith => value?.EndsWith(filterValue, comparison) == true,
                    Operator.GreaterThan => IsGreaterThan(token, where.value),
                    Operator.GreaterThanOrEqual => IsGreaterThanOrEqual(token, where.value),
                    Operator.LessThan => IsLessThan(token, where.value),
                    Operator.LessThanOrEqual => IsLessThanOrEqual(token, where.value),

                    _ => false
                };
            }

            return false;
        }

        private static bool IsGreaterThan(JToken? token, object searchValue)
        {
            if (token is null)
            {
                return false;
            }

            if (token.Type == JTokenType.Integer)
            {
                return (int)token > (int)searchValue;
            }
            if (token.Type == JTokenType.Float)
            {
                return (double)token > (double)searchValue;
            }
            if (token.Type == JTokenType.TimeSpan)
            {
                return (TimeSpan)token > (TimeSpan)searchValue;
            }
            if (token.Type == JTokenType.Date)
            {
                return (DateTime)token > (DateTime)searchValue;
            }

            return false;
        }

        private static bool IsGreaterThanOrEqual(JToken? token, object searchValue)
        {
            if (token is null)
            {
                return false;
            }

            if (token.Type == JTokenType.Integer)
            {
                return (int)token >= (int)searchValue;
            }
            if (token.Type == JTokenType.Float)
            {
                return (double)token >= (double)searchValue;
            }
            if (token.Type == JTokenType.TimeSpan)
            {
                return (TimeSpan)token >= (TimeSpan)searchValue;
            }
            if (token.Type == JTokenType.Date)
            {
                return (DateTime)token >= (DateTime)searchValue;
            }

            return false;
        }

        private static bool IsLessThan(JToken? token, object searchValue)
        {
            if (token is null)
            {
                return false;
            }

            if (token.Type == JTokenType.Integer)
            {
                return (int)token < (int)searchValue;
            }
            if (token.Type == JTokenType.Float)
            {
                return (double)token < (double)searchValue;
            }
            if (token.Type == JTokenType.TimeSpan)
            {
                return (TimeSpan)token < (TimeSpan)searchValue;
            }
            if (token.Type == JTokenType.Date)
            {
                return (DateTime)token < (DateTime)searchValue;
            }

            return false;
        }

        private static bool IsLessThanOrEqual(JToken? token, object searchValue)
        {
            if (token is null)
            {
                return false;
            }

            if (token.Type == JTokenType.Integer)
            {
                return (int)token <= (int)searchValue;
            }
            if (token.Type == JTokenType.Float)
            {
                return (double)token <= (double)searchValue;
            }
            if (token.Type == JTokenType.TimeSpan)
            {
                return (TimeSpan)token <= (TimeSpan)searchValue;
            }
            if (token.Type == JTokenType.Date)
            {
                return (DateTime)token <= (DateTime)searchValue;
            }

            return false;
        }
    }
}