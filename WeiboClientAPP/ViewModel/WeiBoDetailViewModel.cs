using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeiboClient.Model;
using WeiBoClient.ViewModel;
using WeiBoClient.ViewModel.EventArgsInViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace WeiboClient.ViewModel
{
	public class WeiBoDetailViewModel : BaseViewModel
	{
		WeiBoItemTestModel weiBoItem;
		public WeiBoItemTestModel WeiBoItem
		{
			get
			{
				return this.weiBoItem;
			}
			set
			{
				if (value != this.weiBoItem)
				{
					this.weiBoItem = value;
					NotifyPropertyChanged("WeiBoItem");
				}
			}
		}

		private Grid mainContent;

		public Grid MainContent
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

		//public ICommand ItemDetailCommand
		//{
		//	get
		//	{

		//		//foreach (var weiboItem in mWeiboItems.Statuses)
		//		//{
		//		//	WeiBoItem = weiboItem;
		//		//}
		//		ItemViewViewModel model = new ItemViewViewModel();

		//		return new DelegateCommand<TappedRoutedEventArgs>
		//		(
		//			(p) =>
		//			{
		//				model = this.WeiBoItem;
		//				NickName = model.NickName;
		//				UserImage = model.UserImage;
		//			},
		//			(p) =>
		//			{
		//				return true;
		//			}
		//		);
		//	}
		//}

		public string NickName { get; private set; }
		public string UserImage { get; private set; }
	}
}
