// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
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
			if (image != null) {
				image.Dispose ();
				image = null;
			}

			if (bezeichnung != null) {
				bezeichnung.Dispose ();
				bezeichnung = null;
			}

			if (betrag != null) {
				betrag.Dispose ();
				betrag = null;
			}

			if (datum != null) {
				datum.Dispose ();
				datum = null;
			}

			if (status != null) {
				status.Dispose ();
				status = null;
			}
		}
	}
}
