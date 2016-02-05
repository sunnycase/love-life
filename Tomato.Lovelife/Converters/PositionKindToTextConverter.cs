using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Tomato.Lovelife.Primitives;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Data;

namespace Tomato.Lovelife.Converters
{
    class PositionKindToTextConverter : IValueConverter
    {
        private readonly Dictionary<PositionKind, string> _positionTexts;

        public PositionKindToTextConverter()
        {
            var resource = IoC.Get<ResourceLoader>();
            _positionTexts = new Dictionary<PositionKind, string>
            {
                { PositionKind.Average, resource.GetString("PositionKind/Average") },
                { PositionKind.One, resource.GetString("PositionKind/One") },
                { PositionKind.Two, resource.GetString("PositionKind/Two") },
                { PositionKind.Three, resource.GetString("PositionKind/Three") },
                { PositionKind.Four, resource.GetString("PositionKind/Four") }
            };
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return _positionTexts[(PositionKind)value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
