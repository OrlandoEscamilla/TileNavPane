using DevExpress.Mvvm;
using DevExpress.Xpf.CodeView.Margins;
using DevExpress.Xpf.Docking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TileNavPane.Common;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace TileNavPane.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {

        public event ViewModelClosingEventHandler RequestClose;

        ICommand _autentificarcommand;
        ICommand _closeCommand;

        IMessageBoxService MessageBoxService { get { return GetService<IMessageBoxService>(); } }


        public bool Autentificado;

        public string UserName
        {
            get { return GetProperty(() => UserName); }
            set { SetProperty(() => UserName, value); }
        }
        public string Password
        {
            get { return GetProperty(() => Password); }
            set { SetProperty(() => Password, value); }
        }


        public ICommand AutentificarCommand
        {
            get
            {
                return _autentificarcommand ?? (_autentificarcommand = new AsyncCommand(async () =>
                {
                    using (Data.DataSet1TableAdapters.TA_USUARIOS ta = new Data.DataSet1TableAdapters.TA_USUARIOS())
                    {
                        //Data.DataSet1.DT_USUARIOSRow rowUsuario = ta.GetData(UserName, Password)?.FirstOrDefault();

                        OM_SESION objOM_SESION = ta.GetData(UserName, Password)?.Select(x => new OM_SESION()
                        {
                            ID_USUARIO = x.ID_USUARIO,
                            USERNAME = x.USERNAME,
                            NOMBRE = x.NOMBRE

                        })?.FirstOrDefault() ?? new OM_SESION();

                        //var result = ta.GetData(UserName, Password).ToList();

                        if(objOM_SESION.ID_USUARIO != null)
                        {
                            Singleton.Instance.Session = objOM_SESION;

                            Autentificado = true;

                            MainWindow view = new MainWindow();
                            MainWindowVM context = new MainWindowVM();
                            view.DataContext = context;

                            //context.ShowDialog(null, "Actualizar Registro", context);
                            view.Show();
                            RequestClose?.Invoke(this, new ViewModelClosingEventArgs(this));
                        }
                        else
                        {
                            //Console.WriteLine("Información incorrecta");

                            MessageBoxService.ShowMessage("Verificar usuario y contraseña", "Error", MessageButton.OK, MessageIcon.Error);
                        }

                    }
                 
                },
                () => { return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password); }));
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new DelegateCommand(() =>
                {
                    RequestClose?.Invoke(this, new ViewModelClosingEventArgs(this));

                }));
            }
        }
    }
}
