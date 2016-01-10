using System;

using Android.App;
using Android.Content;
using Android.Widget;
using MyNotification;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Java.Util;
using Android.Graphics;
using Android.Support.V4.App;
using Android.Media;

namespace MonoDroid.ApiDemo
{
	[BroadcastReceiver]
	public class OneShotAlarm : BroadcastReceiver
	{
		public override void OnReceive (Context context, Intent intent)
		{
			var message = intent.GetStringExtra("message");
			var title = intent.GetStringExtra("title");

			var notIntent = new Intent(context, typeof(MainScreen));
			var contentIntent = PendingIntent.GetActivity(context, 0, notIntent, PendingIntentFlags.CancelCurrent);
			var manager = NotificationManagerCompat.From(context);

			var style = new NotificationCompat.BigTextStyle();
			style.BigText(message);

			int resourceId = Resource.Drawable.HappyBaby;

			var wearableExtender = new NotificationCompat.WearableExtender()
				.SetBackground(BitmapFactory.DecodeResource(context.Resources, resourceId));

			//Generate a notification with just short text and small icon
			var builder = new NotificationCompat.Builder(context)
				.SetContentIntent(contentIntent)
				.SetSmallIcon(Resource.Drawable.HappyBaby)
				.SetSound(Android.Net.Uri.Parse("android.resource://com.iinotification.app/"+ Resource.Raw.babySound))
				.SetContentTitle("Hey Mom")
				.SetContentText("Here I'm :)")
				.SetStyle(style)
				.SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
				.SetAutoCancel(true)
				.Extend(wearableExtender);

			var notification = builder.Build();
			manager.Notify(0, notification);
		}

	}

	public class AndroidReminderService 
	{
		Activity _context;

		public AndroidReminderService(Activity context)
		{
			_context = context;
		}

		#region ReminderService implementation

		public void Remind(DateTime dateTime, string title, string message, int interval)
		{

			Intent alarmIntent = new Intent(_context, typeof(MainScreen));
			alarmIntent.PutExtra("message", message);
			alarmIntent.PutExtra("title", title);

			PendingIntent pendingIntent = PendingIntent.GetBroadcast(_context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
			AlarmManager alarmManager = (AlarmManager)_context.GetSystemService(Context.AlarmService);
			alarmManager.SetRepeating(AlarmType.ElapsedRealtimeWakeup, interval, interval/*2 * 60 * 60*/, pendingIntent);
		}

		#endregion
	}
}