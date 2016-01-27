using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tomato.Lovelife.Primitives;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace Tomato.Lovelife.Views.Activities
{
    [TemplatePart(Name = "PART_ContentHost", Type = typeof(Border))]
    public sealed class ActivityCalculatorPresenter : Control
    {
        public static DependencyProperty ActivityProperty { get; } = DependencyProperty.Register(nameof(Activity), typeof(IActivity),
            typeof(ActivityCalculatorPresenter), new PropertyMetadata(null, OnActivityPropertyChanged));

        public IActivity Activity
        {
            get { return (IActivity)GetValue(ActivityProperty); }
            set { SetValue(ActivityProperty, value); }
        }

        private Border _contentHost;

        public ActivityCalculatorPresenter()
        {
            this.DefaultStyleKey = typeof(ActivityCalculatorPresenter);
        }

        protected override void OnApplyTemplate()
        {
            _contentHost = (Border)GetTemplateChild("PART_ContentHost");
            UpdateContent();
            base.OnApplyTemplate();
        }

        private static void OnActivityPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ActivityCalculatorPresenter)?.UpdateContent();
        }

        private void UpdateContent()
        {
            var activity = Activity;
            if (activity == null)
                SetContent(null);
            else if (activity is ScoreMatchActivity)
                SetContent(new ScoreMatchView((ScoreMatchActivity)activity));
        }

        private void SetContent(UIElement content)
        {
            if (_contentHost != null)
                _contentHost.Child = content;
        }
    }
}
