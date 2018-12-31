using Android.App;
using Android.Widget;
using Android.OS;
using Syncfusion.Android.DataForm;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Reflection;
using Android.Content;

namespace GenerateDataFormItemsForDataObject
{
    [Activity(Label = "GenerateDataFormItemsForDataObject", MainLauncher = true)]
    public class MainActivity : Activity
    {

        //public static Context context;
        public static SfDataForm dataForm;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            dataForm = new SfDataForm(this);
            var a = new ContactsInfo();
            dataForm.DataObject = a;// new ContactsInfo();
            dataForm.ItemManager = new DataFormItemManagerExt(dataForm);
            // Set our view from the "main" layout resource
            SetContentView(dataForm);
        }
    }

    public class DataFormItemManagerExt : DataFormItemManager
    {
        public DataFormItemManagerExt(SfDataForm dataForm) : base(dataForm)
        {
           
        }
        protected override List<DataFormItemBase> GenerateDataFormItems(PropertyDescriptorCollection itemProperties, List<DataFormItemBase> dataFormItems)
        {
            var items = new List<DataFormItemBase>();
            foreach (PropertyDescriptor propertyInfo in itemProperties)
            {
                DataFormItem dataFormItem;
                if (propertyInfo.Name == "ContactNumber")
                    dataFormItem = new DataFormTextItem() { Name = propertyInfo.Name, Editor = "Text", InputType = Android.Text.InputTypes.ClassNumber };
                else if (propertyInfo.Name == "FirstName")
                    dataFormItem = new DataFormTextItem() { Name = propertyInfo.Name, Editor = "Text" };
                else
                    dataFormItem = new DataFormTextItem() { Name = propertyInfo.Name, Editor = "Text" };
                items.Add(dataFormItem);
            }

            return items;
        }

        public override object GetValue(DataFormItem dataFormItem)
        {
            var value = MainActivity.dataForm.DataObject.GetType().GetRuntimeProperty(dataFormItem.Name).GetValue(MainActivity.dataForm.DataObject);
            return value;
        }

        public override void SetValue(DataFormItem dataFormItem, object value)
        {
            MainActivity.dataForm.DataObject.GetType().GetRuntimeProperty(dataFormItem.Name).SetValue(MainActivity.dataForm.DataObject, value);
        }
    }
    public class ContactsInfo
    {

        private string contactNumber = "20";
        private string _name = "Kyle";
        public string ContactNumber
        {
            get { return contactNumber; }
            set
            {
                contactNumber = value;
                this.RaisePropertyChanged("ContactNumber");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                this.RaisePropertyChanged("Name");
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