// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ReisekostenNative.iOS
{
    [Register ("BelegNeuTableViewController")]
    partial class BelegNeuTableViewController
    {
        [Outlet]
        UIKit.UIPickerView art { get; set; }


        [Outlet]
        UIKit.UILabel artValue { get; set; }


        [Outlet]
        UIKit.UIImageView beleg { get; set; }


        [Outlet]
        UIKit.UITextView beschreibung { get; set; }


        [Outlet]
        UIKit.UITextField betrag { get; set; }


        [Outlet]
        UIKit.UITextField bezeichnung { get; set; }


        [Outlet]
        UIKit.UIDatePicker datum { get; set; }


        [Outlet]
        UIKit.UILabel datumValue { get; set; }


        [Outlet]
        UIKit.UILabel lfd { get; set; }


        [Outlet]
        UIKit.UIImageView status { get; set; }


        [Action ("belegButtonPerformed:")]
        partial void belegButtonPerformed (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
        }
    }
}