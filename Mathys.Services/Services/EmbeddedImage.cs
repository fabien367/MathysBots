using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mathys.Services.Services
{
    [ContentProperty("RessourceId")]
    public class EmbeddedImage : IMarkupExtension
    {
        public string RessourceId { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrEmpty(RessourceId))
                return null;
            else
            {
                var assembly = typeof(EmbeddedImage).Assembly;
                return ImageSource.FromStream(() => assembly.GetManifestResourceStream(RessourceId));
            }
        }
    }
}
