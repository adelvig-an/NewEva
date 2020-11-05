using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace NewEva.StyleHelper
{
    [MarkupExtensionReturnType(typeof(FontFamily))]
    public class MaterialDesignFontExtension : MarkupExtension
    {
        private static readonly Lazy<FontFamily> _roboto
            = new Lazy<FontFamily>(() =>
                new FontFamily(new Uri("pack://application:,,,/;component/Resources/DINPro/"), "./#DINPro"));

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _roboto.Value;
        }
    }
}