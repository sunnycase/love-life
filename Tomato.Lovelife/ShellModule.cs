﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Tomato.Lovelife.ViewModels;
using Windows.ApplicationModel.Resources;

namespace Tomato.Lovelife
{
    static class ShellModule
    {
        public static void UseShell(this SimpleContainer container)
        {
            container.PerRequest<MainViewModel>();
            container.PerRequest<HomeViewModel>();
            container.PerRequest<ActivitiesViewModel>();
            container.Instance(ResourceLoader.GetForCurrentView());
        }

        private static void ModuleReferences()
        {
            var type = new[]
            {
                typeof(Caliburn.Micro.ViewModelBinder)
            };
        }
    }
}
