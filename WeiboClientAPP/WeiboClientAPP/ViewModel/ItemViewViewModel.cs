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
using WeiBoClient.ViewModel;
using Windows.UI.Xaml.Controls;
using WeiboClient.Model;
using WeiBoClient.Model.WeiboStatuses;
using Windows.UI.Xaml.Input;
using WeiboClient.ViewModel;

namespace WeiBoClient.ViewModel
{
	public class ItemViewViewModel : BaseViewModel
	{
		//private ObservableCollection<WeiBoItemViewModel> weiboList;
		private string count;
		private string weibotext;

		private string userImage;
		private string nickName;
		private string time;
		private string content;

		ObservableCollection<WeiBoItemTestModel> weiboList1 = new ObservableCollection<WeiBoItemTestModel>();

		public string Content
		{
			get { return this.content; }
			set
			{
				this.content = value;
			}
		}

		public string UserImage
		{
			get { return this.userImage; }
			set
			{
				this.userImage = value;
				NotifyPropertyChanged("UserImage");
			}
		}

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

		//public ObservableCollection<WeiboItem> WeiboList
		//{
		//    get { return this.weiboList; }
		//    set { this.weiboList = value; NotifyPropertyChanged("WeiboList"); }
		//}

		//public ObservableCollection<WeiBoItemViewModel> WeiboList
		//{
		//	get { return this.weiboList; }
		//	set { this.weiboList = value; NotifyPropertyChanged("WeiboList"); }
		//}

		//get Friends_Timeline list

		//public static ObservableCollection<WeiBoItemTestModel> CreateItems()
		//{
		//	var weiboList = new ObservableCollection<WeiBoItemTestModel>();

		//	for (int i = 0; i < 10; i++)
		//	{
		//		weiboList.Add(new WeiBoItemTestModel
		//		{
		//			Image = "Image " + i.ToString(),
		//			NickName = "NickName " + i.ToString(),
		//			Time = DateTime.Now.ToString()
		//		});
		//	}

		//	return weiboList;
		//}
		private ObservableCollection<WeiBoItemTestModel> weiboList;
		public ObservableCollection<WeiBoItemTestModel> ListItems
		{
			get
			{

				//for (int i = 0; i < 10; i++)
				//{
				//	weiboList.Add(new WeiBoItemTestModel
				//	{
				//		Image = "Image " + i.ToString(),
				//		NickName = "NickName " + i.ToString(),
				//		Time = DateTime.Now.ToString()
				//	});
				//}

				//return weiboList;
				//ObservableCollection<Model.WeiboStatuses.WeiboItem> weiboList = new ObservableCollection<Model.WeiboStatuses.WeiboItem>();

				return weiboList;
			}
			set
			{
				this.weiboList = value;
				NotifyPropertyChanged("ListItems");
			}
		}

