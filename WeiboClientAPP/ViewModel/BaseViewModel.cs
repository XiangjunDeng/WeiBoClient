using WeiBoClient.Model;
using WeiBoClient.Utility;
using WeiBoClient.ViewModel.EventArgsInViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiboSDKForWinRT;
using Windows.Storage;
using Windows.UI.Xaml.Controls;


namespace WeiBoClient.ViewModel
{
    public abstract class BaseViewModel : ExInvokeCommandAction, INotifyPropertyChanged
    {
        private ClientOAuth oauthClient = new ClientOAuth();
        private string picPath = string.Empty;
        public BaseModel AppInfo = XmlUtility.Instance.GetAppSettingByKey();
        public event PropertyChangedEventHandler PropertyChanged;


        protected void NotifyPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #region Properties

        /// <summary>
        /// 用户是否授权(包含授权过期的状态).
        /// </summary>
        private bool isLoginSuccess;
        public bool IsLoginSuccess
        {
            get
            {
                return this.isLoginSuccess;
            }
            set
            {
                this.isLoginSuccess = value;
                NotifyPropertyChanged("IsLoginSuccess");
            }
        }
        /// <summary>
        /// Display Name
        /// </summary>
        private string displayName;
        public string DisplayName
        {
            get
            {
                return this.displayName;
            }
            set
            {
                this.displayName = value;
                NotifyPropertyChanged("DisplayName");
            }
        }

        private string userName;
        public string UserName {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        private string password;
        public string Password {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
                NotifyPropertyChanged("Password");
            }
        }

        #endregion

        /// <summary>
        /// Go to authorize
        /// </summary>
        protected void Authorize()
        {
            BaseModel baseParameter = XmlUtility.Instance.GetAppSettingByKey();
            if (null != baseParameter)
            {
                SdkData.AppKey = baseParameter.AppKey;
                SdkData.AppSecret = baseParameter.AppSecret;
                SdkData.RedirectUri = baseParameter.RedirectUri;
            }
            // prepare the pic to be shared.
            //CopyToIso("Assets/weibo.png", "weibo");
            //Judge the authorization is expired whether or not.
            if (oauthClient.IsAuthorized == false)
            {
                oauthClient.LoginCallback += (isSuccess, err, response) =>
                {
                    if(isSuccess)
                    {
                        IsLoginSuccess = true;
                    }
                    else
                    {
                        IsLoginSuccess = false;
                    }
                };
            }
            else
            {
                IsLoginSuccess = true;
            }
                oauthClient.BeginOAuth();
        }

        protected void CancelAuthorize()
        {
            oauthClient.CancelAuthorize();
        }

        private async void CopyToIso(string source, string dest)
        {
            try
            {
                // Get image buffer.
                var uri = new Uri("ms-appx:///" + source);
                StorageFile sourceFile = await StorageFile.GetFileFromApplicationUriAsync(uri);
                var dataBuffer = await Windows.Storage.FileIO.ReadBufferAsync(sourceFile);

                StorageFolder picFolder = ApplicationData.Current.LocalFolder;
                // write buffer to storage.
                StorageFile file = await picFolder.CreateFileAsync(sourceFile.Name, CreationCollisionOption.OpenIfExists);

                await Windows.Storage.FileIO.WriteBufferAsync(file, dataBuffer);
                picPath = file.Path;
            }
            catch (Exception err)
            {
                // Note: exception  happed.
            }
        }
    }
}
