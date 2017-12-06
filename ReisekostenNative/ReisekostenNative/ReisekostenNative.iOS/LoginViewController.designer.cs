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
	[Register ("LoginViewController")]
	partial class LoginViewController
	{
		[Outlet]
		UIKit.UITextField benutzer { get; set; }

		[Outlet]
		UIKit.UITextField passwort { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (benutzer != null) {
				benutzer.Dispose ();
				benutzer = null;
			}

			if (passwort != null) {
				passwort.Dispose ();
				passwort = null;
			}
		}
	}
}
