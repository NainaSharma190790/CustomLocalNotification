
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
using MonoDroid.ApiDemo;

namespace MyNotification
{
	[Activity (Label = "")]			
	public class SecondActivity : Activity
	{
		private Button btnSetting;
		protected override void OnCreate (Bundle bundle)
		{
			RequestWindowFeature (WindowFeatures.NoTitle);
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.SecondLayout);
			btnSetting =  FindViewById<Button>(Resource.Id.btnSetting);
			btnSetting.Click += btnSetting_Click;

		}
		private void btnSetting_Click(object sender, EventArgs eventArgs)
		{
			StartActivity(typeof(AlarmController));		
		}
	}
}
