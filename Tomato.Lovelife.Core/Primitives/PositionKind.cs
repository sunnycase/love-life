using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomato.Lovelife.Primitives
{
    public enum PositionKind
    {
        Average,
        One,
        Two,
        Three,
        Four
    }

    public struct PositionSelection
    {
        public string Name { get; set; }
        public PositionKind Value { get; set; }
    }
}
