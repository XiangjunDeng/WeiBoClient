namespace WeiBoClient.Model.WeiboStatuses
{
    ////"annotations":[{"client_mblogid":"iPhone-D28F4FE2-6B71-45E9-B8C8-F9697BB8CB9D"},{"mapi_request":true}]
    public class Annotations : BaseModel
    {
        private string client_mblogid;
        private string mapi_request;          
        public string ClientMblogid 
        {
            get
            {
                return this.client_mblogid;
            }
            set
            {
                this.client_mblogid = value;
                NotifyPropertyChanged("ClientMblogid");
            }
        }
        public string MapiRequest
        {
            get
            {
                return this.mapi_request;
            }
            set
            {
                this.mapi_request = value;
                NotifyPropertyChanged("MapiRequest");
            }
        }
    }
}