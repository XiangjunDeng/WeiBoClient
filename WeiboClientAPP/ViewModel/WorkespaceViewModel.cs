using WeiBoClient.View;
using WeiBoClient.ViewModel.EventArgsInViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace WeiBoClient.ViewModel
{
    public class WorkespaceViewModel:BaseViewModel
    {
        /// <summary>
        /// Main Content of MainPage
        /// </summary>
        private StackPanel mainContent;
        public StackPanel MainContent
        {
            get
            {
                return this.mainContent;
            }
            set
            {
                this.mainContent = value;
                NotifyPropertyChanged("MainContent");
            }
        }

        public ICommand WeiboList_Command
        {
            get
            {

                return new DelegateCommand<string>
                (

                    (p) =>
                    {
                        MainContent.Children.Clear();
                        MainContent.Children.Add(new PersonalWeiboList());


                    },
                    (p) =>
                    {
                        return true;
                    }
                );
            }
        }
        public ICommand WriteWeibo_Command
        {
            get
            {

                return new DelegateCommand<string>
                (
                    
                    (p) =>
                    {
                        MainContent.Children.Clear();
                        MainContent.Children.Add(new UCSample());


                    },
                    (p) =>
                    {
                        return true;
                    }
                );
            }
        }

        public ICommand Logout_Command
        {
            get
            {
                
                return new DelegateCommand<string>
                (

                    (p) =>
                    {
                            CancelAuthorize();
                            Authorize();
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
