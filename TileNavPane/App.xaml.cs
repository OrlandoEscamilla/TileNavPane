using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TileNavPane.ViewModel;

namespace TileNavPane
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //base.OnStartup(e);
            //MainWindow view = new MainWindow();
            //MainWindowVM context = new MainWindowVM();
            //view.DataContext = context;
            //view.Show();

            base.OnStartup(e);
            Login loginView = new Login();
            LoginViewModel contextLogin = new LoginViewModel();
            loginView.DataContext = contextLogin;

            contextLogin.RequestClose += (a, b) =>
            {
                LoginViewModel context = a as LoginViewModel;
                if (context.Autentificado)
                {
                    loginView.DialogResult = true;
                }
                else
                    loginView.DialogResult = false;
            };

            //loginView.Activate();


            loginView.ShowDialog();
        }
    }
}
