using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeiBoClient.Utility;

namespace WeiBoClient.Model.WeiboStatuses
{
    /// <summary>
    /// V1.0    Add Weibo item Classes     7/21/2015       Crystal
    /// V1.1    Add methods for Models     7/29/2015       Crystal
    /// V1.2    Add methods to get 'retweeted_status' node's value   7/30/2015    Crystal
    /// V1.3    Add methods of getting node value of 'RetweetedStatus'.   8/4/2015    Crystal
    /// V1.4    Add methods to determine whether 'XElement' is null     8/5/2015    Crystal
    /// V1.5    Exception handle in Model to guarantee the app not blocked by 'ArgumentNullException' or 'FormatException'      8/6/2015    Crystal
    /// 
    /// You can refer to 'WeiboItemFile.xml' or 'WeiboItemJson.txt' if you are not clear about the classes
    /// under 'WeiBoClient.Model.WeiboStatuses'
    /// </summary>

    public class WeiboItem : BaseModel
    {
        private ObservableCollection<Status> statuses;
        private ObservableCollection<string> advertises;
        private ObservableCollection<string> ad;
        private bool hasvisible;
        private long previous_cursor;
        private long next_cursor;
        private int total_number;
        private int interval;
        private int uve_blank;
        private long since_id;
        private long max_id;
        private int has_unread;


        public WeiboItem(string jsonResult)
        {
            if (jsonResult == string.Empty)
            {
                //'jsonResult' is empty, return to stop execute this function
                return;
            }
            else
            {
                statuses = new ObservableCollection<Status>();

                #region Initialize members of 'WeiboItem'

                //Generate XDocument with a root name "RootNode"
                IEnumerable<XElement> rootWeiboItemNode = GetRootNodeList(jsonResult, "RootNode");

                //TEST : rootWeiboItemNode.ElementAt(0).Descendants("statuses").ElementAt(0); ==>
                //<statuses>  < created_at > Tue Jul 28 13:30:34 + 0800 2015 </ created_at >...

                if (IsEleListNotNull(rootWeiboItemNode))
                {
                    //Get 'statuses' node value in WeiboItem
                    GetRootStatuses(rootWeiboItemNode.ElementAt(0).Descendants("statuses"));

                    //Get 'advertises' node value in WeiboItem
                    XElement advertisesNode = rootWeiboItemNode.ElementAt(0).Element("advertises");
                    advertises = new ObservableCollection<string>();
                    GetListNodeValue(advertises, advertisesNode);


                    //Get 'ad' node value in WeiboItem
                    XElement adNode = rootWeiboItemNode.ElementAt(0).Element("ad");
                    ad = new ObservableCollection<string>();
                    GetListNodeValue(ad, adNode);


                    //Get the value of root attribute node
                    GetAttRootNode(rootWeiboItemNode.ElementAt(0));
                }
                #endregion
            }
        }

        //*****************************************************************************************************
        //Utilities
        //*****************************************************************************************************
        
        //Determine whether 'IEnumerable<XElement>' is null
        private bool IsEleListNotNull(IEnumerable<XElement> nodeList)
        {
            if (nodeList != null && nodeList.Count() > 0)
            {
                return true;
            }
            else
                return false;
        }


        //Get element node's value 
        private string GetEleValueInStatuses(XElement xElem, string filedType, string nodeName)
        {
            string ele = string.Empty;
            if (xElem != null && xElem.Element(nodeName) != null)
            {
                ele = xElem.Element(nodeName).Value;
            }
            if (string.IsNullOrEmpty(ele))
            {
                switch (filedType)
                {
                    case "int":
                    case "long":
                        ele = "0";
                        break;
                    case "bool":
                        ele = "false";
                        break;
                }
            }
            return ele;
        }

        //Get element node's value 
        private string GetThirdLNValueInStatuses(XElement xElem, string filedType, string nodeName2, string nodeName3)
        {
            string nodeValue = string.Empty;
            if (xElem != null && xElem.Element(nodeName2) != null)
            {
                XElement node3 = xElem.Element(nodeName2).Element(nodeName3);
                if (node3 != null)
                {
                    nodeValue = node3.Value;
                }
            }
            if (string.IsNullOrEmpty(nodeValue))
            {
                switch (filedType)
                {
                    case "int":
                    case "long":
                        nodeValue = "0";
                        break;
                    case "bool":
                        nodeValue = "false";
                        break;
                }
            }
            return nodeValue;
        }

