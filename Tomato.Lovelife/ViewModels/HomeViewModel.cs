using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomato.Lovelife.Services;
using Tomato.Uwp.Mvvm;

namespace Tomato.Lovelife.ViewModels
{
    class HomeViewModel : BindableBase
    {
        public IActivitiesManager ActivivitesManager { get; }

        public bool ShowActivity => ActivivitesManager.HasActivity;
        public bool ShowActivityConfiguration => !ActivivitesManager.HasActivity;

        public HomeViewModel(IActivitiesManager activitiesManager)
        {
            ActivivitesManager = activitiesManager;
            ActivivitesManager.PropertyChanged += ActivivitesManager_PropertyChanged;
        }

        private void ActivivitesManager_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IActivitiesManager.HasActivity):
                    OnPropertyChanged(nameof(ShowActivity));
                    OnPropertyChanged(nameof(ShowActivityConfiguration));
                    break;
                default:
                    break;
            }
        }

        public void NavigateToActivities()
        {
            MainViewModel.Current.NavigateToActivities();
        }
    }
}
