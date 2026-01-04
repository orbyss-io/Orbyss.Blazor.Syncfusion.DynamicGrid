using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation.Extensions;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Grids;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Models;

public sealed class DynamicColumn(
    TableColumnType columnType,
    ScopeInterpretation scopeInterpretation,
    string field,
    LabelInterpretation headerLabel,
    Operator? filterOperator,
    string width,
    DynamicColumnAdditionalConfiguration? additionalConfiguration = null,
    TextAlign textAlign = TextAlign.Left,
    string? format = null,
    bool sortable = false,
    bool hasHeaderFilter = false)
{
    private ColumnType? columnType;

    public ColumnType GetSfColumnType()
    {
        if (!columnType.HasValue)
        {
            columnType = ColumnType.ToSfColumnType(AdditionalConfiguration);
        }

        return columnType.Value;
    }

    public TableColumnType ColumnType { get; } = columnType;

    public ScopeInterpretation Scope { get; } = scopeInterpretation;

    public string Field { get; } = field;

    public LabelInterpretation HeaderLabel { get; } = headerLabel;

    public string Width { get; } = width;

    public RenderFragment<JToken>? Template { get; internal set; }

    public RenderFragment? FilterTemplate { get; internal set; }

    public DynamicColumnAdditionalConfiguration AdditionalConfiguration { get; } = additionalConfiguration ?? new();

    public TextAlign TextAlign { get; } = textAlign;

    public string? Format { get; } = format;

    public bool Sortable { get; } = sortable;

    public bool HasHeaderFilter { get; } = hasHeaderFilter;

    public Operator? FilterOperator { get; } = filterOperator;
}