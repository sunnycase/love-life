using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Tomato.Lovelife.Primitives;
using Windows.ApplicationModel.Resources;

namespace Tomato.Lovelife
{
    public static class Constants
    {
        public readonly static RankKind[] Ranks = new[]
        {
            RankKind.None, RankKind.C, RankKind.B, RankKind.A, RankKind.S
        };

        public readonly static PositionKind[] Positions = new[]
        {
            PositionKind.Average, PositionKind.One, PositionKind.Two, PositionKind.Three, PositionKind.Four
        };

        static Constants()
        {
            var resource = IoC.Get<ResourceLoader>();
        }

        public readonly static Guid CurrentProfileId = new Guid("1C0B9443-BC69-4942-A854-FAA57D9CDF75");
    }
}
