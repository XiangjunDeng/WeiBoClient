namespace WeiBoClient.Model.WeiboStatuses
{
    public class User : BaseModel
    {
        private long id;
        private string idstr;
        private int _class;
        private string screen_name;
        private string name;
        private string province;
        private string city;
        private string location;
        private string description;
        private string url;
        private string profile_image_url;
        private string profile_url;
        private string domain;
        private string weihao;
        private string gender;
        private int followers_count;
        private int friends_count;
        private int pagefriends_count;
        private int statuses_count;
        private int favourites_count;
        private string created_at;
        private bool following;
        private bool allow_all_act_msg;
        private bool geo_enabled;
        private bool verified;
        private int verified_type;
        private string remark;
        private int ptype;
        private bool allow_all_comment;
        private string avatar_large;
        private string avatar_hd;
        private string verified_reason;
        private string verified_trade;
        private string verified_reason_url;
        private string verified_source;
        private string verified_source_url;
        private int verified_state;
        private int verified_level;
        private string verified_reason_modified;
        private string verified_contact_name;
        private string verified_contact_email;
        private string verified_contact_mobile;
        private bool follow_me;
        private int online_status;
        private int bi_followers_count;
        private string lang;
        private int star;
        private int mbtype;
        private int mbrank;
        private int block_word;
        private int block_app;
        private int credit_score;
        private int user_ability;
        private int urank;





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
        public int Class
        {
            get
            {
                return this._class;
            }
            set
            {
                this._class = value;
                NotifyPropertyChanged("Class");
            }
        }
        public string ScreenName
        {
            get
            {
                return this.screen_name;
            }
            set
            {
                this.screen_name = value;
                NotifyPropertyChanged("ScreenName");
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public string Province
        {
            get
            {
                return this.province;
            }
            set
            {
                this.province = value;
                NotifyPropertyChanged("Province");
            }
        }
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
                NotifyPropertyChanged("City");
            }
        }
        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
                NotifyPropertyChanged("Location");
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                NotifyPropertyChanged("Description");
            }
        }
        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                NotifyPropertyChanged("Url");
            }
        }

        public string ProfileImageUrl
        {
            get
            {
                return this.profile_image_url;
            }
            set
            {
                this.profile_image_url = value;
                NotifyPropertyChanged("ProfileImageUrl");
            }
        }

        public string ProfileUrl
        {
            get
            {
                return this.profile_url;
            }
            set
            {
                this.profile_url = value;
                NotifyPropertyChanged("ProfileUrl");
            }
        }
        public string Domain
        {
            get
            {
                return this.domain;
            }
            set
            {
                this.domain = value;
                NotifyPropertyChanged("Domain");
            }
        }
        public string Weihao
        {
            get
            {
                return this.weihao;
            }
            set
            {
                this.weihao = value;
                NotifyPropertyChanged("Weihao");
            }
        }
        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
                NotifyPropertyChanged("Gender");
            }
        }
        public int FollowersCount
        {
            get
            {
                return this.followers_count;
            }
            set
            {
                this.followers_count = value;
                NotifyPropertyChanged("FollowersCount");
            }
        }
        public int FriendsCount
        {
            get
            {
                return this.friends_count;
            }
            set
            {
                this.friends_count = value;
                NotifyPropertyChanged("FriendsCount");
            }
        }

        public int PagefriendsCount
        {
            get
            {
                return this.pagefriends_count;
            }
            set
            {
                this.pagefriends_count = value;
                NotifyPropertyChanged("PagefriendsCount");
            }
        }
        public int StatusesCount
        {
            get
            {
                return this.statuses_count;
            }
            set
            {
                this.statuses_count = value;
                NotifyPropertyChanged("StatusesCount");
            }
        }
        public int FavouritesCount
        {
            get
            {
                return this.favourites_count;
            }
            set
            {
                this.favourites_count = value;
                NotifyPropertyChanged("FavouritesCount");
            }
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


        public bool Following
        {
            get
            {
                return this.following;
            }
            set
            {
                this.following = value;
                NotifyPropertyChanged("Following");
            }
        }
        public bool AllowAllActMsg
        {
            get
            {
                return this.allow_all_act_msg;
            }
            set
            {
                this.allow_all_act_msg = value;
                NotifyPropertyChanged("AllowAllActMsg");
            }
        }
        public bool GeoEnabled
        {
            get
            {
                return this.geo_enabled;
            }
            set
            {
                this.geo_enabled = value;
                NotifyPropertyChanged("GeoEnabled");
            }
        }
        public bool Verified
        {
            get
            {
                return this.verified;
            }
            set
            {
                this.verified = value;
                NotifyPropertyChanged("Verified");
            }
        }
        public int VerifiedType
        {
            get
            {
                return this.verified_type;
            }
            set
            {
                this.verified_type = value;
                NotifyPropertyChanged("VerifiedType");
            }
        }
        public string Remark
        {
            get
            {
                return this.remark;
            }
            set
            {
                this.remark = value;
                NotifyPropertyChanged("Remark");
            }
        }
        public int Ptype
        {
            get
            {
                return this.ptype;
            }
            set
            {
                this.ptype = value;
                NotifyPropertyChanged("Ptype");
            }
        }
        public bool AllowAllComment
        {
            get
            {
                return this.allow_all_comment;
            }
            set
            {
                this.allow_all_comment = value;
                NotifyPropertyChanged("AllowAllComment");
            }
        }
        public string AvatarLarge
        {
            get
            {
                return this.avatar_large;
            }
            set
            {
                this.avatar_large = value;
                NotifyPropertyChanged("AvatarLarge");
            }
        }
        public string AvatarHd
        {
            get
            {
                return this.avatar_hd;
            }
            set
            {
                this.avatar_hd = value;
                NotifyPropertyChanged("AvatarHd");
            }
        }
        public string VerifiedReason
        {
            get
            {
                return this.verified_reason;
            }
            set
            {
                this.verified_reason = value;
                NotifyPropertyChanged("VerifiedReason");
            }
        }
        public string VerifiedTrade
        {
            get
            {
                return this.verified_trade;
            }
            set
            {
                this.verified_trade = value;
                NotifyPropertyChanged("VerifiedTrade");
            }
        }
        public string VerifiedReasonUrl
        {
            get
            {
                return this.verified_reason_url;
            }
            set
            {
                this.verified_reason_url = value;
                NotifyPropertyChanged("VerifiedReasonUrl");
            }
        }
        public string VerifiedSource
        {
            get
            {
                return this.verified_source;
            }
            set
            {
                this.verified_source = value;
                NotifyPropertyChanged("VerifiedSource");
            }
        }
        public string VerifiedSourceUrl
        {
            get
            {
                return this.verified_source_url;
            }
            set
            {
                this.verified_source_url = value;
                NotifyPropertyChanged("VerifiedSourceUrl");
            }
        }
        public int VerifiedState
        {
            get
            {
                return this.verified_state;
            }
            set
            {
                this.verified_state = value;
                NotifyPropertyChanged("VerifiedState");
            }
        }
        public int VerifiedLevel
        {
            get
            {
                return this.verified_level;
            }
            set
            {
                this.verified_level = value;
                NotifyPropertyChanged("VerifiedLevel");
            }
        }
        public string VerifiedReasonModified
        {
            get
            {
                return this.verified_reason_modified;
            }
            set
            {
                this.verified_reason_modified = value;
                NotifyPropertyChanged("VerifiedReasonModified");
            }
        }
        public string VerifiedContactName
        {
            get
            {
                return this.verified_contact_name;
            }
            set
            {
                this.verified_contact_name = value;
                NotifyPropertyChanged("VerifiedContactName");
            }
        }
        public string VerifiedContactEmail
        {
            get
            {
                return this.verified_contact_email;
            }
            set
            {
                this.verified_contact_email = value;
                NotifyPropertyChanged("VerifiedContactEmail");
            }
        }
        public string VerifiedContactMobile
        {
            get
            {
                return this.verified_contact_mobile;
            }
            set
            {
                this.verified_contact_mobile = value;
                NotifyPropertyChanged("VerifiedContactMobile");
            }
        }
        public bool FollowMe
        {
            get
            {
                return this.follow_me;
            }
            set
            {
                this.follow_me = value;
                NotifyPropertyChanged("FollowMe");
            }
        }
        public int OnlineStatus
        {
            get
            {
                return this.online_status;
            }
            set
            {
                this.online_status = value;
                NotifyPropertyChanged("OnlineStatus");
            }
        }
        public int BiFollowersCount
        {
            get
            {
                return this.bi_followers_count;
            }
            set
            {
                this.bi_followers_count = value;
                NotifyPropertyChanged("BiFollowersCount");
            }
        }
        public string Lang
        {
            get
            {
                return this.lang;
            }
            set
            {
                this.lang = value;
                NotifyPropertyChanged("Lang");
            }
        }
        public int Star
        {
            get
            {
                return this.star;
            }
            set
            {
                this.star = value;
                NotifyPropertyChanged("Star");
            }
        }
        public int Mbtype
        {
            get
            {
                return this.mbtype;
            }
            set
            {
                this.mbtype = value;
                NotifyPropertyChanged("Mbtype");
            }
        }
        public int Mbrank
        {
            get
            {
                return this.mbrank;
            }
            set
            {
                this.mbrank = value;
                NotifyPropertyChanged("Mbrank");
            }
        }
        public int BlockWord
        {
            get
            {
                return this.block_word;
            }
            set
            {
                this.block_word = value;
                NotifyPropertyChanged("BlockWord");
            }
        }
        public int BlockApp
        {
            get
            {
                return this.block_app;
            }
            set
            {
                this.block_app = value;
                NotifyPropertyChanged("BlockApp");
            }
        }
        public int CreditScore
        {
            get
            {
                return this.credit_score;
            }
            set
            {
                this.credit_score = value;
                NotifyPropertyChanged("CreditScore");
            }
        }
        public int UserAbility
        {
            get
            {
                return this.user_ability;
            }
            set
            {
                this.user_ability = value;
                NotifyPropertyChanged("UserAbility");
            }
        }
        public int Urank
        {
            get
            {
                return this.urank;
            }
            set
            {
                this.urank = value;
                NotifyPropertyChanged("Urank");
            }
        }
    }
}



