using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeiBoClient.Consts;
using WeiBoClient.ViewModel;
using WeiBoClient.ViewModel.EventArgsInViewModel;
using Windows.UI.Xaml.Controls;

namespace WeiBoClient.ViewModel
{
	public class WeiBoItemModel : BaseViewModel
	{
		private string userImage;
		private string nickName;
		private string time;
		private string content;

		//public string Content
		//{
		//	get { return this.content; }
		//	set
		//	{
		//		this.content = value;
		//	}
		//}

		//public string UserImage
		//{
		//	get { return this.userImage; }
		//	set
		//	{
		//		this.userImage = value;
		//		NotifyPropertyChanged("UserImage");
		//	}
		//}

		public string NickName
		{
			get { return this.nickName; }
			set
			{
				this.nickName = value;
				NotifyPropertyChanged("NickName");
			}
		}

		//public string Time
		//{
		//	get
		//	{
		//		return this.time;
		//	}

		//	set
		//	{
		//		this.time = value;
		//		NotifyPropertyChanged("Time");
		//	}
		//}

		//private string loginStatusText;
		///// <summary>
		///// Login Status
		///// </summary>
		//public string LoginStatusText
		//{
		//	get
		//	{
		//		return this.loginStatusText;
		//	}
		//	set
		//	{
		//		this.loginStatusText = value;
		//		NotifyPropertyChanged("LoginStatusText");
		//	}
		//}

		//private StackPanel mainContent;

		//public StackPanel MainContent
		//{
		//	get
		//	{
		//		return this.mainContent;
		//	}
		//	set
		//	{
		//		this.mainContent = value;
		//		NotifyPropertyChanged("MainContent");
		//	}
		//}

		//public ICommand LoginCommand
		//{
		//	get
		//	{
		//		Authorize();

		//		return new DelegateCommand<string>
		//		(
		//			(p) =>
		//			{

		//				if (IsLoginSuccess)
		//				{
		//					LoginStatusText = LoginStatus.LoginSuccess;

		//				}
		//				else
		//				{
		//					LoginStatusText = LoginStatus.LoginFailed;
		//					//Frame.Navigate(typeof(UCSample));
		//				}

		//			},
		//			(p) =>
		//			{
		//				return true;
		//			}
		//		);

		//	}
		//}
	}
}
