# Orbyss.Blazor.Syncfusion.DynamicGrid

`Orbyss.Blazor.Syncfusion.DynamicGrid` is a NuGet package that allows you to generate a **Syncfusion SfGrid** dynamically using JSON schemas.  
The grid’s **columns, filters, and localization** are all defined through schemas, giving you a highly flexible and schema-driven way of rendering tables.

---

## ✨ Features

- Define grid **columns, filters, and translations** entirely through JSON schema.
- UI Schema (`TableUiSchema`) controls **width, layout, alignment, labels, and filter types**.
- Supports **initial sorting** through schema (`InitialOrdering`).
- Automatic **localization support** via `TranslationSchema`.
- Plug in your own **data provider** via `IDynamicGridDataProvider`.
- Open source and extensible — contribute missing `SfGrid` features!

---

## 🚀 Getting Started

### 1. Configure Syncfusion

In `wwwroot/index.html`:

```html
<link href="_content/Syncfusion.Blazor.Themes/tailwind.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```

### 2. Register Services

In `MauiProgram.cs`:

```csharp
// Register License Key
SyncfusionLicenseProvider.RegisterLicense("YOUR_LICENSE_KEY");

// Register Syncfusion Blazor Core services
builder.Services.AddSyncfusionBlazor();

// Register Dynamic Data Grid
builder.Services.AddSyncfusionDynamicGrid((sp) => new JTokenDataAdaptor(
        new MockDynamicGridDataProvider()
    )
);
```

⚠️ **Note:** If you use the built-in `JTokenDataAdaptor`, you must implement `IDynamicGridDataProvider`. Optionally, you could provide your own DataAdaptor all together

Example of `IDynamicGridDataProvider` implementation:

```csharp
internal class MockDynamicGridDataProvider : IDynamicGridDataProvider
{
    private readonly JArray array = JArray.Parse("[...]");

    public Task<DynamicGridDataProviderResult> GetData(DataManagerRequest request, string? whereFilterHash, string? sortOrderHash)
    {
        var items = array.Where(token =>
        {
            var result = request.Where?.All(where =>
            {
                return where?.MatchesItem(token) != false;
            });

            return result != false;
        });

        if (request.Skip > 0 || request.Take > 0)
        {
            items = items.Skip(request.Skip).Take(request.Take);
        }

        if (request.Sorted?.Count > 0)
        {
            var sorted = request.Sorted[0];
            IOrderedEnumerable<JToken> ordered;

            if (sorted.Direction.Equals(nameof(SortDirection.Descending), StringComparison.OrdinalIgnoreCase))
            {
                ordered = items.OrderByDescending(x => $"{x.SelectToken(sorted.Name)}");
            }
            else
            {
                ordered = items.OrderBy(x => $"{x.SelectToken(sorted.Name)}");
            }

            items = ordered;
        }

        var result = new DynamicGridDataProviderResult(
            items,
            array.Count
        );

        return Task.FromResult(result);
    }
}
```

---

### 3. Provide Schema(s)

At minimum, you need a **JSON schema** for your data.

You may also provide:

- `TableUiSchema` → Customize filters, widths, alignments, and layouts.
- `TranslationSchema` → For localization.

---

### 4. Render the Grid

```razor
@* Parameters:
[Required] ItemsJsonSchema
[Required] TableUiSchema
[Optional] TranslationSchema
*@

<DynamicSfGrid 
    ItemsJsonSchema="@ExampleConstants.JsonSchema" 
    TableUiSchema="@ExampleConstants.TableUiSchema"
    TranslationSchema="@ExampleConstants.TranslationSchema" />
```

---

## ⚙️ Parameters

```csharp
[Parameter] public Type CustomDataAdaptorType { get; set; } = typeof(JTokenDataAdaptor);
[Parameter] public IEnumerable<ItemModel> ToolbarItems { get; set; } = [];
[Parameter] public TableUiSchema? TableUiSchema { get; set; } = default!;
[Parameter] public TranslationSchema? TranslationSchema { get; set; }
[Parameter, EditorRequired] public JSchema ItemsJsonSchema { get; set; } = default!;
[Parameter] public DynamicGridOptions Options { get; set; } = DynamicGridOptions.Default;
```

---

## 🌍 Localization

Localization is handled via:

```csharp
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
```

Whenever `DynamicGridCulture.Instance` changes, the grid automatically updates column labels, filters, and values.

---

## ⚡ Options

Using `DynamicGridOptions` you can configure pagination and virtualization:

```csharp
public sealed class DynamicGridOptions
{
    public bool EnablePaging { get; init; }
    public bool EnableVirtualization { get; init; }
    public int? PageSize { get; init; }
    public VirtualizationOptions? VirtualizationOptions { get; init; }    

    public static readonly DynamicGridOptions Default = new();
}
```

```csharp
public record VirtualizationOptions(
    string FixedHeight,
    bool EnableMaskRows = false,
    bool? EnableCache = null,
    int? InitialBlocksToLoad = null,
    int? MaximumBlocksToRender = null
);
```

---

## 📄 License

MIT License  
© Orbyss.io

---

## 🔗 Links

- 🌍 **Website**: [https://orbyss.io](https://orbyss.io)
- 📦 **This Package**: [Orbyss.Blazor.Syncfusion.DynamicGrid](https://www.nuget.org/packages/Orbyss.Blazor.Syncfusion.DynamicGrid)
- 📦 **Other Packages**: [Orbyss.io](https://www.nuget.org/profiles/Orbyss.io)
- 🧑‍💻 **GitHub**: [https://github.com/orbyss-io](https://github.com/orbyss-io)
- 📚 **Syncfusion Docs**: [Syncfusion Blazor UI](https://blazor.syncfusion.com/)
- 📝 **License**: [MIT](./LICENSE)

---

## 🤝 Contributing

This project is open source and contributions are welcome!

Whether it's bug fixes, improvements, documentation, or ideas — we encourage developers to get involved.  
Just fork the repo, create a branch, and open a pull request.

We follow standard .NET open-source conventions:
- Write clean, readable code
- Keep PRs focused and descriptive
- Open issues for larger features or discussions

No formal contribution guidelines — just be constructive and respectful.

---

⭐️ Found this useful? [Give us a star](https://github.com/orbyss-io/Orbyss.Blazor.Syncfusion.DynamicGrid/stargazers) and help spread the word!
