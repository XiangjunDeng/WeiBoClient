namespace WeiBoClient.Model.WeiboStatuses
{
    public class Visible : BaseModel
    {
        private int type;
        private int list_id;

        public int Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
                NotifyPropertyChanged("Type");
            }
        }
        public int ListId
        {
            get
            {
                return this.list_id;
            }
            set
            {
                this.list_id = value;
                NotifyPropertyChanged("ListId");
            }
        }
    }
}