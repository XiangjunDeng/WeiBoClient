using WeiBoClient.Consts;
using WeiBoClient.ViewModel.EventArgsInViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WeiBoClient.View;

namespace WeiBoClient.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        //public string UserName { get; set; }
        //public string Password { get; set; }

        private string loginStatusText;
        /// <summary>
        /// Login Status
        /// </summary>
        public string LoginStatusText
        {
            get
            {
                return this.loginStatusText;
            }
            set
            {
                this.loginStatusText = value;
                NotifyPropertyChanged("LoginStatusText");
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                Authorize();

                return new DelegateCommand<string>
                (
                    (p) =>
                    {

                        if (IsLoginSuccess)
                        {
                            LoginStatusText = LoginStatus.LoginSuccess;
                        }
                        else
                        {
                            LoginStatusText = LoginStatus.LoginFailed;
                            //Frame.Navigate(typeof(UCSample));
                        }

                    },
                    (p) =>
                    {
                        return true;
                    }
                );

            }
        }
    }
}


