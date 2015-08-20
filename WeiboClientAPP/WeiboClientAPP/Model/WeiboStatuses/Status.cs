using System.Collections.ObjectModel;

namespace WeiBoClient.Model.WeiboStatuses
{
    public class Status : BaseStatus
    {
        private RetweetedStatus retweeted_status;
        private string rid;
        private User user;
        private Annotations annotations;

        public Status() : base()
        {
            user = new User();
            retweeted_status = new RetweetedStatus();
            annotations = new Annotations();
        }

        public Annotations Annotations
        {
            get
            {
                return this.annotations;
            }
            set
            {
                this.annotations = value;
                NotifyPropertyChanged("Annotations");
            }
        }

        public RetweetedStatus RetweetedStatus
        {
            get
            {
                return this.retweeted_status;
            }
            set
            {
                this.retweeted_status = value;
                NotifyPropertyChanged("RetweetedStatus");
            }
        }

        public string Rid
        {
            get
            {
                return this.rid;
            }
            set
            {
                this.rid = value;
                NotifyPropertyChanged("Rid");
            }
        }
        public User User
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