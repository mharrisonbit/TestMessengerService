using TestMessagerCore;
using System;
using Android.OS;
using Android.Util;

namespace TestMessengerService
{
    public class MainActivityMessageHandler : Handler
    {
		static readonly string TAG = typeof(MainActivityMessageHandler).FullName;
		WeakReference<MainActivity> activity;

		public MainActivityMessageHandler(MainActivity activity)
		{
			this.activity = new WeakReference<MainActivity>(activity);
		}
		MainActivity Activity
		{
			get
			{
				MainActivity ma;

				if (activity.TryGetTarget(out ma))
				{
					return ma;
				}
				return null;
			}
		}

		public override void HandleMessage(Message msg)
		{
			int what = msg.What;

			switch (what)
			{
				case (Constants.GET_UTC_TIMESTAMP_RESPONSE):
					string timestampMessage = msg.Data.GetString(Constants.TIMESTAMP_RESPONSE_KEY) ?? "NO MESSAGE.";

					Activity.timestampMessageTextView.Text = timestampMessage;
					break;

				default:
					Log.Warn(TAG, $"Unknown msg.what value: {what} . Ignoring this message.");
					break;

			}
		}
	}
}