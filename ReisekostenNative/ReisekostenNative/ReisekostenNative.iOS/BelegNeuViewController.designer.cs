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
	[Register ("BelegNeuViewController")]
	partial class BelegNeuViewController
	{
		[Outlet]
		UIKit.UIPickerView art { get; set; }

		[Outlet]
		UIKit.UIImageView beleg { get; set; }

		[Outlet]
		UIKit.UITextField beschreibung { get; set; }

		[Outlet]
		UIKit.UITextField betrag { get; set; }

		[Outlet]
		UIKit.UITextField bezeichnung { get; set; }

		[Outlet]
		UIKit.UIDatePicker datum { get; set; }

		[Outlet]
		UIKit.UILabel lfd { get; set; }

		[Outlet]
		UIKit.UIImageView status { get; set; }

		[Action ("belegButtonPerformed:")]
		partial void belegButtonPerformed (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (lfd != null) {
				lfd.Dispose ();
				lfd = null;
			}

			if (datum != null) {
				datum.Dispose ();
				datum = null;
			}

			if (art != null) {
				art.Dispose ();
				art = null;
			}

			if (betrag != null) {
				betrag.Dispose ();
				betrag = null;
			}

			if (status != null) {
				status.Dispose ();
				status = null;
			}

			if (bezeichnung != null) {
				bezeichnung.Dispose ();
				bezeichnung = null;
			}

			if (beschreibung != null) {
				beschreibung.Dispose ();
				beschreibung = null;
			}

			if (beleg != null) {
				beleg.Dispose ();
				beleg = null;
			}
		}
	}
}
