using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiBoClient.Model.WeiboStatuses
{
    public class BaseStatus : BaseModel
    {
        private string created_at;
        private long id;
        private string mid;
        private string idstr;
        private string text;
        private int source_allowclick;
        private int source_type;
        private string source;
        private bool favorited;
        private bool truncated;
        private string in_reply_to_status_id;
        private string in_reply_to_user_id;
        private string in_reply_to_screen_name;
        private ObservableCollection<PicUrl> pic_urls;//
        private string geo;
        private int reposts_count;
        private int comments_count;
        private int attitudes_count;
        private int mlevel;
        private Visible visible;//
        private ObservableCollection<string> darwin_tags;//
       

        public BaseStatus()
        {
            pic_urls = new ObservableCollection<PicUrl>();
            visible = new Visible();
            darwin_tags = new ObservableCollection<string>();
        }

        public string CreatedAt
        {
            get
            {
                return this.created_at;
            }
            set
            {
                this.created_at = value;
                NotifyPropertyChanged("CreatedAt");
            }
        }

        public long Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string Mid
        {
            get
            {
                return this.mid;
            }
            set
            {
                this.mid = value;
                NotifyPropertyChanged("Mid");
            }
        }

        public string Idstr
        {
            get
            {
                return this.idstr;
            }
            set
            {
                this.idstr = value;
                NotifyPropertyChanged("Idstr");
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
                NotifyPropertyChanged("Text");
            }
        }

        public int SourceAllowclick
        {
            get
            {
                return this.source_allowclick;
            }
            set
            {
                this.source_allowclick = value;
                NotifyPropertyChanged("SourceAllowclick");
            }
        }

        public int SourceType
        {
            get
            {
                return this.source_type;
            }
            set
            {
                this.source_type = value;
                NotifyPropertyChanged("SourceType");
            }
        }

        public string Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
                NotifyPropertyChanged("Source");
            }
        }

        public bool Favorited
        {
            get
            {
                return this.favorited;
            }
            set
            {
                this.favorited = value;
                NotifyPropertyChanged("Favorited");
            }
        }

        public bool Truncated
        {
            get
            {
                return this.truncated;
            }
            set
            {
                this.truncated = value;
                NotifyPropertyChanged("Truncated");
            }
        }

        public string InReplyToStatusId
        {
            get
            {
                return this.in_reply_to_status_id;
            }
            set
            {
                this.in_reply_to_status_id = value;
                NotifyPropertyChanged("InReplyToStatusId");
            }
        }

        public string InReplyToUserId
        {
            get
            {
                return this.in_reply_to_user_id;
            }
            set
            {
                this.in_reply_to_user_id = value;
                NotifyPropertyChanged("InReplyToUserId");
            }
        }

        public string InReplyToScreenName
        {
            get
            {
                return this.in_reply_to_screen_name;
            }
            set
            {
                this.in_reply_to_screen_name = value;
                NotifyPropertyChanged("InReplyToScreenName");
            }
        }


        public ObservableCollection<PicUrl> PicUrls
        {
            get
            {
                return this.pic_urls;
            }
            set
            {
                this.pic_urls = value;
                NotifyPropertyChanged("PicUrls");
            }
        }

        public string Geo
        {
            get
            {
                return this.geo;
            }
            set
            {
                this.geo = value;
                NotifyPropertyChanged("Geo");
            }
        }



        public int RepostsCount
        {
            get
            {
                return this.reposts_count;
            }
            set
            {
                this.reposts_count = value;
                NotifyPropertyChanged("RepostsCount");
            }
        }

        public int CommentsCount
        {
            get
            {
                return this.comments_count;
            }
            set
            {
                this.comments_count = value;
                NotifyPropertyChanged("CommentsCount");
            }
        }

        public int AttitudesCount
        {
            get
            {
                return this.attitudes_count;
            }
            set
            {
                this.attitudes_count = value;
                NotifyPropertyChanged("AttitudesCount");
            }
        }

        public int Mlevel
        {
            get
            {
                return this.mlevel;
            }
            set
            {
                this.mlevel = value;
                NotifyPropertyChanged("Mlevel");
            }
        }

        public Visible Visible
        {
            get
            {
                return this.visible;
            }
            set
            {
                this.visible = value;
                NotifyPropertyChanged("Visible");
            }
        }


        public ObservableCollection<string> DarwinTags
        {
            get
            {
                return this.darwin_tags;
            }
            set
            {
                this.darwin_tags = value;
                NotifyPropertyChanged("DarwinTags");
            }
        }
    }
}
