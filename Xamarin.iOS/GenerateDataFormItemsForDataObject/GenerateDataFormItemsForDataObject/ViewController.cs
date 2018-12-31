using Syncfusion.iOS.DataForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UIKit;

namespace GenerateDataFormItemsForDataObject
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        Dictionary<string, object> formDictionary;
        public override void ViewDidLoad()
        {
            //  base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var dataForm = new SfDataForm(new CoreGraphics.CGRect(0, 45, this.View.Frame.Width, this.View.Frame.Height));

            dataForm.DataObject = new ContactsInfo();
            dataForm.ItemManager = new DataFormItemManagerExt(dataForm);

            View.AddSubview(dataForm);
        }

        public class ContactsInfo
        {

            private int contactNumber = 20;
            private string firstName = "Kyle";
            public int ContactNumber
            {
                get { return contactNumber; }
                set
                {
                    contactNumber = value;
                    this.RaisePropertyChanged("ContactNumber");
                }
            }
            public string FirstName
            {
                get { return firstName; }
                set
                {
                    firstName = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void RaisePropertyChanged(String Name)
            {
                if (PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

}
