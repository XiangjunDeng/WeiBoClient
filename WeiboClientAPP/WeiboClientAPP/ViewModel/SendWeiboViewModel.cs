using WeiBoClient.ViewModel.EventArgsInViewModel;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WeiboSDKForWinRT;
using WeiboClient.Model;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Collections.Generic;
using Windows.UI.Xaml.Media.Imaging;
using System.IO;

namespace WeiBoClient.ViewModel
{
    public class SendWeiboViewModel : BaseViewModel
    {
        private string sendContent;
        public string SendContent
        {
            get
            {
                return sendContent;
            }

            set
            {
                sendContent = value;
                NotifyPropertyChanged("SendContent");
            }
        }

        private BitmapImage sendPic;
        public BitmapImage SendPic
        {
            get
            {
                return sendPic;
            }

            set
            {
                sendPic = value;
                NotifyPropertyChanged("SendPic");
            }
        }

        private string sendPicPath;
        public string SendPicPath
        {
            get
            {
                return sendPicPath;
            }

            set
            {
                sendPicPath = value;
                NotifyPropertyChanged("SendPicPath");
            }
        }

        private ObservableCollection<WeiBoItemTestModel> weibo;
        public ObservableCollection<WeiBoItemTestModel> ListItems
        {
            get
            {
                return weibo;
            }
            set
            {
                this.weibo = value;
                NotifyPropertyChanged("ListItems");
            }
        }

        public ICommand PostMsgWithoutPic
        {
            get
            {

                return new DelegateCommand<string>
                (

                    (p) =>
                    {
                        string result = string.Empty;
                        Task.WaitAll(Task.Run(async delegate { result = await PostMSgnopic(SendContent); }));

                    },
                    (p) =>
                    {
                        return true;
                    }
                );

            }
        }

        #region private postmsgwithoutpic method
        private async Task<string> PostMSgnopic(string contentStr)
        {
            var engine = new SdkNetEngine();

            ISdkCmdBase cmdBase = new CmdPostMessage()
            {
                Status = contentStr,
            };

            var result = await engine.RequestCmd(SdkRequestType.POST_MESSAGE, cmdBase);

            if (result.errCode == SdkErrCode.SUCCESS)
            {
                return result.content;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        public ICommand PostMsgWithPic
        {
            get
            {

                return new DelegateCommand<string>
                    (
                    (p) =>
                    {
                        string result = string.Empty;
                        Task.WaitAll(Task.Run(async delegate { result = await Postmsgpic(SendContent, SendPic); }));
                    },
                    (p) =>
                    {
                        return true;
                    }
                    );
            }
        }
        #region private postmsgwithpic method
        private async Task<string> Postmsgpic(string content, BitmapImage contentPic)
        {
            var engine = new SdkNetEngine();
            ISdkCmdBase cmdBase = new CmdPostMsgWithPic()
            {
                Status = content,
                PicPath = SendPicPath

            };
            var result = await engine.RequestCmd(SdkRequestType.POST_MESSAGE_PIC, cmdBase);
            if (result.errCode == SdkErrCode.SUCCESS)
            {
                return result.content;

            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        public ICommand Atuser
        {
            get
            {
                string reslut = string.Empty;
                Task.WaitAll(Task.Run(async delegate { reslut = await AtUser(); }));

                return new DelegateCommand<string>
                (
                    (p) =>
                    {


                    },
                    (p) =>
                    {
                        return true;
                    }
                );
            }
        }
        #region private atuser method
        private async Task<string> AtUser()
        {
            var engine = new SdkNetEngine();
            ISdkCmdBase cmdBase = new CmdAtUsers()
            {
                Count = "10",
                Type = "0",
                Keyword = "q",
                Range = "2"

            };
            var result = await engine.RequestCmd(SdkRequestType.AT_USERS, cmdBase);
            if (result.errCode == SdkErrCode.SUCCESS)
            {
                return result.content;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        public ICommand Get_picture
        {
            get
            {

                return new DelegateCommand<string>
                               (
                                   async (p) =>
                                   {
                                       var picker = new FileOpenPicker();
                                       picker.SuggestedStartLocation = PickerLocationId.Desktop;
                                       picker.FileTypeFilter.Add(".jpg");
                                       picker.FileTypeFilter.Add(".jpeg");
                                       picker.FileTypeFilter.Add(".png");
                                       StorageFile file = await picker.PickSingleFileAsync();
                                       var dataBuffer = await Windows.Storage.FileIO.ReadBufferAsync(file);
                                       if (file != null)
                                       {
                                           StorageFolder picFolder = ApplicationData.Current.LocalFolder;
                                           // write buffer to storage.
                                           StorageFile object_file = await picFolder.CreateFileAsync(file.Name, CreationCollisionOption.OpenIfExists);

                                           await Windows.Storage.FileIO.WriteBufferAsync(object_file, dataBuffer);
                                           SendPicPath = object_file.Path;

                                           Windows.Storage.Streams.IRandomAccessStream fileStream =
                                                             await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                                           BitmapImage image = new BitmapImage(new Uri(file.Path, UriKind.Absolute));
                                           image.SetSource(fileStream);
                                           SendPic = image;
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

