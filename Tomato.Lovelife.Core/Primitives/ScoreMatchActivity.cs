using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomato.Uwp.Mvvm;

namespace Tomato.Lovelife.Primitives
{
    public sealed class ScoreMatchActivity : IActivity
    {
        public string Name { get; set; }
        public DateTime EndTime { get; set; }
        public DifficultyKind[] AvailableDifficulty { get; set; }
    }
}
