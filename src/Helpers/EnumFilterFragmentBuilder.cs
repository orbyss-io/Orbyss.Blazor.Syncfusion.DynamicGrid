using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Models;
using Orbyss.Components.Json.Models;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Grids;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Helpers;

internal static class EnumFilterFragmentBuilder
{
    internal static RenderFragment BuildSingleEnumFilterTemplate(
        object parent,
        SfGrid<JToken> GridRef,
        DynamicColumn col,
        IEnumerable<TranslatedEnumItem> translatedEnums)
    {
        return builder =>
        {
            int seq = 0;
            builder.OpenComponent(seq++, typeof(SfDropDownList<string, TranslatedEnumItem>));
            builder.AddAttribute(seq++, "ValueChanged", EventCallback.Factory.Create<string>(parent, async e =>
            {
                if (string.IsNullOrWhiteSpace(e))
                    await GridRef!.ClearFilteringAsync(col.Scope.AbsoluteSchemaJsonPath);
                else
                {
                    await GridRef!.FilterByColumnAsync(col.Scope.AbsoluteSchemaJsonPath, "equal", e);
                }
            }));

            builder.AddAttribute(seq++, "DataSource", translatedEnums);
            builder.AddAttribute(seq++, "Width", "100%");
            builder.AddAttribute(seq++, "ShowClearButton", false);

            builder.AddAttribute(seq++, "ChildContent", (RenderFragment)(fieldBuilder =>
            {
                fieldBuilder.OpenComponent<DropDownListFieldSettings>(0);
                fieldBuilder.AddAttribute(1, "Value", nameof(TranslatedEnumItem.Value));
                fieldBuilder.AddAttribute(2, "Text", nameof(TranslatedEnumItem.Label));
                fieldBuilder.CloseComponent();
            }));

            builder.CloseComponent();
        };
    }

    internal static RenderFragment BuildMultiEnumFilterTemplate(
        object parent,
        SfGrid<JToken> GridRef,
        DynamicColumn col,
        IEnumerable<TranslatedEnumItem> translatedEnums)
    {
        return builder =>
        {
            int seq = 0;
            builder.OpenComponent(seq++, typeof(SfMultiSelect<List<string>, TranslatedEnumItem>));
            builder.AddAttribute(seq++, "ValueChanged", EventCallback.Factory.Create<List<string>>(parent, async e =>
            {
                if (e is null || e.Count == 0)
                    await GridRef!.ClearFilteringAsync(col.Scope.AbsoluteSchemaJsonPath);
                else
                {
                    await GridRef!.FilterByColumnAsync(col.Scope.AbsoluteSchemaJsonPath, "equal", e.ToArray());
                }
            }));

            builder.AddAttribute(seq++, "DataSource", translatedEnums);
            builder.AddAttribute(seq++, "Width", "100%");
            builder.AddAttribute(seq++, "ShowClearButton", false);

            builder.AddAttribute(seq++, "ChildContent", (RenderFragment)(fieldBuilder =>
            {
                fieldBuilder.OpenComponent<MultiSelectFieldSettings>(0);
                fieldBuilder.AddAttribute(1, "Value", nameof(TranslatedEnumItem.Value));
                fieldBuilder.AddAttribute(2, "Text", nameof(TranslatedEnumItem.Label));
                fieldBuilder.CloseComponent();
            }));

            builder.CloseComponent();
        };
    }
}