using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoClient.Model;

namespace WeiboClientAPP.Model.WeiboStatuses.UtilityModel
{
    /// <summary>
    /// User's interested friend
    /// </summary>
    class IntrFriend : BaseModel
    {
        private long uid;
        private string nickname;
        private string remark;


        public long Uid
        {
            get
            {
                return this.uid;
            }
            set
            {
                this.uid = value;
                NotifyPropertyChanged("Uid");
            }
        }
        public string Nickname
        {
            get
            {
                return this.nickname;
            }
            set
            {
                this.nickname = value;
                NotifyPropertyChanged("Nickname");
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

    } 
}
