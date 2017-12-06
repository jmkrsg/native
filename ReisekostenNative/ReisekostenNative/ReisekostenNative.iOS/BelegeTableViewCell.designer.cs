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
    [Register ("BelegeTableViewCell")]
    partial class BelegeTableViewCell
    {
        [Outlet]
        UIKit.UILabel betrag { get; set; }


        [Outlet]
        UIKit.UILabel bezeichnung { get; set; }


        [Outlet]
        UIKit.UILabel datum { get; set; }


        [Outlet]
        UIKit.UIImageView image { get; set; }


        [Outlet]
        UIKit.UIImageView status { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (betrag != null) {
                betrag.Dispose ();
                betrag = null;
            }

            if (bezeichnung != null) {
                bezeichnung.Dispose ();
                bezeichnung = null;
            }

            if (datum != null) {
                datum.Dispose ();
                datum = null;
            }

            if (image != null) {
                image.Dispose ();
                image = null;
            }

            if (status != null) {
                status.Dispose ();
                status = null;
            }
        }
    }
}