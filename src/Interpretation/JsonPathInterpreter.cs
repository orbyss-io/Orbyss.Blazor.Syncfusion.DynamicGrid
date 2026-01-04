namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;

public sealed class JsonPathInterpreter : IJsonPathInterpreter
{
    public string JoinJsonPaths(string left, string right)
    {
        return string.Concat(
            left,
            right.Replace("$", "")
        );
    }

    public string[] GetPathElements(string path)
    {
        var result = path
            .Split('.', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        result.RemoveAll(x => x == "$");

        return [.. result];
    }

    public string FromElementScope(string? scope)
    {
        if (string.IsNullOrWhiteSpace(scope))
        {
            throw new ArgumentException("Scope is either null or empty");
        }

        return scope
            .Replace("#/", "$.")
            .Replace("/", ".");
    }

    public string FromSchemaPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("Path is either null or empty");
        }

        return path
            .Replace(".items", "")
            .Replace(".properties", "");
    }

    public string AddIndexToPath(string path, int index)
    {
        return $"{path}[{index}]";
    }

    public string GetParentPathFromSchemaPath(string schemaPath)
    {
        if (schemaPath.Contains(".properties"))
        {
            var items = schemaPath.Split('.');
            var index = items.Length - 1;
            while (index > -1)
            {
                var item = items[index];

                if (item == "properties")
                {
                    break;
                }

                index--;
            }

            if (index <= 1)
            {
                return "$";
            }

            var result = Enumerable
                .Range(0, index)
                .Select(i => items[i])
                .ToArray();

            return string.Join('.', result);
        }

        return "$";
    }

    public string GetParentPathFromDataPath(string dataPath)
    {
        var items = dataPath.Split('.');
        if (items.Length > 2)
        {
            var result = Enumerable
                .Range(0, items.Length - 1)
                .Select(i => items[i])
                .ToArray();

            return string.Join('.', result);
        }

        return "$";
    }

    public string GetJsonPropertyNameFromPath(string path)
    {
        return path.Split('.').LastOrDefault() ?? throw new ArgumentException("JSON path does not contain any path elements");
    }
}

public interface IJsonPathInterpreter
{
    string FromElementScope(string? scope);

    string JoinJsonPaths(string left, string right);

    string GetJsonPropertyNameFromPath(string path);

    string[] GetPathElements(string path);

    string FromSchemaPath(string path);

    string AddIndexToPath(string path, int index);

    string GetParentPathFromSchemaPath(string schemaPath);

    string GetParentPathFromDataPath(string dataPath);
}