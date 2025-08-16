namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation
{
    public sealed class TableUiSchemaInterpreter(IJsonPathInterpreter pathInterpreter) : ITableUiSchemaInterpreter
    {
        public LabelInterpretation InterpretLabel(string? i18n, string? label)
        {
            return new LabelInterpretation(label, i18n);
        }

        public ScopeInterpretation InterpretScope(string scope)
        {
            var absoluteSchemaJsonPath = pathInterpreter.FromElementScope(scope);
            var jsonPropertyName = pathInterpreter.GetJsonPropertyNameFromPath(absoluteSchemaJsonPath);
            return new ScopeInterpretation(absoluteSchemaJsonPath, jsonPropertyName);
        }
    }

    public interface ITableUiSchemaInterpreter
    {
        LabelInterpretation InterpretLabel(string? i18n, string? label);

        ScopeInterpretation InterpretScope(string scope);
    }
}