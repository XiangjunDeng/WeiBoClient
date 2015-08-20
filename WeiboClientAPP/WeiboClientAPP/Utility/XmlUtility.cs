using WeiBoClient.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Windows.Data.Xml.Dom;
using Windows.UI.Xaml;

namespace WeiBoClient.Utility
{
    public class XmlUtility
    {
        private static XDocument doc = null;
        private static XmlUtility instance = null;
        /// <summary>
        /// Get the instance of Configuration
        /// </summary>
        public static XmlUtility Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new XmlUtility();
                }
                return instance;
            }
        }
        private XmlUtility()
        {
            string sysSettingPath = Path.Combine(Package.Current.InstalledLocation.Path, "Configuration\\SysSetting.xml");
            
            doc = XDocument.Load(sysSettingPath);
        }

        /// <summary>
        /// Get the App Info (AppKey, AppSecret...)
        /// </summary>
        /// <returns></returns>
        public BaseModel GetAppSettingByKey()
        {
            var data = from query in doc.Descendants("appSettings")
                       select new BaseModel
                       {
                           AppKey = (string)query.Element("AppKey"),
                           AppSecret = (string)query.Element("AppSecret"),
                           RedirectUri = (string)query.Element("RedirectUri")
                       };
            return data.ToList<BaseModel>().FirstOrDefault();
        }
    }
}
