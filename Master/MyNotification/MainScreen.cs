
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyNotification
{
	[Activity (Label = "")]			
	public class MainScreen : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			RequestWindowFeature (WindowFeatures.NoTitle);
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.MainLayout);
			// Create your application here
		}
	}
}

