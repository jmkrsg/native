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
    [Register ("BelegNeuTableView")]
    partial class BelegNeuTableView
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

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        ReisekostenNative.iOS.BelegNeuTableViewController dataSource { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        ReisekostenNative.iOS.BelegNeuTableViewController @delegate { get; set; }


        [Action ("artEditingChanged:")]
        partial void artEditingChanged (Foundation.NSObject sender);


        [Action ("artEditingEnd:")]
        partial void artEditingEnd (Foundation.NSObject sender);


        [Action ("belegButtonPerformed:")]
        partial void belegButtonPerformed (Foundation.NSObject sender);


        [Action ("datumEditingChanged:")]
        partial void datumEditingChanged (Foundation.NSObject sender);


        [Action ("datumEditingEnd:")]
        partial void datumEditingEnd (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
            if (art != null) {
                art.Dispose ();
                art = null;
            }

            if (artValue != null) {
                artValue.Dispose ();
                artValue = null;
            }

            if (beleg != null) {
                beleg.Dispose ();
                beleg = null;
            }

            if (beschreibung != null) {
                beschreibung.Dispose ();
                beschreibung = null;
            }

            if (betrag != null) {
                betrag.Dispose ();
                betrag = null;
            }

            if (bezeichnung != null) {
                bezeichnung.Dispose ();
                bezeichnung = null;
            }

            if (dataSource != null) {
                dataSource.Dispose ();
                dataSource = null;
            }

            if (datum != null) {
                datum.Dispose ();
                datum = null;
            }

            if (datumValue != null) {
                datumValue.Dispose ();
                datumValue = null;
            }

            if (@delegate != null) {
                @delegate.Dispose ();
                @delegate = null;
            }

            if (status != null) {
                status.Dispose ();
                status = null;
            }
        }
    }
}