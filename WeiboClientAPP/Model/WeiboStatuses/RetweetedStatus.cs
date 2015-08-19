using System.Collections.ObjectModel;

namespace WeiBoClient.Model.WeiboStatuses
{
    public class RetweetedStatus : BaseStatus
    {

        private string thumbnail_pic;
        private string bmiddle_pic;
        private string original_pic;
        private UserRS user;
        
        public RetweetedStatus() : base()
        {
            user = new UserRS();
        }

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
        public string BmiddlePic
        {
            get
            {
                return this.bmiddle_pic;
            }
            set
            {
                this.bmiddle_pic = value;
                NotifyPropertyChanged("BmiddlePic");
            }
        }
        public string OriginalPic
        {
            get
            {
                return this.original_pic;
            }
            set
            {
                this.original_pic = value;
                NotifyPropertyChanged("OriginalPic");
            }
        }
        public UserRS User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
                NotifyPropertyChanged("User");
            }
        }

    }
}