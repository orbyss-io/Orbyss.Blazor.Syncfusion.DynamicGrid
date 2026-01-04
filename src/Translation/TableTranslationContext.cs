using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Extensions;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;
using Orbyss.Components.Json.Models;
using System.Text.Json;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Translation;

public sealed class TableTranslationContext(IJsonPathInterpreter jsonPathInterpreter) : ITableTranslationContext
{
    private static readonly JsonSerializerOptions serializerOptions = GetSerializerOptions();

    private TranslationObject[] translations = [];
    private JObject schema = [];

    public void Instantiate(TranslationSchema? translationSchema, JSchema dataSchema)
    {
        if (translations?.Length > 0)
        {
            throw new InvalidOperationException("Translation context is already instantiated.");
        }

        translations = [.. ConvertToTranslationObjects(translationSchema)];

        schema = JObject.Parse(dataSchema.ToString());
    }

    public IEnumerable<TranslatedEnumItem>? TranslateEnum(string? language, ScopeInterpretation scopeInterpretation)
    {
        var translation = GetTranslationObject(language);
        if (translation is null)
        {
            return GetDefaultTranslatedEnumItems(scopeInterpretation.AbsoluteSchemaJsonPath);
        }

        var translationSectionPath = jsonPathInterpreter.FromSchemaPath(scopeInterpretation.AbsoluteSchemaJsonPath);
        var translationSection = GetSectionByPath(translation, translationSectionPath);

        if (translationSection?.Enums?.Any() == true)
        {
            return translationSection.Enums;
        }

        return GetDefaultTranslatedEnumItems(scopeInterpretation.AbsoluteSchemaJsonPath);
    }

    private IEnumerable<TranslatedEnumItem>? GetDefaultTranslatedEnumItems(string absoluteSchemaJsonPath)
    {
        var enumSchemaSection = schema.SelectToken(absoluteSchemaJsonPath);
        if (enumSchemaSection is null
            || enumSchemaSection is not JObject enumSchemaObject
            || !enumSchemaObject.ContainsKey("enum")
            || enumSchemaObject["enum"] is not JArray enumArray)
        {
            return null;
        }

        return enumArray.Select(x =>
        {
            return new TranslatedEnumItem($"{x}", $"{x}");
        });
    }

    public string? TranslateLabel(string? language, LabelInterpretation? labelInterpretation, string? absoluteSchemaPath)
    {
        var propertyName = !string.IsNullOrWhiteSpace(absoluteSchemaPath)
           ? jsonPathInterpreter.GetJsonPropertyNameFromPath(absoluteSchemaPath)
           : string.Empty;

        var translation = GetTranslationObject(language);

        if (translation is null)
        {
            return propertyName.ToHumanReadableName();
        }

        if (!string.IsNullOrWhiteSpace(labelInterpretation?.I18n)
             && translation.Sections.TryGetValue(labelInterpretation.I18n, out var i18nSection))
        {
            return i18nSection.Label;
        }

        if (!string.IsNullOrWhiteSpace(labelInterpretation?.Value)
            && propertyName != labelInterpretation.Value
            && translation.Sections.TryGetValue(labelInterpretation.Value, out var simpleLabelSection))
        {
            return simpleLabelSection.Label;
        }

        if (string.IsNullOrWhiteSpace(absoluteSchemaPath))
        {
            return null;
        }

        var translationSectionPath = jsonPathInterpreter.FromSchemaPath(absoluteSchemaPath);
        var translationSection = GetSectionByPath(translation, translationSectionPath);
        if (translationSection is not null)
        {
            return translationSection.Label;
        }

        return propertyName?.ToHumanReadableName();
    }

    private TranslationSection? GetSectionByPath(TranslationObject translation, string path)
    {
        var pathElements = jsonPathInterpreter.GetPathElements(path);

        if (pathElements.Length < 1)
        {
            return null;
        }
        if (!translation.Sections.TryGetValue(pathElements[0], out var section) || section is null)
        {
            return null;
        }

        if (pathElements.Length == 1)
        {
            return section;
        }

        if (section.NestedSections is null)
        {
            return null;
        }

        return GetNestedSection(section, pathElements, 1);
    }

    private static TranslationSection? GetNestedSection(TranslationSection parent, string[] pathElements, int currentIndex)
    {
        if (parent.NestedSections is null || parent.NestedSections.Count == 0)
        {
            return null;
        }

        var currentPathElement = pathElements[currentIndex];
        if (!parent.NestedSections.TryGetValue(currentPathElement, out var section))
        {
            return section;
        }

        return GetNestedSection(section, pathElements, currentIndex++);
    }

    private TranslationObject? GetTranslationObject(string? language)
    {
        if (string.IsNullOrWhiteSpace(language))
        {
            return translations.FirstOrDefault();
        }

        return translations.FirstOrDefault(x => x.Language.Equals(language, StringComparison.OrdinalIgnoreCase));
    }

    private static IEnumerable<TranslationObject> ConvertToTranslationObjects(TranslationSchema? translationSchema)
    {
        if (translationSchema is null)
        {
            return [];
        }

        return translationSchema.Resources.Select(x => ConvertToTranslationObject(x.Key, x.Value));
    }

    private static TranslationObject ConvertToTranslationObject(string language, TranslationSchemaResource resource)
    {
        var json = DefaultJsonConverter.Serialize(resource.Translation);
        var sections = JsonSerializer.Deserialize<Dictionary<string, TranslationSection>>(json, serializerOptions);
        var sectionsWithEqualityComparer = new Dictionary<string, TranslationSection>(
            sections ?? [],
            StringComparer.OrdinalIgnoreCase
        );
        return new TranslationObject(language, sectionsWithEqualityComparer);
    }

    private static JsonSerializerOptions GetSerializerOptions()
    {
        var result = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        result.Converters.Add(new TranslationSectionJsonConverter());
        return result;
    }
}