using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomato.Lovelife.Primitives
{
    public class ScoreMatchActivityComputeResult
    {
        public int LovecaNeeded { get; set; }
        public TimeSpan GameTime { get; set; }
        public int ScoreMatchTimes { get; set; }
        public int FinalLevel { get; set; }
        public int FinalExp { get; set; }
        public int Finalpts { get; set; }
    }

    public class ScoreMatchActivityComputeParam
    {
        public TimeSpan RestTime { get; set; }
        public int WastedLP { get; set; }
        public DifficultyKind Difficulty { get; set; }
        public RankKind Rank { get; set; }
        public PositionKind Position { get; set; }
        public int Goalpts { get; set; }
        public int Nowpts { get; set; }
        public int NowLP { get; set; }
        public int NowLevel { get; set; }
        public int NowExp { get; set; }
    }
}
