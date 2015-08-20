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
using WeiboClientAPP.Model.WeiboStatuses.UtilityModel;
using WeiboSDKForWinRT;

namespace WeiBoClient.ViewModel
{
	public class FollowingListViewModel : BaseViewModel
	{
		public ObservableCollection<WeiBoItemTestModel> friendList;
		public ObservableCollection<WeiBoItemTestModel> FriendList
		{
			get
			{
				return friendList;
			}
			set
			{
				this.friendList = value;
				NotifyPropertyChanged("FriendList");
			}
		}
		private async Task<string> AtFriends()
		{
			var engine = new SdkNetEngine();
			ISdkCmdBase cmdBase = new CmdAtUsers
			{
				Count = "10",
				Type = "0",
				Range = "2",
				Keyword = "a"
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

		public ICommand AtFriendCommand
		{
			get
			{
				string result = String.Empty;

				Task.WaitAll(Task.Run(async delegate { result = await AtFriends(); }));

				ObservableCollection<WeiBoItemTestModel> friends = new ObservableCollection<WeiBoItemTestModel>();

				AcquireIntrFriend atFriend = new AcquireIntrFriend(result);


				for (int i = 0; i < atFriend.IntrFriendList.Count; i++)
				{
					friends.Add(
						new WeiBoItemTestModel
						{
							FriendName = atFriend.IntrFriendList[i].Nickname
						});
				}
				FriendList = friends;

				return new DelegateCommand<string>
				(
					(p) =>
					{

					},
					(p) =>
					{
						return true;
					});
			}
		}
	}
}
