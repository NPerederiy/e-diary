using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eDiary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bool IsAuthorised = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        /* ---- Simple window manipulations ---- */

        public void OnWindowDrag(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public void OnWindowMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        public void OnWindowResize(object sender, RoutedEventArgs e)
        {
            switch (WindowState)
            {
                case WindowState.Maximized:
                    WindowState = WindowState.Normal;
                    break;
                case WindowState.Normal:
                    WindowState = WindowState.Maximized;
                    break;
            }
        }

        public void OnWindowClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /* ---- Page switch ---- */

        private void SetPage(TabControl tabControl, int pageIndex)
        {
            tabControl.SelectedIndex = pageIndex;
        }

        public void OpenAuthenticationPage(object sender, RoutedEventArgs e)
        {
            if(!IsAuthorised)
                SetPage(TabBlock, 0);
        }

        public void OpenAuthPasswordPage(object sender, RoutedEventArgs e)
        {
            if (!IsAuthorised)
                SetPage(TabBlock, 1);
        }

        public void OpenRegistrationPage(object sender, RoutedEventArgs e)
        {
            if (!IsAuthorised)
                SetPage(TabBlock, 2);
        }

        private void OpenHomePage()
        {
            if (IsAuthorised)
                SetPage(TabBlock, 3);
        }

        /* ---- Authentication ---- */

        public void Authenticate(object sender, RoutedEventArgs e)
        {
            IsAuthorised = true;
            OpenHomePage();
        }

        public void Register(object sender, RoutedEventArgs e)
        {
            IsAuthorised = true;
            OpenHomePage();
        }

        /* ---- - ---- */

    }
}
