using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomato.Lovelife.Views;
using Tomato.Uwp.Mvvm;
using Windows.UI.Xaml.Controls;

namespace Tomato.Lovelife.ViewModels
{
    class MainViewModel : BindableBase
    {
        private Frame _navigationService;

        public static MainViewModel Current { get; private set; }

        public MainViewModel()
        {
            Current = this;
        }

        public void SetupNavigationService(object sender, object e)
        {
            _navigationService = (Frame)sender;
            NavigateToHome();
        }

        public void NavigateToHome()
        {
            _navigationService?.Navigate(typeof(HomeView));
        }

        public void NavigateToActivities()
        {
            _navigationService?.Navigate(typeof(ActivitiesView));
        }

        public void NavigateToSettings()
        {

        }
    }
}
