namespace Orbyss.Blazor.Syncfusion.DynamicGrid;

public sealed class DynamicGridOptions
{
    private DynamicGridOptions()
    {
    }

    public bool EnablePaging { get; init; }

    public bool EnableVirtualization { get; init; }

    public int? PageSize { get; init; }

    public VirtualizationOptions? VirtualizationOptions { get; init; }

    public PaginationOptions? PaginationOptions { get; init; }

    public static readonly DynamicGridOptions Default = new();

    public static DynamicGridOptions Pagination(int pageSize)
    {
        return new DynamicGridOptions
        {
            EnablePaging = true,
            PaginationOptions = new(),
            PageSize = pageSize
        };
    }

    public static DynamicGridOptions Virtualization(int pageSize, VirtualizationOptions? options = null)
    {
        return new DynamicGridOptions
        {
            PageSize = pageSize,
            VirtualizationOptions = options,
            EnablePaging = false,
            EnableVirtualization = true
        };
    }
}

public record VirtualizationOptions(
    string FixedHeight,
    bool EnableMaskRows = false,
    bool? EnableCache = null,
    int? InitialBlocksToLoad = null,
    int? MaximumBlocksToRender = null
);

public record PaginationOptions(
);