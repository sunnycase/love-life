using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Tomato.Lovelife.Applets.Services;
using Tomato.Lovelife.Services;
using Windows.ApplicationModel.Resources;

namespace Tomato.Lovelife
{
    public static class AppletsModule
    {
        public static void UseApplets(this SimpleContainer container)
        {
            container.Singleton<IActivitiesManager, ActivitiesManager>();
        }
    }
}
