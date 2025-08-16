﻿namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Extensions
{
    internal static class StringExtensions
    {
        internal static string ToHumanReadableName(this string value)
        {
            var characters = value.ToCharArray();
            var result = new List<char>();

            for (var i = 0; i < characters.Length; i++)
            {
                var character = characters[i];
                if (i == 0)
                {
                    result.Add(char.ToUpper(character));
                    continue;
                }

                if (char.IsLower(character))
                {
                    result.Add(character);
                    continue;
                }

                if (char.IsUpper(character))
                {
                    result.Add(' ');
                    result.Add(char.ToLower(character));
                }
            }

            return new string([.. result]);
        }
    }
}