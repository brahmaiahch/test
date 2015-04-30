
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

using KeyEvent = Android.Views.KeyEvent;
using Menu = Android.Views.Menu;
using MenuItem = Android.Views.IMenuItem;
using View = Android.Views.View;
using OnClickListener = Android.Views.View.IOnClickListener;
using Button = Android.Widget.Button;
using TextView = Android.Widget.TextView;

namespace AssurantApplication
{
	[Activity (Label = "MessageActivity")]			
	public class MessageActivity : Activity,View.IOnClickListener
	{
		 const int INVOKED_BY_PUSH = 0;
		const int INVOKED_BY_MESSAGE_URI = 1;
		const int INVOKED_BY_EXCEPTION = 2;
		const int INVOKED_BY_SDK_INIT_ERROR = 3;

		internal int activityInvokedBy = -1;

		internal string TAG = "MessageActivity";

		internal ActionBar actionBar = null;
		internal TextView pageTitle = null;
		internal TextView messagePart1 = null;
		internal TextView messagePart2 = null;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Message);

			initialSettings();

			if (activityInvokedBy == INVOKED_BY_EXCEPTION || activityInvokedBy == INVOKED_BY_SDK_INIT_ERROR)
			{
				showExceptionMessage();
			}
			else
			{
				parseMessageAndUpdateUI();
			}

			// Create your application here
		}

		private void initialSettings()
		{

			pageTitle = FindViewById<TextView>(Resource.Id.textViewtitle);
			messagePart1 = FindViewById<TextView>(Resource.Id.tvMessagePart1);
			messagePart2 = FindViewById<TextView>(Resource.Id.tvMessagePart2);

			Button messageBtn = FindViewById<Button>(Resource.Id.BtnMessageOk);
			messageBtn.SetOnClickListener(this);
		}
		private void showExceptionMessage()
		{

			string eMessage = Intent.GetStringExtra("Message");
			string eLocMessage = Intent.GetStringExtra("LocalizedMessage");

			pageTitle.Text = "Exception Handler";
			messagePart1.Text = "Error : " + eMessage;
			messagePart2.Text = "Cause : " + eLocMessage;
		}
		private void parseMessageAndUpdateUI()
		{

			if (Intent.GetStringExtra("NotificationId") != "-1")
			{
				((NotificationManager) this.GetSystemService(Context.NotificationService)).Cancel(Intent.GetIntExtra("NotificationId", -1));
			}

			string nType = Intent.GetStringExtra("nType");
			string nMessage = Intent.GetStringExtra("nMessage");
			string nPhoneNumber = Intent.GetStringExtra("nFrom");

			switch (activityInvokedBy)
			{

			case INVOKED_BY_PUSH:
				pageTitle.Text = "Invoked by Push\nFrom - " + nPhoneNumber;
				break;

			case INVOKED_BY_MESSAGE_URI:
				pageTitle.Text = "Invoked by Message";
				break;

			default:
				break;
			}

			messagePart1.Text = "Category : " + nType;
			messagePart2.Text = "Message : " + nMessage;
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{

			base.OnCreateOptionsMenu (menu);

			MenuInflater inflater = this.MenuInflater;

			//inflater.Inflate (Resource.Menu.home, menu);

			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{

			switch (item.ItemId)
			{

			case Android.Resource.Id.Home:

				updateActivityReturnCodes("backButton");
				Finish();
				break;

//			case Resource.Id.action_home:
//				updateActivityReturnCodes("homeButton");
//				gotoHome();
//				break;

			default:
				break;
			}

			return base.OnOptionsItemSelected(item);
		}
		public void OnClick(View v)
		{

			switch (v.Id)
			{

			case Resource.Id.BtnMessageOk:
				updateActivityReturnCodes("homeButton");
				gotoHome();
				break;

			default:
				break;
			}
		}

		public override  bool OnKeyDown(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
		{

			if (keyCode ==Keycode.Back)
			{
				updateActivityReturnCodes("backButton");
				Finish();
				return true;
			}

			return base.OnKeyDown (keyCode, e);
		}

		private void updateActivityReturnCodes(string from)
		{

			Intent output = new Intent();
			output.PutExtra("from", from);

			SetResult(Result.Ok, output);
		}

		private void gotoHome()
		{

			if (activityInvokedBy != INVOKED_BY_SDK_INIT_ERROR)
			{

				Intent homeIntent = new Intent(this, typeof(HomeActivity));
				homeIntent.AddFlags(ActivityFlags.NewTask);
				homeIntent.AddFlags(ActivityFlags.ClearTop);
				StartActivity(homeIntent);
			}

			Finish();
		}
	}
}

