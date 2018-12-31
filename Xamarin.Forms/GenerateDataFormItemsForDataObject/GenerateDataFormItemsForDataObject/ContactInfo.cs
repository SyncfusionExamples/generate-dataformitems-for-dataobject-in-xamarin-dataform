using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateDataFormItemsForDataObject
{
    public class ContactsInfo
    {

        private double id = 20;
        private string _name = null;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                this.RaisePropertyChanged("Name");
            }
        }
        public double ID
        {
            get { return id; }
            set
            {
                id = value;
                this.RaisePropertyChanged("ID");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String Name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
        }
    }

}
