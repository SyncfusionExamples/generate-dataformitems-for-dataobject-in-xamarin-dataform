using Syncfusion.iOS.DataForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace GenerateDataFormItemsForDataObject
{
    public class DataFormItemManagerExt : DataFormItemManager
    {
       public  SfDataForm dataform = new SfDataForm();
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
                    dataFormItem = new DataFormTextItem() { Name = propertyInfo.Name, Editor = "Text" };
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
            var value = dataform.DataObject.GetType().GetRuntimeProperty(dataFormItem.Name).GetValue(dataform.DataObject);
            return value;
        }

        public override void SetValue(DataFormItem dataFormItem, object value)
        {
            dataform.DataObject.GetType().GetRuntimeProperty(dataFormItem.Name).SetValue(dataform.DataObject, value);
        }
    }
}
