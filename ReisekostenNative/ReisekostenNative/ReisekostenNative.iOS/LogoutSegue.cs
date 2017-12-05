// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace ReisekostenNative.iOS
{
    public partial class LogoutSegue : UIStoryboardSegue
	{
        public LogoutSegue (IntPtr handle) : base (handle)
		{
		}

        public override void Perform()
        {
            var tabViewCtrl = SourceViewController as BelegeTableViewController;
            if (tabViewCtrl != null)
            {
                tabViewCtrl.NavigationController.DismissViewController(true, null);
            }
        }
	}
}
