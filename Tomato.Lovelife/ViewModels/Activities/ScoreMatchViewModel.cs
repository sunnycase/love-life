using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomato.Lovelife.Primitives;
using Tomato.Uwp.Mvvm;

namespace Tomato.Lovelife.ViewModels.Activities
{
    class ScoreMatchViewModel : BindableBase
    {
        public ScoreMatchActivity Activity { get; }

        private TimeSpan _restTime;
        public TimeSpan RestTime
        {
            get { return _restTime; }
            set { SetProperty(ref _restTime, value); }
        }

        private int _wastedLP;
        public int WastedLP
        {
            get { return _wastedLP; }
            set { SetProperty(ref _wastedLP, value); }
        }

        private DifficultyKind _difficulty;
        public object Difficulty
        {
            get { return _difficulty; }
            set { SetProperty(ref _difficulty, (DifficultyKind)value); }
        }

        public RankKind[] AvailableRanks => Constants.Ranks;

        private RankKind _rank;
        public object Rank
        {
            get { return _rank; }
            set { SetProperty(ref _rank, (RankKind)value); }
        }

        public ScoreMatchViewModel(ScoreMatchActivity activity)
        {
            Activity = activity;
            Difficulty = activity.AvailableDifficulty.First();
        }
    }
}
