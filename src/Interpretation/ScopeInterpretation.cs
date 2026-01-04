namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;

public sealed class ScopeInterpretation(
    string absoluteSchemaJsonPath,
    string jsonPropertyName)
{
    public string AbsoluteSchemaJsonPath { get; } = absoluteSchemaJsonPath;

    public string JsonPropertyName { get; } = jsonPropertyName;
}