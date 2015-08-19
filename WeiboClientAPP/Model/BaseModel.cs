using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiBoClient.Model
{
    public class BaseModel: INotifyPropertyChanged
    {
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string RedirectUri { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
