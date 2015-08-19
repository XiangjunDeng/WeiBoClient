using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace WeiBoClient.ViewModel.EventArgsInViewModel
{
    public class ExCommandParameter
    {
        /// <summary>
        /// Event Sender
        /// </summary>
        public DependencyObject Sender { get; set; }
        /// <summary>
        /// Event Args
        /// </summary>
        public EventArgs EventArgs { get; set; }
        /// <summary>
        /// Event Parameter
        /// </summary>
        public object Parameter { get; set; }
    }
}
