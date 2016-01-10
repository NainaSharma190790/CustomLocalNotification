using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using MyNotification;

namespace MonoDroid.ApiDemo
{
	[Activity (Label = "Mother", MainLauncher = true)]

	public class AlarmController : Activity
	{
		private Button btnSet, btnRandom,btnTheme;
		private TimePicker timePicker;

		private int _count = 1;
		private DateTime currenttime;
		private int inputTime,actualtime,maxMinutes,minutes,randomHr,randomMin,currentHr,currentMin,interval;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			RequestWindowFeature (WindowFeatures.NoTitle);
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.alarm_controller);
			btnSet =  FindViewById<Button>(Resource.Id.btnSet);
			btnRandom =  FindViewById<Button>(Resource.Id.btnRandom);
			timePicker =  FindViewById<TimePicker>(Resource.Id.timePicker);
			btnTheme=  FindViewById<Button>(Resource.Id.btnTheme);
			timePicker.SetIs24HourView ((Java.Lang.Boolean)true);
			btnSet.Click += btnSet_Click;
			btnRandom.Click += btnRandom_Click;
			btnTheme.Click += btnTheme_Click;

		}
		private void btnSet_Click(object sender, EventArgs eventArgs)
		{
			var intent = new Intent (this, typeof (OneShotAlarm));
			var source = PendingIntent.GetBroadcast (this, 0, intent, 0);
			currenttime = DateTime.Now;
			int actualTime = currenttime.Hour * 60 + currenttime.Minute;
			int inputTime = (Convert.ToInt32 (timePicker.CurrentHour)) * 60 + (Convert.ToInt32 (timePicker.CurrentMinute));
			if (inputTime < actualTime)
			{
				currenttime = currenttime.AddDays (1);
				currentHr = Convert.ToInt32 (timePicker.CurrentHour);
				currentMin = Convert.ToInt32 (timePicker.CurrentMinute);
			} 
			else
			{
				currentHr = Convert.ToInt32 (timePicker.CurrentHour) - currenttime.Hour;
				currentMin = Convert.ToInt32 (timePicker.CurrentMinute) - currenttime.Minute;
			}

			interval = (((currentHr * 60) * 60 )+ ((currentMin)* 60))* 1000;

			// Schedule the alarm for 30 seconds from now!
			var am = (AlarmManager) GetSystemService (AlarmService);
			am.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime () + interval , source);
			StartActivity(typeof(SecondActivity));
		}
		private void btnRandom_Click(object sender, EventArgs eventArgs)
		{
			var intent = new Intent (this, typeof (OneShotAlarm));
			var source = PendingIntent.GetBroadcast (this, 0, intent, 0);

			var random = new System.Random();
			var start = TimeSpan.FromHours(17);
			var end = TimeSpan.FromHours(18);

			maxMinutes = (int)((end - start).TotalMinutes);
			minutes = random.Next (maxMinutes);

			TimeSpan t = start.Add (TimeSpan.FromMinutes (minutes));
			randomHr = t.Hours;
			randomMin = t.Minutes;
			currenttime = DateTime.Now;
			currentHr =randomHr - currenttime.Hour;
			currentMin=randomMin - currenttime.Minute;

			interval = (((currentHr * 60) * 60) + (currentMin* 60))* 1000;

			var am = (AlarmManager) GetSystemService (AlarmService);
			am.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime () + interval , source);
			StartActivity(typeof(SecondActivity));
		}
		private void btnTheme_Click(object sender, EventArgs eventArgs)
		{
			StartActivity(typeof(ThemeActivity));
		}
	}
}
