using Newtonsoft.Json.Schema;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;
using Orbyss.Components.Json.Models;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Translation
{
    public interface ITableTranslationContext
    {
        void Instantiate(TranslationSchema translationSchema, JSchema dataSchema);

        string? TranslateLabel(string? language, LabelInterpretation? labelInterpretation = null, string? absoluteSchemaPath = null);

        IEnumerable<TranslatedEnumItem>? TranslateEnum(string? language, ScopeInterpretation scopeInterpretation);
    }
}