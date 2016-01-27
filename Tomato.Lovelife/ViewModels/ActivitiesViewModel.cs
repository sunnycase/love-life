using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomato.Lovelife.Primitives;
using Tomato.Uwp.Mvvm;

namespace Tomato.Lovelife.ViewModels
{
    class ActivitiesViewModel : BindableBase
    {
        private IActivity _currentActivity;
        public IActivity CurrentActivity
        {
            get { return _currentActivity; }
            private set { SetProperty(ref _currentActivity, value); }
        }

        public ActivitiesViewModel()
        {
            CurrentActivity = new ScoreMatchActivity
            {
                Name = "第16次 Score Match",
                AvailableDifficulty = new[] { DifficultyKind.Easy, DifficultyKind.Normal, DifficultyKind.Hard, DifficultyKind.Expert }
            };
        }
    }
}
