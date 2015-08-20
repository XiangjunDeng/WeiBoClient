using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiboClient.ViewModel;

namespace WeiboClientAPP.ViewModel
{
	public class ViewModelLocator
	{
		//public ViewModelLocator()
		//{
		//	ServiceLocator.SetLocatorProvider(()=>Simpleloc.Default);
		//}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMemberAsStatic", Justification = "This non- static member is nedded fo data binding purposes.")]
		public WeiBoDetailViewModel DetailPage
		{
			get
			{
				return new WeiBoDetailViewModel();
			}
		}

	}
}
