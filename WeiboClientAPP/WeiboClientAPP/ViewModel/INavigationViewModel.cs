using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace WeiboClientAPP.ViewModel
{
	public interface INavigationBase
	{ }
	public interface INavigationViewModel : INavigationBase
	{
		void OnNavigatedTo(NavigationEventArgs e);
		void OnNavigatedFrom(NavigationEventArgs e);
	}
}
