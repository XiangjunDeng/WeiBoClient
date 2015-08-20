using WeiBoClient.Model;
using WeiBoClient.ViewModel.EventArgsInViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeiboSDKForWinRT;
using Newtonsoft.Json;
using WeiBoClient.Utility;
using System.Xml.Linq;

namespace WeiBoClient.ViewModel
{
    public class PersonalWeiboListViewModel : BaseViewModel
    {
        private ObservableCollection<WeiboItem> weiboList;
        private string count;
        private string pageIndex;
        private string testWeiboText;

        /// <summary>
        /// Weibo List
        /// </summary>
        public ObservableCollection<WeiboItem> WeiboList
        {
            get { return this.weiboList; }
            set { this.weiboList = value; NotifyPropertyChanged("WeiboList"); }
        }

        public string TextWeiboText
        {
            get
            {
                return this.testWeiboText;
            }
            set
            {
                this.testWeiboText = value;
                NotifyPropertyChanged("TextWeiboText");
            }
        }
        public string Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
                NotifyPropertyChanged("Count");
            }
        }
        public string PageIndex
        {
            get
            {
                return this.pageIndex;
            }
            set
            {
                this.pageIndex = value;
                NotifyPropertyChanged("PageIndex");
            }
        }

        /// <summary>
        /// call the timeline of SDK
        /// </summary>
        public ICommand GetTimeline_Command
        {
            get
            {
                
                string result = string.Empty;
                //
                Task.WaitAll(Task.Run(async delegate { result = await Timeline(); }));
                TextWeiboText = result;
                //result = "";
                Model.WeiboStatuses.WeiboItem testWeibo = new Model.WeiboStatuses.WeiboItem(result);


                ////Get the "statuses" Node
                //XDocument statuses = JsonConverterTool.GetWeiboList(result);
                //ObservableCollection<WeiboItem> newWeiboList = new ObservableCollection<WeiboItem>();
                //IEnumerable<XElement> existStatuses = statuses.Descendants("statuses");
                //int weiboItemCount = existStatuses.Count() - 1;
                //for (int i = 0; i < weiboItemCount; i++)
                //{
                //    WeiboItem wi = new WeiboItem();
                //    IEnumerable<XElement> existsText = existStatuses.ElementAt(i + 1).Descendants("text");
                //    for (int j = 0; j < existsText.Count(); j++)
                //    {
                //        wi.Text += existsText.ElementAt(j).Value;
                //        wi.Name = existStatuses.ElementAt(i + 1).Element("user").Element("name").Value;
                //        wi.Created_at = existStatuses.ElementAt(i + 1).Element("created_at").Value;
                //    }
                //    newWeiboList.Add(wi);
                //}
                

                //WeiboList = newWeiboList;
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

        #region Private methods
        
        private async Task<string> Timeline()
        {
            var engine = new SdkNetEngine();
            ISdkCmdBase cmdBase = new CmdUserTimeline()
            {

                UserId="wu9xia@sina.cn",
                Count = "2",
                Page = "1"
            };
            var result = await engine.RequestCmd(SdkRequestType.USER_TIMELINE, cmdBase);

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
    }
}
