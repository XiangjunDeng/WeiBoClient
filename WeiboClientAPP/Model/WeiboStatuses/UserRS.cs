using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiBoClient.Model.WeiboStatuses
{
    public class UserRS : User
    {
        private string cover_image_phone;
        public string CoverImagePhone
        {
            get
            {
                return this.cover_image_phone;
            }
            set
            {
                this.cover_image_phone = value;
                NotifyPropertyChanged("CoverImagePhone");
            }
        }
    }
}