        //Get each string value of string list
        private void GetListNodeValue(ObservableCollection<string> strListNode, XElement existsListNode)
        {
            if (existsListNode != null)
            {
                //DEBUG: 'existsListNode.Descendants()'->Rignt??
                foreach (XElement str in existsListNode.Descendants())
                {
                    strListNode.Add(str.Value);
                }
            }
        }

        //*****************************************************************************************************
        //End Utilities
        //*****************************************************************************************************


        //Get the value of root attribute node
        private void GetAttRootNode(XElement xRootElement)
        {
            hasvisible = bool.Parse(GetEleValueInStatuses(xRootElement, "bool", "hasvisible"));
            previous_cursor = long.Parse(GetEleValueInStatuses(xRootElement, "long", "previous_cursor"));
            next_cursor = long.Parse(GetEleValueInStatuses(xRootElement, "long", "next_cursor"));
            total_number = int.Parse(GetEleValueInStatuses(xRootElement, "int", "total_number"));
            interval = int.Parse(GetEleValueInStatuses(xRootElement, "int", "interval"));
            uve_blank = int.Parse(GetEleValueInStatuses(xRootElement, "int", "uve_blank"));
            since_id = long.Parse(GetEleValueInStatuses(xRootElement, "long", "since_id"));
            max_id = long.Parse(GetEleValueInStatuses(xRootElement, "long", "max_id"));
            has_unread = int.Parse(GetEleValueInStatuses(xRootElement, "int", "has_unread"));
        }

        //Get 'statuses' in root node
        private void GetRootStatuses(IEnumerable<XElement> statusesNodes)
        {
            if (IsEleListNotNull(statusesNodes))
            {
                for (int i = 0; i < statusesNodes.Count(); i++)
                {
                    Status mStatus = new Status();
                    GetBaseStatusValue(mStatus, statusesNodes.ElementAt(i));
                    GetPriNdInStatus(mStatus, statusesNodes.ElementAt(i));

                    statuses.Add(mStatus);
                }
            }
        }

        //Get BaseStatus's value
        private void GetBaseStatusValue(BaseStatus mStatus, XElement statusesNode)
        {
            //DEBUG: component value in 'retweented_status', right??
            GetSimNdInBaseStatuses(mStatus, statusesNode);

            //3 composite nodes in BaseStatus : ObservableCollection<PicUrl> pic_urls;Visible visible;ObservableCollection<string> darwin_tags;            
            GetComNdInBaseStatuses(mStatus, statusesNode);
        }

        //Get the value of private elements in 'Status'
        private void GetPriNdInStatus(Status mStatus, XElement statusesNode)
        {
            //Get 'retweeted_status' node value
            //GetRetweetedStatus(mStatus.RetweetedStatus, statusesNode);
            GetRetweetedStatus(mStatus, statusesNode);

            //Get 'rid' in 'Statuses'
            mStatus.Rid = GetEleValueInStatuses(statusesNode, "string", "rid");

            //Get 'user' in 'Statuses'
            GetUserInStatuses(mStatus.User, statusesNode);

            //Get 'annotations' in 'Statuses'
            GetAnnotationsInStatuses(mStatus, statusesNode);


        }

        //Get 'annotations' node in 'Statuses'
        private void GetAnnotationsInStatuses(Status mStatus, XElement statusesNode)
        {
            mStatus.Annotations.ClientMblogid = GetThirdLNValueInStatuses(statusesNode, "string", "annotations", "client_mblogid");
            mStatus.Annotations.MapiRequest = GetThirdLNValueInStatuses(statusesNode, "string", "annotations", "mapi_request");
        }

        //Get 'retweeted_status' node value
        private void GetRetweetedStatus(Status mStatus, XElement statusesNode)
        {
            //Get public attribute of 'Stataus' in 'retweeted_status'
            XElement retweetedStatusNode = statusesNode.Element("retweeted_status");
            if (retweetedStatusNode != null)
            {
                GetBaseStatusValue(mStatus.RetweetedStatus, retweetedStatusNode);
            }

            //Get private attribute in 'retweeted_status'
            GetPriNdInRetweetedStatus(mStatus, retweetedStatusNode);
        }

