// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation;
using UIKit;
using ReisekostenNative.Services;

namespace ReisekostenNative.iOS
{
    public partial class BelegNeuTableView : UITableView
	{
        public BelegNeuTableView (IntPtr handle) : base (handle)
        {
        }

        public void initTableView() {
            datum.MaximumDate = new NSDate();
            datumValue.Text = "";
            artValue.Text = "";
            beschreibung.Text = "";
            beschreibungValue.Text = "";
            art.Model = new ArtenPickerViewModel();
            UIService.Instance.GetBelegarten((o) => setArten(o));
        }

        private void setArten(Task<List<string>> o)
        {
            ((ArtenPickerViewModel)art.Model).setArten(o.Result, artValue);
            art.ReloadComponent(0);
        }

        public bool hasImage() {
            return beleg != null && beleg.Image != null;
        }

        public bool hasBeschreibung() {
            return beschreibung != null && beschreibung.Text != null && beschreibung.Text.Length > 0;
        }

        public class ArtenPickerViewModel : UIPickerViewModel
        {

            List<string> arten = new List<string>();
            UILabel artVal = new UILabel();

            public void setArten(List<string> newArten, UILabel newArtVal)
            {
                arten = newArten;
                artVal = newArtVal;
            }

            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                return arten.Capacity;
            }

            public override string GetTitle(UIPickerView pickerView, nint row, nint component)
            {
                return arten[(int)row];
            }

            public override nint GetComponentCount(UIPickerView pickerView)
            {
                return 1;
            }

            public override void Selected(UIPickerView pickerView, nint row, nint component)
            {
                artVal.Text = arten[(int)row];
            }

        }

        partial void datumEditingEnd(NSObject sender)
        {
            var formatter = new NSDateFormatter();
            formatter.DateFormat = "dd.MM.yyyy";
            datumValue.Text = formatter.StringFor(datum.Date);
        }

        partial void datumEditingChanged(NSObject sender)
        {
            var formatter = new NSDateFormatter();
            formatter.DateFormat = "dd.MM.yyyy";
            datumValue.Text = formatter.StringFor(datum.Date);
        }

        partial void belegButtonPerformed(NSObject sender)
        {

        }
	}
}
