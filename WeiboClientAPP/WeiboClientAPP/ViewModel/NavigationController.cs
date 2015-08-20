using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiboClient.View;

namespace WeiboClientAPP.ViewModel
{
	public class NavigationController
	{
		private INavigationBase currrentVM;

		private static WeiBoDetail weiboDetail;

		public NavigationController()
		{ }

		public NavigationController(WeiBoDetail weiboDetail)
		{
			
		}
	}
}
