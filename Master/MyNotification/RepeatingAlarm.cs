using System;

using Android.App;
using Android.Content;
using Android.Widget;
using MyNotification;

namespace MonoDroid.ApiDemo
{
	/**
 	* This is an example of implement an {@link BroadcastReceiver} for an alarm that
 	* should occur once.
 	*/
	[BroadcastReceiver]
	public class RepeatingAlarm : BroadcastReceiver
	{
		public override void OnReceive (Context context, Intent intent)
		{
			//Toast.MakeText (context, Resource.String.repeating_received, ToastLength.Short).Show ();
		}
	}
}

