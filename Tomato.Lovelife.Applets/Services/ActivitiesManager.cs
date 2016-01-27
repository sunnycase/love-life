using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomato.Lovelife.Services;
using Tomato.Uwp.Mvvm;

namespace Tomato.Lovelife.Applets.Services
{
    class ActivitiesManager : BindableBase, IActivitiesManager
    {
        private bool _hasActivity;
        public bool HasActivity
        {
            get { return _hasActivity; }
            private set { SetProperty(ref _hasActivity, value); }
        }

        public ActivitiesManager()
        {

        }
    }
}
