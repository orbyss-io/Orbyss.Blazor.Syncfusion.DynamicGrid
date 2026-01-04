namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Models;

public sealed class DynamicColumnEnumConfiguration(bool multiSelect)
{
    public bool MultiSelect { get; } = multiSelect;
}