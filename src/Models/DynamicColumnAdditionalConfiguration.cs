namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Models
{
    public sealed class DynamicColumnAdditionalConfiguration(bool renderBooleanAsCheckbox = false)
    {
        public bool RenderBooleanAsCheckbox { get; } = renderBooleanAsCheckbox;
    }
}