        private void GetPriNdInRetweetedStatus(Status mStatus, XElement retweetedStatusNode)
        {
            //Get simple private attribute node in 'RetweetedStatus': 'thumbnail_pic', 'bmiddle_pic', 'original_pic'
            mStatus.RetweetedStatus.ThumbnailPic = GetEleValueInStatuses(retweetedStatusNode, "string", "thumbnail_pic");
            mStatus.RetweetedStatus.BmiddlePic = GetEleValueInStatuses(retweetedStatusNode, "string", "bmiddle_pic");
            mStatus.RetweetedStatus.OriginalPic = GetEleValueInStatuses(retweetedStatusNode, "string", "original_pic");

            //GetUserInRetweetedStatus(mStatus, retweetedStatusNode);
            //1. Get basic 'User' node of 'UserRS'
            GetUserInStatuses(mStatus.RetweetedStatus.User, retweetedStatusNode);
            //2. Get private node of 'UserRS'
            mStatus.RetweetedStatus.User.CoverImagePhone = GetEleValueInStatuses(retweetedStatusNode, "string", "cover_image_phone");

        }

        //Get composite nodes in BaseStatus
        private void GetComNdInBaseStatuses(BaseStatus mStatus, XElement statusesNode)
        {
            if (statusesNode != null)
            {
                //Get 'pic_urls' value in 'statuses'/'retweeted_status'
                IEnumerable<XElement> existsPicUrls = statusesNode.Elements("pic_urls");
                if (IsEleListNotNull(existsPicUrls))
                {
                    //IEnumerable<XElement> existsPicUrls = statusesNode.Element("pic_urls").Descendants("thumbnail_pic");
                    GetPicUrlsValue(mStatus, existsPicUrls);
                }

                //Get 'visible' value in 'statuses'/'retweeted_status'
                mStatus.Visible.Type = int.Parse(GetThirdLNValueInStatuses(statusesNode, "int", "visible", "type"));
                mStatus.Visible.ListId = int.Parse(GetThirdLNValueInStatuses(statusesNode, "int", "visible", "list_id"));

                //Get 'darwin_tags' in 'statuses'/'retweeted_status'
                XElement existsDarwinTags = statusesNode.Element("darwin_tags");
                GetListNodeValue(mStatus.DarwinTags, existsDarwinTags);
            }
        }

        

        private void GetPicUrlsValue(BaseStatus mStatus, IEnumerable<XElement> existsPicUrls)
        {
            for (int i = 0; i < existsPicUrls.Count(); i++)
            {
                PicUrl mPicUrl = new PicUrl();
                mPicUrl.ThumbnailPic = existsPicUrls.ElementAt(i).Value;
                mStatus.PicUrls.Add(mPicUrl);
            }
        }


        //Get the root list node
        private IEnumerable<XElement> GetRootNodeList(string jsonResult, string rootNodeName)
        {
            IEnumerable<XElement> existRootNodeList = null;
            XDocument mWeiboItem_RootNodeDoc = JsonConverterTool.GetWeibo(jsonResult, rootNodeName);
            if (mWeiboItem_RootNodeDoc != null)
            {
                existRootNodeList = mWeiboItem_RootNodeDoc.Descendants(rootNodeName);
            }
            
            return existRootNodeList;
        }


