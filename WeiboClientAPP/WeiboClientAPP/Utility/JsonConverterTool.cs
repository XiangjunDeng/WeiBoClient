using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace WeiBoClient.Utility
{
    public class JsonConverterTool
    {
        public static XDocument GetWeiboList(string jsonString)
        {
            XDocument xNodes = JsonConvert.DeserializeXNode(jsonString, "statuses");
            return xNodes;
        }

        public static XDocument GetWeibo(string jsonString, string nodeName)
        {
            XDocument xNodes = JsonConvert.DeserializeXNode(jsonString, nodeName);
            return xNodes;
        }
    }
}
