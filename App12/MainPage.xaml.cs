using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace App12
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            Debug.WriteLine("ctor");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Debug.WriteLine("To: " + e.NavigationMode);
            print();

            if (e.NavigationMode == NavigationMode.New)
            {
                TextBlock1.Text = e.Parameter.ToString();
            }

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Debug.WriteLine("From: " + e.NavigationMode);
            print();

            base.OnNavigatedFrom(e);
        }

        private void new_OnClick(object sender, RoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(MainPage), App.i++);
        }

        private void forward_OnClick(object sender, RoutedEventArgs e)
        {
            if ((Window.Current.Content as Frame).CanGoForward)
            {
                (Window.Current.Content as Frame).GoForward();
            }
        }

        private void back_OnClick(object sender, RoutedEventArgs e)
        {
            if ((Window.Current.Content as Frame).CanGoBack)
            {
                (Window.Current.Content as Frame).GoBack();
            }
        }

        private void print()
        {
            var frame = (Window.Current.Content as Frame);
            Debug.WriteLine($"ForwardStack count: {frame.ForwardStack.Count}");
            Debug.WriteLine($"BackStack count: {frame.BackStack.Count}");
        }

    }
}