		public ICommand TimeLine_Command
		{
			get
			{
				string result = String.Empty;

				Task.WaitAll(Task.Run(async delegate { result = await Timeline(); }));

				if (!string.IsNullOrEmpty(result))
				{
					Model.WeiboStatuses.WeiboItem mWeiboItems = new Model.WeiboStatuses.WeiboItem(result);
					//string a = mWeiboItems.Statuses[1].User.ToString();

					for (int i = 0; i < mWeiboItems.Statuses.Count; i++)
					{
						object weiboitem = mWeiboItems.Statuses[i];

						weiboList1.Add(new WeiBoItemTestModel
						{
							Image = mWeiboItems.Statuses[i].User.ProfileImageUrl,
							NickName = mWeiboItems.Statuses[i].User.Name,
							Text = mWeiboItems.Statuses[i].Text,
							RepostText = mWeiboItems.Statuses[i].RetweetedStatus.Text,
							RepostName = mWeiboItems.Statuses[i].RetweetedStatus.User.Name,
							Time = mWeiboItems.Statuses[i].CreatedAt,
							//Source = mWeiboItems.Statuses[i].Source
						});
					}
					ListItems = weiboList1;
				}

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
		#region private method
		private async Task<string> Timeline()
		{
			var engine = new SdkNetEngine();
			ISdkCmdBase cmdBase = new CmdTimelines()
			{
				Count = "10",
				Page = "1"
			};
			var result = await engine.RequestCmd(SdkRequestType.FRIENDS_TIMELINE, cmdBase);
			if (result.errCode == SdkErrCode.SUCCESS)
			{
				return result.content;

			}
			else
			{
				return string.Empty;
			}
		}

		//private async Task<string> GetWeiBoItem()
		//{
		//	var engine = new SdkNetEngine();
		//	ISdkCmdBase cmdBase = new CmdShortenUrl()
		//	{
		//		OriginalUrl = "a"
		//	};
		//	var result = await engine.RequestCmd(SdkRequestType.SHORTEN_URL, cmdBase);
		//	if (result.errCode == SdkErrCode.SUCCESS)
		//	{
		//		return result.content;

		//	}
		//	else
		//	{
		//		return string.Empty;
		//	}
		//}

		public ICommand ItemDetailCommand
		{
			get
			{

				//foreach (var weiboItem in mWeiboItems.Statuses)
				//{
				//	WeiBoItem = weiboItem;
				//}

				return new DelegateCommand<TappedRoutedEventArgs>
				(
					(p) =>
					{
						//string a = string.Empty;

						//WeiBoItemTestModel itemDetail = new WeiBoItemTestModel()
						//{
						//	NickName = this.WeiBoItem.NickName,
						//	Image = this.WeiBoItem.Image,
						//};

						//WeiBoItem = itemDetail;
						WeiBoDetailViewModel detail = new WeiBoDetailViewModel();
						detail.WeiBoItem = this.WeiBoItem;

					},
					(p) =>
					{
						return true;
					}
				);
			}
		}

		
		#endregion
		public ICommand LoginCommand
		{
			get
			{
				Authorize();

				//string result = String.Empty;

				return new DelegateCommand<string>
				(
					(p) =>
					{
						if (IsLoginSuccess)
						{
							//LoginStatusText = LoginStatus.LoginSuccess;

						}
						else
						{
							//LoginStatusText = LoginStatus.LoginFailed;
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

		public ICommand GetTimeLine_Command
		{
			get
			{
				return new DelegateCommand<TappedRoutedEventArgs>
				(
					(p) =>
					{
						string result = String.Empty;

						Task.WaitAll(Task.Run(async delegate { result = await Timeline(); }));

						if (!string.IsNullOrEmpty(result))
						{
							Model.WeiboStatuses.WeiboItem mWeiboItems = new Model.WeiboStatuses.WeiboItem(result);
							//string a = mWeiboItems.Statuses[1].User.ToString();

							for (int i = 0; i < mWeiboItems.Statuses.Count; i++)
							{
								object weiboitem = mWeiboItems.Statuses[i];

								weiboList1.Add(new WeiBoItemTestModel
								{
									Image = mWeiboItems.Statuses[i].User.ProfileImageUrl,
									NickName = mWeiboItems.Statuses[i].User.Name,
									Text = mWeiboItems.Statuses[i].Text,
									RepostText = mWeiboItems.Statuses[i].RetweetedStatus.Text,
									RepostName = mWeiboItems.Statuses[i].RetweetedStatus.User.Name,
									Time = mWeiboItems.Statuses[i].CreatedAt,
									//Source = mWeiboItems.Statuses[i].Source
								});
							}
							ListItems = weiboList1;
							//return weiboList1;
						}

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

		private Grid itemContent;

		public Grid ItemContent
		{
			get
			{
				return this.itemContent;
			}
			set
			{
				this.itemContent = value;
				NotifyPropertyChanged("ItemContent");
			}
		}

		WeiBoItemTestModel weiBoItem;
		public WeiBoItemTestModel WeiBoItem
		{
			get
			{
				return this.weiBoItem;
			}
			set
			{
				if(value != this.weiBoItem)
				{ 
					this.weiBoItem = value;
					NotifyPropertyChanged("WeiBoItem");
				}
			}
		}

		WeiBoDetailViewModel weiBoDetail;

		public WeiBoDetailViewModel WeiBoDetail
		{
			get
			{
				return this.weiBoDetail;
			}

			private set
			{
				this.weiBoDetail = value;
				NotifyPropertyChanged("WeiBoDetail");
			}
		}

        private async Task GetItemAsync()
        {

        }
    }
}
