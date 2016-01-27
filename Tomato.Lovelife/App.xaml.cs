using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Caliburn.Micro;
using Tomato.Lovelife.Views;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Tomato.Lovelife
{
    /// <summary>
    /// 提供特定于应用程序的行为，以补充默认的应用程序类。
    /// </summary>
    sealed partial class App : CaliburnApplication
    {
        private WinRTContainer _container;
        private IEventAggregator _eventAggregator;
        private ILog _logger;

        /// <summary>
        /// 初始化单一实例应用程序对象。这是执行的创作代码的第一行，
        /// 已执行，逻辑上等同于 main() 或 WinMain()。
        /// </summary>
        public App()
        {
            LogManager.GetLog = type => new DebugLog(type);
            _logger = LogManager.GetLog(typeof(App));

            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session |
                Microsoft.ApplicationInsights.WindowsCollectors.PageView |
                Microsoft.ApplicationInsights.WindowsCollectors.UnhandledException);
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            this.UnhandledException += App_UnhandledException;
            this.InitializeComponent();
        }

        private void App_UnhandledException(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            var client = new Microsoft.ApplicationInsights.TelemetryClient();
            client.TrackException(e.Exception);
            _logger.Error(e.Exception);
            e.Handled = true;
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            var client = new Microsoft.ApplicationInsights.TelemetryClient();
            client.TrackException(e.Exception);
            _logger.Error(e.Exception);
            e.SetObserved();
        }

        protected override void Configure()
        {
            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            _container.UseShell();
            _container.UseApplets();
            _eventAggregator = _container.GetInstance<IEventAggregator>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            _container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            DisplayRootView<MainView>();
            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                //_eventAggregator.PublishOnUIThread(new ResumeStateMessage());
            }
        }
    }
}
