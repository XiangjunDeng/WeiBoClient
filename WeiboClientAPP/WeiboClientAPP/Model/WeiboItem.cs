using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiBoClient.Model
{
    public class WeiboItem : BaseModel
    {
        private string name;
        private string text;
        private string created_at;
        
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
        public string Created_at
        {
            get
            {
                return this.created_at;
            }
            set
            {
                this.created_at = value;
                NotifyPropertyChanged("Created_at");
            }
        }

        
    }
}
