using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoClient.Model.WeiboStatuses;

namespace WeiboClient.Model
{
	public class WeiBoItemTestModel : BaseStatus
	{
		//Item View display
		private string image;
		private string nickName;
		private string time;
		private string text;
		private string repostText;
		private string repostName;
		private string source;

		//Send weibo display
        private string picture;

		//Friends List display
		private string friendName;

		public string Image
		{
			get { return image; }
			set
			{
				image = value;
				NotifyPropertyChanged("Image");
			}
		}

		public string NickName
		{
			get { return nickName; }
			set
			{
				nickName = value;
				NotifyPropertyChanged("NickName");
			}
		}

		public string Time
		{
			get;
			set;
		}

		public string Text
		{
			get { return text; }
			set
			{
				text = value;
				NotifyPropertyChanged("Text");
			}
		}

		public string RepostText
		{
			get { return repostText; }
			set
			{
				repostText = value;
				NotifyPropertyChanged("RepostText");
			}
		}

		public string RepostName
		{
			get
			{
				//return repostName + ":";
				return repostName;
            }
			set
			{
				repostName = value;
				NotifyPropertyChanged("RepostName");
			}
		}

		public string Source
		{
			get { return source; }
			set
			{
				source = value;
				NotifyPropertyChanged("Source");
			}
		}
        public string Picture
        {
            get { return picture; }
            set
            {
                image = value;
                NotifyPropertyChanged("Picture");
            }
        }

		public string FriendName
		{
			get { return friendName; }
			set
			{
				friendName = value;
				NotifyPropertyChanged("FriendName");
			}
		}
    }
}