        //Get Simple node in 'statuses' node
        private void GetSimNdInBaseStatuses(BaseStatus mStatus, XElement existStatuses)
        {
            #region GetSimNdInStatuses
            mStatus.CreatedAt = GetEleValueInStatuses(existStatuses, "string", "created_at");
            mStatus.Id = long.Parse(GetEleValueInStatuses(existStatuses, "long", "id"));
            mStatus.Mid = GetEleValueInStatuses(existStatuses, "string", "mid");
            mStatus.Idstr = GetEleValueInStatuses(existStatuses, "string", "idstr");
            mStatus.Text = GetEleValueInStatuses(existStatuses, "string", "text");
            mStatus.SourceAllowclick = int.Parse(GetEleValueInStatuses(existStatuses, "int", "source_allowclick"));
            mStatus.SourceType = int.Parse(GetEleValueInStatuses(existStatuses, "int", "source_type"));
            mStatus.Source = GetEleValueInStatuses(existStatuses, "string", "source");
            mStatus.Favorited = bool.Parse(GetEleValueInStatuses(existStatuses, "bool", "favorited"));
            mStatus.Truncated = bool.Parse(GetEleValueInStatuses(existStatuses, "bool", "truncated"));
            mStatus.InReplyToStatusId = GetEleValueInStatuses(existStatuses, "string", "in_reply_to_status_id");
            mStatus.InReplyToUserId = GetEleValueInStatuses(existStatuses, "string", "in_reply_to_user_id");
            mStatus.InReplyToScreenName = GetEleValueInStatuses(existStatuses, "string", "in_reply_to_screen_name");
            mStatus.Geo = GetEleValueInStatuses(existStatuses, "string", "geo");
            mStatus.RepostsCount = int.Parse(GetEleValueInStatuses(existStatuses, "int", "reposts_count"));
            mStatus.CommentsCount = int.Parse(GetEleValueInStatuses(existStatuses, "int", "comments_count"));
            mStatus.AttitudesCount = int.Parse(GetEleValueInStatuses(existStatuses, "int", "attitudes_count"));
            mStatus.Mlevel = int.Parse(GetEleValueInStatuses(existStatuses, "int", "mlevel"));
            //mStatus.Rid = GetEleInStatuses(existStatuses, i, "rid");//Old method
            #endregion
        }



