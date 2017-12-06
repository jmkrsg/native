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

			if (datum != null) {
				datum.Dispose ();
				datum = null;
			}

			if (datumValue != null) {
				datumValue.Dispose ();
				datumValue = null;
			}

			if (lfd != null) {
				lfd.Dispose ();
				lfd = null;
			}

			if (status != null) {
				status.Dispose ();
				status = null;
			}
		}
	}
}
