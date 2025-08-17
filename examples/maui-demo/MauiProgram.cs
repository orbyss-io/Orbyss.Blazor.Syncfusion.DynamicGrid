using Microsoft.Extensions.Logging;
using Orbyss.Blazor.Syncfusion.DynamicGrid.DataAdaptors;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Extensions;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace Syncfusion.DynamicGrid.Demo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // Register License Key
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JEaF5cXmRCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXdfd3RcQ2BZWU11XkZWYEk=");

            // Register Syncfusion Blazor Core services
            builder.Services.AddSyncfusionBlazor();

            // Register Dynamic Data Grid
            builder.Services.AddSyncfusionDynamicGrid((sp) => new JTokenDataAdaptor(
                    new MockDynamicGridDataProvider()
                )
            );

            try
            {
                var u = ExampleConstants.TableUiSchema;
                var t = ExampleConstants.TranslationSchema;
                var j = ExampleConstants.JsonSchema;
            }
            catch (Exception e)
            {
                var r = e.Message;
            }

            return builder.Build();
        }
    }
}