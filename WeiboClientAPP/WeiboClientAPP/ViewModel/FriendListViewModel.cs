using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeiBoClient.ViewModel;
using WeiBoClient.ViewModel.EventArgsInViewModel;
using WeiboSDKForWinRT;

namespace WeiboClient.ViewModel
{
	public class FriendListViewModel : BaseViewModel
	{
		private async Task<string> GetFriends()
		{
			var engine = new SdkNetEngine();
			ISdkCmdBase cmdBase = new CmdAtUsers()
			{
				Count = "10",
				Type = "0",
				Keyword = "a",
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

		public ICommand GetFriendListCommand
		{
			get
			{
				string result = String.Empty;
				Task.WaitAll(Task.Run(async delegate { result = await GetFriends(); }));

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
	}
}
