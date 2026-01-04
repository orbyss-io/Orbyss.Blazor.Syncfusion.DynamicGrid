using System.Globalization;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid;

public static class DynamicGridCulture
{
    private static CultureInfo instance = new("en-US");

    public static event Action CultureChanged = default!;

    public static CultureInfo Instance
    {
        get => instance;
        set
        {
            instance = value;
            CultureChanged?.Invoke();
        }
    }
}