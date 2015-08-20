using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeiBoClient.Model;
using WeiBoClient.Utility;

namespace WeiboClientAPP.Model.WeiboStatuses.UtilityModel
{
    /// <summary>
    /// V1.0    Add Model for user's interested friends    8/13/2015       Crystal
    /// V1.1    Add judgment for 'jsonResult' if it not a standard json string or illegal string   8/13/2015       Crystal
    /// Function: Acquire current user's interested friend list
    /// </summary>
    class AcquireIntrFriend : BaseModel
    {
        private ObservableCollection<IntrFriend> intrFriendList;

        public AcquireIntrFriend(string jsonResult)
        {
            if (jsonResult == string.Empty || jsonResult.Substring(2,3) == "req")
            {
                //'jsonResult' is empty, return to stop execute this function
                return;
            }
            else
            {
                if (jsonResult.Substring(0,1) == "[")
                {
                    string str = "{\"intrfriend\":" + jsonResult + "}";//jsonResult is not a standard structure that will cause exception in "JsonConverterTool.GetWeibo(jsonResult, rootNodeName);"
                                                                       //str = jsonResult;
                    intrFriendList = new ObservableCollection<IntrFriend>();

                    //Generate XDocument with a root name "RootNode"
                    IEnumerable<XElement> rootIntrFriendList = GetRootNodeList(str, "RootNode");
                    if (IsEleListNotNull(rootIntrFriendList))
                    {
                        //rootIntrFriendList.ElementAt(0).Descendants("statuses")
                        GetRootIntrFriend(rootIntrFriendList.ElementAt(0).Descendants("intrfriend"));
                    }
                }
            }
        }


        private void GetRootIntrFriend(IEnumerable<XElement> list)
        {
            if (IsEleListNotNull(list))
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    IntrFriend mIntrFriend = new IntrFriend();

                    mIntrFriend.Uid = long.Parse(GetEleValueInStatuses(list.ElementAt(i), "long", "uid"));
                    mIntrFriend.Nickname = GetEleValueInStatuses(list.ElementAt(i), "string", "nickname");
                    mIntrFriend.Remark = GetEleValueInStatuses(list.ElementAt(i), "string", "remark");
                    
                    intrFriendList.Add(mIntrFriend);
                }
            }
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









        public ObservableCollection<IntrFriend> IntrFriendList
        {
            get
            {
                return this.intrFriendList;
            }
            set
            {
                this.intrFriendList = value;
                NotifyPropertyChanged("IntrFriendList");
            }
        }
    }
}