        //Get 'user' node in 'statuses' node
        private void GetUserInStatuses(User mUser, XElement existStatuses)
        {
            #region GetUserInStatuses
            //mStatus.User.Id = int.Parse(existStatuses.Element("user").Element("id").Value);//Old method
            mUser.Id = long.Parse(GetThirdLNValueInStatuses(existStatuses, "long", "user", "id"));
            mUser.Idstr = GetThirdLNValueInStatuses(existStatuses, "string", "user", "idstr");
            mUser.Class = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "class"));
            mUser.ScreenName = GetThirdLNValueInStatuses(existStatuses, "string", "user", "screen_name");
            mUser.Name = GetThirdLNValueInStatuses(existStatuses, "string", "user", "name");
            mUser.Province = GetThirdLNValueInStatuses(existStatuses, "string", "user", "province");
            mUser.City = GetThirdLNValueInStatuses(existStatuses, "string", "user", "city");
            mUser.Location = GetThirdLNValueInStatuses(existStatuses, "string", "user", "location");
            mUser.Description = GetThirdLNValueInStatuses(existStatuses, "string", "user", "description");
            mUser.Url = GetThirdLNValueInStatuses(existStatuses, "string", "user", "url");
            mUser.ProfileImageUrl = GetThirdLNValueInStatuses(existStatuses, "string", "user", "profile_image_url");
            mUser.ProfileUrl = GetThirdLNValueInStatuses(existStatuses, "string", "user", "profile_url");
            mUser.Domain = GetThirdLNValueInStatuses(existStatuses, "string", "user", "domain");
            mUser.Weihao = GetThirdLNValueInStatuses(existStatuses, "string", "user", "weihao");
            mUser.Gender = GetThirdLNValueInStatuses(existStatuses, "string", "user", "gender");
            mUser.FollowersCount = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "followers_count"));
            mUser.FriendsCount = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "friends_count"));
            mUser.PagefriendsCount = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "pagefriends_count"));
            mUser.StatusesCount = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "statuses_count"));
            mUser.FavouritesCount = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "favourites_count"));
            mUser.CreatedAt = GetThirdLNValueInStatuses(existStatuses, "string", "user", "created_at");
            mUser.Following = bool.Parse(GetThirdLNValueInStatuses(existStatuses, "bool", "user", "following"));
            mUser.AllowAllActMsg = bool.Parse(GetThirdLNValueInStatuses(existStatuses, "bool", "user", "allow_all_act_msg"));
            mUser.GeoEnabled = bool.Parse(GetThirdLNValueInStatuses(existStatuses, "bool", "user", "geo_enabled"));
            mUser.Verified = bool.Parse(GetThirdLNValueInStatuses(existStatuses, "bool", "user", "verified"));
            mUser.VerifiedType = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "verified_type"));
            mUser.Remark = GetThirdLNValueInStatuses(existStatuses, "string", "user", "remark");
            mUser.Ptype = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "ptype"));
            mUser.AllowAllComment = bool.Parse(GetThirdLNValueInStatuses(existStatuses, "bool", "user", "allow_all_comment"));
            mUser.AvatarLarge = GetThirdLNValueInStatuses(existStatuses, "string", "user", "avatar_large");
            mUser.AvatarHd = GetThirdLNValueInStatuses(existStatuses, "string", "user", "avatar_hd");
            mUser.VerifiedReason = GetThirdLNValueInStatuses(existStatuses, "string", "user", "verified_reason");
            mUser.VerifiedTrade = GetThirdLNValueInStatuses(existStatuses, "string", "user", "verified_trade");
            mUser.VerifiedReasonUrl = GetThirdLNValueInStatuses(existStatuses, "string", "user", "verified_reason_url");
            mUser.VerifiedSource = GetThirdLNValueInStatuses(existStatuses, "string", "user", "verified_source");
            mUser.VerifiedSourceUrl = GetThirdLNValueInStatuses(existStatuses, "string", "user", "verified_source_url");
            mUser.VerifiedState = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "verified_state"));
            mUser.VerifiedLevel = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "verified_level"));
            mUser.VerifiedReasonModified = GetThirdLNValueInStatuses(existStatuses, "string", "user", "verified_reason_modified");
            mUser.VerifiedContactName = GetThirdLNValueInStatuses(existStatuses, "string", "user", "verified_contact_name");
            mUser.VerifiedContactMobile = GetThirdLNValueInStatuses(existStatuses, "string", "user", "verified_contact_mobile");
            mUser.FollowMe = bool.Parse(GetThirdLNValueInStatuses(existStatuses, "bool", "user", "follow_me"));
            mUser.OnlineStatus = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "online_status"));
            mUser.BiFollowersCount = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "bi_followers_count"));
            mUser.Lang = GetThirdLNValueInStatuses(existStatuses, "string", "user", "lang");
            mUser.Star = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "star"));
            mUser.Mbtype = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "mbtype"));
            mUser.Mbrank = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "mbrank"));
            mUser.BlockWord = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "block_word"));
            mUser.BlockApp = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "block_app"));
            mUser.CreditScore = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "credit_score"));
            mUser.UserAbility = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "user_ability"));
            mUser.Urank = int.Parse(GetThirdLNValueInStatuses(existStatuses, "int", "user", "urank"));
            #endregion
        }


        public ObservableCollection<Status> Statuses
        {
            get
            {
                return this.statuses;
            }
            set
            {
                this.statuses = value;
                NotifyPropertyChanged("Statuses");
            }
        }


        public ObservableCollection<string> Advertises
        {
            get
            {
                return this.advertises;
            }
            set
            {
                this.advertises = value;
                NotifyPropertyChanged("Advertises");
            }
        }


        public ObservableCollection<string> Ad
        {
            get
            {
                return this.ad;
            }
            set
            {
                this.ad = value;
                NotifyPropertyChanged("Ad");
            }
        }


        public bool Hasvisible
        {
            get
            {
                return this.hasvisible;
            }
            set
            {
                this.hasvisible = value;
                NotifyPropertyChanged("Hasvisible");
            }
        }


        public long PreviousCursor
        {
            get
            {
                return this.previous_cursor;
            }
            set
            {
                this.previous_cursor = value;
                NotifyPropertyChanged("PreviousCursor");
            }
        }
        public long NextCursor
        {
            get
            {
                return this.next_cursor;
            }
            set
            {
                this.next_cursor = value;
                NotifyPropertyChanged("NextCursor");
            }
        }
        public int TotalNumber
        {
            get
            {
                return this.total_number;
            }
            set
            {
                this.total_number = value;
                NotifyPropertyChanged("TotalNumber");
            }
        }
        public int Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                this.interval = value;
                NotifyPropertyChanged("Interval");
            }
        }
        public int UveBlank
        {
            get
            {
                return this.uve_blank;
            }
            set
            {
                this.uve_blank = value;
                NotifyPropertyChanged("UveBlank");
            }
        }
        public long SinceId
        {
            get
            {
                return this.since_id;
            }
            set
            {
                this.since_id = value;
                NotifyPropertyChanged("SinceId");
            }
        }
        public long MaxId
        {
            get
            {
                return this.max_id;
            }
            set
            {
                this.max_id = value;
                NotifyPropertyChanged("MaxId");
            }
        }
        public int HasUnread
        {
            get
            {
                return this.has_unread;
            }
            set
            {
                this.has_unread = value;
                NotifyPropertyChanged("HasUnread");
            }
        }
    }
}
