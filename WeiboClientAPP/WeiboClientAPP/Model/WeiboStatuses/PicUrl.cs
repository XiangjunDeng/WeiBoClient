using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiBoClient.Model.WeiboStatuses
{
    public class PicUrl : BaseModel
    {
        private string thumbnail_pic;
        public string ThumbnailPic
        {
            get
            {
                return this.thumbnail_pic;
            }
            set
            {
                this.thumbnail_pic = value;
                NotifyPropertyChanged("ThumbnailPic");
            }
        }
    }
}
