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

using ClientSDKHelper = Com.Cognizant.Trumobi.Appintegration.Clientsdk.Core.ClientSDKHelper;
using Entity = Com.Cognizant.Trumobi.Appintegration.Clientsdk.DB.Entity;
using TJError = Com.Cognizant.Trumobi.Appintegration.Clientsdk.Exception.TJError;
using TJResponseHandler = Com.Cognizant.Trumobi.Appintegration.Clientsdk.Handlers.ITJResponseHandler;
using TJProgressHandler = Com.Cognizant.Trumobi.Appintegration.Clientsdk.Handlers.ITJProgressHandler;
using ClientSdkConfiguration = Com.Cognizant.Trumobi.Appintegration.Clientsdk.Core.ClientSdkConfiguration;
using Log = Com.Cognizant.Trumobi.Appintegration.Clientsdk.Util.Log;
using DigitalHubModel = Appmodel.Orchestration;
using Com.Cognizant.Trumobi.Appintegration.Clientsdk.Handlers;
using Com.Cognizant.Trumobi.Appintegration.Clientsdk.Core;
using Org.Json;
using Com.Cognizant.Trumobi.Appintegration.Clientsdk.Util;
using Android.Preferences;

namespace AssurantApplication
{
	[Activity (Label = "AssurantApplication", MainLauncher = true,ConfigurationChanges = (Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.KeyboardHidden))]

	public class LoginActivity : Activity
	{

		internal Context mContext;
		private readonly string TAG = typeof(LoginActivity).Name;
		internal ClientSDKHelper clientSDKHelper;
		Appmodel.AssurantDigitalHub assurantApp;
		Button _dialogNegativeButton;
		Button _dialogPositiveButton;
		AlertDialog alert;
		EditText userNameEdtTxt;
		EditText passwordEdtTxt ;
		ProgressDialog progressDialog;

		private static string tokenObj = string.Empty;
		private static string userID = string.Empty;
		private static string custID = string.Empty;

		private readonly int INVOKED_BY_SDK_INIT_ERROR = 3;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);


			assurantApp = new Appmodel.AssurantDigitalHub (this);
			SetContentView (Resource.Layout.Login);

			mContext = this;

			clientSDKHelper = ClientSDKHelper.GetInstance (this);
			progressDialog = new ProgressDialog(this);
			startSDKInitProcess();

		}
		private void startSDKInitProcess()
		{
			ClientSdkConfiguration sdkConfiguration = ClientSdkConfiguration.Instance;
			sdkConfiguration.AppPackageModel = "appmodel";
			sdkConfiguration.SetMessagePackCompression(false);
			sdkConfiguration.SetGCMParams("48913525767", "AIzaSyDKLpuOGS9wQqnfeeLM0hujRdQzRliZ2T8");
			sdkConfiguration.RegisterForPushNotification(typeof(MessageActivity).FullName, Resource.Drawable.Assurant);
			sdkConfiguration.SetNetworkType (Com.Cognizant.Trumobi.Appintegration.Clientsdk.Context.SyncContext.NetworkType.TwoGNetwork);


			clientSDKHelper.InitializeSDK(sdkConfiguration, new ProgressDialog(this), new TJResponseHandlerInitilizeSDKHandler(this));


			// Retrieving data from existing table
//			IDictionary<string,SyncUtils.CLASSTYPE> colums = new Dictionary<string,SyncUtils.CLASSTYPE>();
//			colums.Add ("username", SyncUtils.CLASSTYPE.String);
//			colums.Add ("password",SyncUtils.CLASSTYPE.String);
//			colums.Add ("login_attempt",SyncUtils.CLASSTYPE.Int);
//
//			GenericDBManager gb = new GenericDBManager (this, "UserStorageDB", colums,new TjHandler(this));
//			gb.CreateTable ();
//			string query = "login_attempt=?";
//			string[] values = new string[] {
//				"1"
//			};
//			ContentValues Cv = new ContentValues ();
//			Cv.Put ("username", "brahmam");
//			Cv.Put ("password", "brahmam");
//			Cv.Put ("login_attempt", 1);
//
//
//			ContentValues Cvobj = new ContentValues ();
//			Cvobj.Put ("username", "test");
//			Cvobj.Put ("password", "test");
//			Cvobj.Put ("login_attempt", 1);
//			query = "login_attempt=?";
//
//			gb.UpdateValues(Cvobj,query,values);
//			gb.Select (null, null);
//			gb.DeleteValues (query, values);
		}

		// HashMap<String, Class<?>> columns = new HashMap<String, Class<?>>();
		//
		// columns.put("username", String.class);
		// columns.put("password", String.class);
		// columns.put("login_attempt", Integer.class);
		//
		// GenericDBManager gb = new GenericDBManager(mContext, "UserStorageDB", columns);
		// gb.createTable();
		//
		// ContentValues cv = new ContentValues();
		// cv.put("username", "Sudarshan");
		// cv.put("password", "sudarshan");
		// cv.put("login_attempt", 1);
		//
		// gb.insertValues(cv);
		//
		// JSONObject obj = gb.select(null, null);




		private void startLoginProcess()
		{
			Button startLoginButton = FindViewById <Button>(Resource.Id.loginStartButton);
			Button withOutLogin = FindViewById<Button> (Resource.Id.withOutLogin);
			withOutLogin.Click+= delegate {
				userID ="hemal2008@test.lifestylegroup.co.uk";
				custID="73548765868";
				openHomeActivity();
			};
			startLoginButton.SetOnClickListener (new OnClickListenerShowLoginDialog (this));
		}

		private class OnClickListenerShowLoginDialog :Java.Lang.Object,View.IOnClickListener
		{
			private readonly LoginActivity outerInstance;

			public OnClickListenerShowLoginDialog(LoginActivity outerInstance)
			{
				this.outerInstance = outerInstance;

			}
			public void OnClick(View arg0)
			{
				Appmodel.AssurantDigitalHub assurantApp = new Appmodel.AssurantDigitalHub (outerInstance);
				// DigitalHubModel.Eligiblecustomeremail.Model.EligibleCustomerEmail_EligibleCustomerEmail_READ_REQUEST EligibleCustomerReadRequest = new  DigitalHubModel.Eligiblecustomeremail.Model.EligibleCustomerEmail_EligibleCustomerEmail_READ_REQUEST ();
				// //EligibleCustomerReadRequest.Authorization = "Huzzle f12d483d-8919-4d1b-9dd6-34390b5ead26.8b4ade9e5284531029680e5618cf6d79";
				// EligibleCustomerReadRequest.Company = "halifax";
				// //EligibleCustomerReadRequest.ID = "johnnycrappleseed@ex";
				// EligibleCustomerReadRequest.ID = "halifax";
				// EligibleCustomerReadRequest.EmailAddress = "Offshore12130@test.lifestylegroup.co.uk";
				//
				// DigitalHubModel.Eligiblecustomeremail.clsEligibleCustomerEmail Request = assurantApp.EligibleCustomerEmailResource;
				// Request.SetResponseHandler (new TJResponseHandlerCreate (outerInstance));
				// Request.SetProgressHandler (new TJProgressHandlerCreate (outerInstance));
				// DigitalHubModel.Onetimepassword.Model.OneTimePassword_OneTimePassword_CREATE_REQUEST OnePasswordValidate = new DigitalHubModel.Onetimepassword.Model.OneTimePassword_OneTimePassword_CREATE_REQUEST ();
				// OnePasswordValidate.Reference = custID;
				// //OnePasswordValidate.Authorization = token;
				// OnePasswordValidate.Company = "halifax";
				// OnePasswordValidate.ID = userid;
				//
				// DigitalHubModel.Onetimepassword.Model.OneTimePassword_OneTimePassword_CREATE_endpoint_REQUEST endPointRequest = new DigitalHubModel.Onetimepassword.Model.OneTimePassword_OneTimePassword_CREATE_endpoint_REQUEST ();
				// endPointRequest.Channel = "email";
				// endPointRequest.Destination = userid;
				// endPointRequest.TemplateCode = "forgotten_password";
				// OnePasswordValidate.Endpoint = endPointRequest;
				//
				// DigitalHubModel.Onetimepassword.clsOneTimePassword OneTimePassword = assurantApp.OneTimePasswordResource;
				// OneTimePassword.SetProgressHandler (new TJProgressHandlerCreate (this));
				// OneTimePassword.SetResponseHandler (new TJResponseHandlerCreate (this));
				// OneTimePassword.Create (OnePasswordValidate);
				//Request.Read (EligibleCustomerReadRequest);

				outerInstance.showLoginDialog();
			}
		}

		private void showLoginDialog()
		{

			// userNameEdtTxt = new EditText(this);
			// userNameEdtTxt.Hint = "Username";
			//
			// passwordEdtTxt = new EditText(this);
			// passwordEdtTxt.Hint = "Password";
			// passwordEdtTxt.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextVariationPassword;
			//
			// LinearLayout loginLayout = new LinearLayout(this);
			// LinearLayout.LayoutParams params1 = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
			// loginLayout.LayoutParameters = params1;
			// //loginLayout.Orientation = LinearLayout.;
			// loginLayout.AddView(userNameEdtTxt);
			// loginLayout.AddView(passwordEdtTxt);
			//
			// AlertDialog.Builder alertdialog = new AlertDialog.Builder (this);
			// alertdialog.SetTitle (Resource.String.app_name);
			// alertdialog.SetIcon (Resource.Drawable.Assurant);
			// alertdialog.SetView (loginLayout);
			//
			// alertdialog.SetPositiveButton (Android.Resource.String.Ok, (EventHandler<DialogClickEventArgs>)null);
			// alertdialog.SetNegativeButton (Android.Resource.String.Cancel, (EventHandler<DialogClickEventArgs>)null);
			//
			// //alertdialog.SetNegativeButton (Android.Resource.String.Cancel, new OnClickListenerAnonymousInnerClassHelper (this));
			// //alertdialog.SetPositiveButton(Android.Resource.String.Ok, new OnClickListenerAnonymousInnerClassHelper2(this, userNameEdtTxt, passwordEdtTxt));
			//
			// alert = alertdialog.Create();
			// //alert.Show();
			//
			// _dialogPositiveButton = alert.GetButton ((int)DialogButtonType.Positive);
			// _dialogNegativeButton = alert.GetButton ((int)DialogButtonType.Negative);
			//
			// _dialogPositiveButton.Click += HandleDialogPositiveButtonClick;
			// _dialogNegativeButton.Click += HandleDialogNegativeButtonClick;
			authenticateUsernameAndPassword ("", "");
		}

		private void HandleDialogPositiveButtonClick (object sender, EventArgs e) 
		{
			Appmodel.AssurantDigitalHub assurantApp = new Appmodel.AssurantDigitalHub(this);
			if (userNameEdtTxt.Text != null && !userNameEdtTxt.Text.ToString().Equals("") && passwordEdtTxt.Text != null && !passwordEdtTxt.Text.ToString().Equals(""))
			{
				alert.Dismiss();
				authenticateUsernameAndPassword(userNameEdtTxt.Text.ToString(), passwordEdtTxt.Text.ToString());
			}
			else
			{

				Toast.MakeText(mContext, "All fields are mandatory", ToastLength.Long).Show();
			}
		}
		private void HandleDialogNegativeButtonClick (object sender, EventArgs e)
		{
			DismissDialog ();

		}
		private void DismissDialog () 
		{
			_dialogPositiveButton.Click -= HandleDialogPositiveButtonClick;
			_dialogNegativeButton.Click -= HandleDialogNegativeButtonClick;
			alert.Dismiss ();
		}

		private void authenticateUsernameAndPassword(string userName, string userPassword)
		{

			//bool userAuthenticated = false;
			Appmodel.AssurantDigitalHub assurantApp = new Appmodel.AssurantDigitalHub (this);
			try
			{
				//Appmodel.AssurantDigitalHub assurantApp = new Appmodel.AssurantDigitalHub(this);
				//Eligiblecustomeremail

				//clientSDKHelper.AuthenticateUser(userName, userPassword,new ProgressDialog(this),  new TJResponseHandlerAuthenticateUsers(this));
				DigitalHubModel.Integratedlogin.Model.Request.AssurantLogin_CREATE LoginCreateRequest = new DigitalHubModel.Integratedlogin.Model.Request.AssurantLogin_CREATE();
				//
				// LoginCreateRequest.Company = "halifax";
				// LoginCreateRequest.ID = "halifax";
				//
				// //localDBUserRequest.COMPANY_NAME = "dev";
				//

				LoginCreateRequest.Channel = "app";
				// //LoginCreateRequest.Password ="TruJunction@01";
				// //LoginCreateRequest.Username = "Sally.Neesom@dev.lifestylegroup.co.uk";
				// //LoginCreateRequest.Password ="Trujunction@15";
				LoginCreateRequest.Password ="Tester12!";
				//
				//LoginCreateRequest.Password ="jdflsjl!";
				// LoginCreateRequest.Password ="Password!1";
				//LoginCreateRequest.Username = "Offshore170@test.lifestylegroup.co.uk";
				//LoginCreateRequest.Username = "Offshore12130@test.lifestylegroup.co.uk";
				//LoginCreateRequest.Username = "Offshore12130@test.lifestylegroup.co.uk";
				//LoginCreateRequest.Username = "Benjamin.Cole@dev.lifestylegroup.co.uk";
				//LoginCreateRequest.Username = "Henry.Goddard@dev.lifestylegroup.co.uk";
				//LoginCreateRequest.Username = "Zach.OBrien@dev.lifestylegroup.co.uk";
				//LoginCreateRequest.Username = "Amber.Price@dev.lifestylegroup.co.uk";
				//LoginCreateRequest.Username = "Amber.Price@dev.lifestylegroup.co.uk";
				LoginCreateRequest.Username = "Andrew.Norton@dev.lifestylegroup.co.uk";
			
				//LoginCreateRequest.Username = "hemal2008@test.lifestylegroup.co.uk";

				//
				//LoginCreateRequest.Username = " fjdkslfl @dev.lifestylegroup.co.uk";

				// LoginCreateRequest.Username = "Offshore160@test.lifestylegroup.co.uk";
				//// //userID = "Offshore12130@test.lifestylegroup.co.uk";
				userID = LoginCreateRequest.Username;
				// clientSDKHelper.AuthenticateUser(LoginCreateRequest,"IntegratedLogin",null,new TJResponseHandlerAuthenticateUsers(this));
				//    
				string strTOken= string.Empty;
				ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences (mContext);

				strTOken = prefs.GetString ("Token","");
//				if(string.IsNullOrEmpty(strTOken))
//				{
				DigitalHubModel.Integratedlogin.clsIntegratedLogin obj = new DigitalHubModel.Integratedlogin.clsIntegratedLogin();


				//
//				clientSDKHelper.AuthenticateUser(LoginCreateRequest, "IntegratedLogin" ,new ProgressDialog(this),  new TJResponseHandlerAuthenticateUsers(this) ,"gfdghghjk@dev.lifestylegroup.co.uk","ghjhkhkh!", (Java.Lang.Long)(DigitalHubModel.Integratedlogin.clsIntegratedLogin.OrchestrationId));
//
//
				clientSDKHelper.AuthenticateUser(LoginCreateRequest, "IntegratedLogin" ,new ProgressDialog(this),  new TJResponseHandlerAuthenticateUsers(this) ,"Andrew.Norton@dev.lifestylegroup.co.uk","Tester12!", (Java.Lang.Long)(DigitalHubModel.Integratedlogin.clsIntegratedLogin.OrchestrationId));
				
				
//				}
//				else
//				{
//					custID = "73548765868";
//					openHomeActivity();
//				}

			}
			catch (Exception e)
			{

				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}

		}
		private class TJResponseHandlerInitilizeSDKHandler :Java.Lang.Object, TJResponseHandler
		{
			private readonly LoginActivity outerInstance;

			public TJResponseHandlerInitilizeSDKHandler(LoginActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public void OnSuccess(Java.Lang.Object responseObject)
			{

				Log.I(outerInstance.TAG, "initializeSDK - onSuccess","","");

//				// Retrieving data from existing table
//				IDictionary<string,SyncUtils.CLASSTYPE> colums = new Dictionary<string,SyncUtils.CLASSTYPE>();
//				colums.Add ("username", SyncUtils.CLASSTYPE.String);
//				colums.Add ("password",SyncUtils.CLASSTYPE.String);
//				colums.Add ("login_attempt",SyncUtils.CLASSTYPE.Int);
//
//				GenericDBManager gb = new GenericDBManager (outerInstance, "UserStorageDB", colums,new TjHandler(outerInstance));
//				gb.CreateTable ();
//				string query = "login_attempt=?";
//				string[] values = new string[] {
//					"1"
//				};
//
//				ContentValues Cv = new ContentValues ();
//				Cv.Put ("username", "brahmam");
//				Cv.Put ("password", "brahmam");
//				Cv.Put ("login_attempt", 1);
//
//				ContentValues Cobj = new ContentValues ();
//				Cobj.Put ("username", "record");
//				Cobj.Put ("password", "record");
//				Cobj.Put ("login_attempt", 2);
//				long count;
//
//
//				gb.InsertValues (Cv);
//
//
//
//				ContentValues Cvobj = new ContentValues ();
//				Cvobj.Put ("username", "test");
//				Cvobj.Put ("password", "test");
//				Cvobj.Put ("login_attempt", 1);
//
//				query = "login_attempt=?";
//				// string[] values = new string[] {
//				// "1"
//				// };
//				gb.UpdateValues(Cvobj,query,values);
//
//				//
//				gb.Select (null, null);
//				gb.DeleteValues (query, values);

				IDictionary<string,Java.Lang.Class> colums = new Dictionary<string,Java.Lang.Class>();
				colums.Add ("username", Java.Lang.Class.FromType(typeof (Java.Lang.String)));
				colums.Add ("password",Java.Lang.Class.FromType(typeof (Java.Lang.String)));
				colums.Add ("login_attempt",Java.Lang.Class.FromType( typeof( Java.Lang.Integer)));

				GenericDBManager gb = new GenericDBManager (outerInstance, "UserStorageDB", colums);
				gb.CreateTable ();
				string query = "login_attempt=?";
				string[] values = new string[] {
					"1"
				};
				string strUserName;
				//Select is working in both following cases 
				//select with query,values
//				IList<JSONObject> jsonObj = gb.Select(query, values);
//				string strUserName;
//				foreach (JSONObject obj in jsonObj) {
//					strUserName = obj.GetString ("username");
//				}
//				//Select with null,null
//				jsonObj = gb.Select (null, null);
//				foreach (JSONObject jsnObj in jsonObj) {
//					strUserName = jsnObj.GetString ("username");
//				}
				IList<JSONObject> jsonObj=null;
				ContentValues Cv = new ContentValues ();
				Cv.Put ("username", "brahmam");
				Cv.Put ("password", "brahmam");
				Cv.Put ("login_attempt", 1);

				ContentValues Cobj = new ContentValues ();
				Cobj.Put ("username", "record");
				Cobj.Put ("password", "record");
				Cobj.Put ("login_attempt", 2);
				long count;


				count=	gb.InsertValues (Cv);

				count = gb.InsertValues (Cobj);

				jsonObj = gb.Select(query, values);
				foreach (JSONObject obj in jsonObj) {
					strUserName = obj.GetString ("username");
				}

				ContentValues Cvobj = new ContentValues ();
				Cvobj.Put ("username", "test");
				Cvobj.Put ("password", "test");
				Cvobj.Put ("login_attempt", 1);
				count = gb.UpdateValues(Cvobj,query,values);

				jsonObj = gb.Select (null, null);

				count = gb.DeleteValues (query, values);

				jsonObj = gb.Select (null, null);
				//count = 2;

				string responseStr = responseObject.ToString();
				Toast.MakeText(outerInstance, responseStr, ToastLength.Long).Show();

				outerInstance.startLoginProcess();
			}

			public void OnError(Entity error)
			{
				Log.I(outerInstance.TAG, "initializeSDK - onError","","");
				outerInstance.openErrorActivity(error);
			}

		}
		private class TJResponseHandlerAuthenticateUsers : Java.Lang.Object, TJResponseHandler
		{
			private readonly LoginActivity outerInstance;

			public TJResponseHandlerAuthenticateUsers(LoginActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}


			public void OnSuccess(Java.Lang.Object responseObject)
			{
				DigitalHubModel.Integratedlogin.Model.Response.AssurantLogin_CREATE responseObj = responseObject.JavaCast<DigitalHubModel.Integratedlogin.Model.Response.AssurantLogin_CREATE> ();
				ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences (outerInstance.mContext);
				tokenObj = responseObj.Token;
				ISharedPreferencesEditor editor = prefs.Edit ();
				editor.PutString ("Token", tokenObj);
				editor.Commit ();
				custID = responseObj.CustID;

				outerInstance.openHomeActivity();

				// IDictionary<string, string> dict = responseObj.HttpResponseHeaders;
				// foreach (KeyValuePair<string, string> pair in dict)
				// {
				// Console.WriteLine("{0}, {1}",
				// pair.Key,
				// pair.Value);
				// }
			}

			public void OnError(Entity error)
			{

				TJError tjError = error.JavaCast<TJError>();

				IList<TJError.ProxyObject> testlist = new List<TJError.ProxyObject>();


				testlist = tjError.Proxy_object;

				if (testlist.Count > 0) {
					Toast.MakeText (outerInstance.mContext, testlist [0].HttpStatusCode + testlist [0].ServiceIdentifier, ToastLength.Short).Show (); 
				}
				outerInstance.openErrorActivity(tjError);
			}
		}
		private class TJResponseHandlerCreate :Java.Lang.Object, TJResponseHandler
		{
			private readonly LoginActivity outerInstance;

			public TJResponseHandlerCreate(LoginActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}


			public void OnSuccess(Java.Lang.Object createResponse)
			{
				// appmodels.OrchBreakDownCREATE_BreakDown_CREATE_RESPONSE response = createResponse.JavaCast<appmodels.OrchBreakDownCREATE_BreakDown_CREATE_RESPONSE> ();
				//DigitalHubModel.Eligiblecustomer.Model.EligibleCustomer_EligibleCustomerService_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Eligiblecustomer.Model.EligibleCustomer_EligibleCustomerService_READ_RESPONSE> ();
				//DigitalHubModel.Formdefinitions.Model.FormDefinitions_FormsDefinition_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Formdefinitions.Model.FormDefinitions_FormsDefinition_READ_RESPONSE>();
				// DigitalHubModel.Onetimepassword.Model.OneTimePassword_OneTimePasswordValidate_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Onetimepassword.Model.OneTimePassword_OneTimePasswordValidate_READ_RESPONSE> ();
				//DigitalHubModel.Onetimepassword.Model.OneTimePassword_OneTimePassword_CREATE_RESPONSE reponse = createResponse.JavaCast<DigitalHubModel.Onetimepassword.Model.OneTimePassword_OneTimePassword_CREATE_RESPONSE> (); 

				//==========================================================================================================================================================================================================================================================
				//
//				DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_RESPONSE> ();
//				//
//				DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_address_RESPONSE addressResponse = response.Address.JavaCast<DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_address_RESPONSE>();
//				//
//				DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_security_questions_RESPONSE secQuesResponse = response.SecurityQuestions.JavaCast<DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_security_questions_RESPONSE> ();
//				//
//				if (secQuesResponse != null) {
//					//
//					DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_security_questions_security_question_one_RESPONSE secQuesResponse1 = response.SecurityQuestions.SecurityQuestionOne.JavaCast<DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_security_questions_security_question_one_RESPONSE> ();
//					//
//					DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_security_questions_security_question_two_RESPONSE secQuesResponse2 = response.SecurityQuestions.SecurityQuestionTwo.JavaCast<DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_security_questions_security_question_two_RESPONSE> ();
//					//
//					string code1 = secQuesResponse1.SecurityQuestionCode;
//					//
//					string amswer1 = secQuesResponse1.SecurityAnswer;
//					//
//					//
//					string code2 = secQuesResponse2.SecurityQuestionCode;
//					//
//					string answer2 = secQuesResponse2.SecurityAnswer;
//					//
//				}
				//
//				string postalcode = addressResponse.Postalcode;
//				//
//				string countrycode = addressResponse.CountryCode;
//				//
//				string line1 = addressResponse.Line1;
//				//
//				string line2 = addressResponse.Line2;
//				//
//				string line3 = addressResponse.Line3;
//				//
//				string line4 = addressResponse.Line4;
//				//

				//

				//


				//
//				string sortcode = response.Sortcode;
//				//
//				string firstname = response.Forename;
//
//				//==========================================================================================================================================================================================================================================================
//
//				//DigitalHubModel.Emailphoneupdate.Model.EmailPhoneUpdate_CustomerUpdate_UPDATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Emailphoneupdate.Model.EmailPhoneUpdate_CustomerUpdate_UPDATE_RESPONSE> ();
//
//				//DigitalHubModel.Formdefinitionscardetailsread.Model.OrchFormDefinitionsCarDetailsREAD_FormDefinitionsCarDetails_READ_RESPONSE carResponse = createResponse.JavaCast<DigitalHubModel.Formdefinitionscardetailsread.Model.OrchFormDefinitionsCarDetailsREAD_FormDefinitionsCarDetails_READ_RESPONSE> ();
//				//DigitalHubModel.Cardetailsformpostcreate.Model.OrchCarDetailsFormPostCREATE_CarDetailsFormPost_CREATE_RESPONSE carCreateResponse = createResponse.JavaCast<DigitalHubModel.Cardetailsformpostcreate.Model.OrchCarDetailsFormPostCREATE_CarDetailsFormPost_CREATE_RESPONSE> ();
//
//				//DigitalHubModel.Createmessagecreate.Model.OrchCreateMessageCREATE_CreateMessage_CREATE_RESPONSE createMessageResponse = createResponse.JavaCast<DigitalHubModel.Createmessagecreate.Model.OrchCreateMessageCREATE_CreateMessage_CREATE_RESPONSE> ();
//				//
//				DigitalHubModel.Getmessagesread.Model.OrchGetMessagesREAD_GetMessages_READ_RESPONSE getMessageResponse = createResponse.JavaCast<DigitalHubModel.Getmessagesread.Model.OrchGetMessagesREAD_GetMessages_READ_RESPONSE> ();
				//DigitalHubModel.Getmessagewithidread.Model.OrchGetMessageWithIDREAD_GetMessageWithID_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Getmessagewithidread.Model.OrchGetMessageWithIDREAD_GetMessageWithID_READ_RESPONSE> (); 
				//DigitalHubModel.Messagesmiscellaneousupdate.Model.OrchMessagesMiscellaneousUPDATE_MessagesMiscellaneous_UPDATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Messagesmiscellaneousupdate.Model.OrchMessagesMiscellaneousUPDATE_MessagesMiscellaneous_UPDATE_RESPONSE> ();



				//DigitalHubModel.Customer.Model.Customer_GetCustom_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Customer.Model.Customer_GetCustom_READ_RESPONSE> ();
				//DigitalHubModel.Getcustomerwithquery.Model.GetCustomerWithQuery_GetCustomer_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Getcustomerwithquery.Model.GetCustomerWithQuery_GetCustomer_READ_RESPONSE> ();
				//DigitalHubModel.Customermiscellaneous.Model.CustomerMiscellaneous_CustomerMiscellaneous_CREATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Customermiscellaneous.Model.CustomerMiscellaneous_CustomerMiscellaneous_CREATE_RESPONSE> ();
				//DigitalHubModel.Formdefinitionname.Model.FormDefinitionName_FormDefinitionName_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Formdefinitionname.Model.FormDefinitionName_FormDefinitionName_READ_RESPONSE> ();
				//DigitalHubModel.

				//string one = response.
				//DigitalHubModel.Getform.Model.GetForm_FormsGetForm_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Getform.Model.GetForm_FormsGetForm_READ_RESPONSE> ();
				//DigitalHubModel.Formspost.Model.FormsPost_FormsPost_CREATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Formspost.Model.FormsPost_FormsPost_CREATE_RESPONSE> ();
				//DigitalHubModel.Formupdate.Model.FormUpdate_FormsUpdate_UPDATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Formupdate.Model.FormUpdate_FormsUpdate_UPDATE_RESPONSE> ();
				//DigitalHubModel.Eligiblecustomeremail.Model.EligibleCustomerEmail_EligibleCustomerEmail_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Eligiblecustomeremail.Model.EligibleCustomerEmail_EligibleCustomerEmail_READ_RESPONSE> ();
				//DigitalHubModel.Customercreate.Model.CustomerCreate_CustomerCreate_CREATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Customercreate.Model.CustomerCreate_CustomerCreate_CREATE_RESPONSE> ();
				//DigitalHubModel.Login.Model.Login_Login_CREATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Login.Model.Login_Login_CREATE_RESPONSE> ();
				//DigitalHubModel.Logoutcreate.Model.OrchLogOutCREATE_LogOut_CREATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Logoutcreate.Model.OrchLogOutCREATE_LogOut_CREATE_RESPONSE> ();
				//DigitalHubModel.Validatetokencreate.Model.OrchValidateTokenCREATE_ValidateToken_CREATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Validatetokencreate.Model.OrchValidateTokenCREATE_ValidateToken_CREATE_RESPONSE> ();
				//Toast.MakeText (outerInstance, response.DateOfBirth, ToastLength.Long).Show ();
				//DigitalHubModel.Samlread.Model.OrchSAMLREAD_SAML_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Samlread.Model.OrchSAMLREAD_SAML_READ_RESPONSE> ();
				//DigitalHubModel.Createmessagecreate.Model.OrchCreateMessageCREATE_CreateMessage_CREATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Createmessagecreate.Model.OrchCreateMessageCREATE_CreateMessage_CREATE_RESPONSE> ();
				//DigitalHubModel.Getmessagesread.Model.OrchGetMessagesREAD_GetMessages_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Getmessagesread.Model.OrchGetMessagesREAD_GetMessages_READ_RESPONSE> (); 

				//DigitalHubModel.Shasignread.Model.OrchSHASignREAD_SHASign_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Shasignread.Model.OrchSHASignREAD_SHASign_READ_RESPONSE> ();



				//DigitalHubModel.Formscollection.Model.FormsCollection_FormCollections_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Formscollection.Model.FormsCollection_FormCollections_READ_RESPONSE> ();
				//List<DigitalHubModel.Formscollection.Model.FormsCollection_FormCollections_READ_formlinks_RESPONSE> linkResponse = response.Formlinks.JavaCast<DigitalHubModel.Formscollection.Model.FormsCollection_FormCollections_READ_formlinks_RESPONSE>();




				//response.Formlinks = 
				//response.Formlinks = response.ToArray<DigitalHubModel.Formscollection.Model.FormsCollection_FormCollections_READ_formlinks_RESPONSE> ();

				//
				List<object> ol = new List<object> ();
//				//
//				ol.Add (linkResponse);
//				//
//				response.Formlinks = ol;
//
//				//string formDefination = linkResponse.Formdefinition;
//				//string hrefObj = linkResponse.Href;
//
//
//				//==========================================================================================================================================================================================================================================================
//
//
//				//Toast.MakeText(outerInstance, response.Getprop_question1, ToastLength.Long).Show();
//				//   
//				//
//				Console.WriteLine("Breakdown Call Success","Result is - " + response.Getprop_question1 + "");
//				//
//				//
//				Log.I("Breakdown Call Success","Result is - " + response.Getprop_question1 + "","","");

				//outerInstance.Finish();

			}
			public void OnError(Entity errorObj)
			{
				TJError tjError = errorObj.JavaCast<TJError>();
				string errorStr = tjError.ErrorCode + "-" + tjError.ErrorMessage;
				//string error = tjError.ToString ();
				//
				Toast.MakeText(outerInstance, errorStr, ToastLength.Long).Show();
				//
				outerInstance.Finish();
			}
		}
		private class TJProgressHandlerCreate :Java.Lang.Object, TJProgressHandler
		{
			private readonly LoginActivity outerInstance;

			public TJProgressHandlerCreate(LoginActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public void SetUpProgress()
			{
				outerInstance.progressDialog.SetMessage("Processing");
				outerInstance.progressDialog.SetCancelable (false);
				outerInstance.progressDialog.Show();
			}

			public void SetProgressPercent(string[] value)
			{
				outerInstance.progressDialog.SetMessage ("Progressing..");
			}

			public void DismissProgress()
			{
				if (outerInstance.progressDialog.IsShowing)
				{
					outerInstance.progressDialog.Dismiss ();
				}
			}
		}

		public class TjHandler:Java.Lang.Object,ITJDBHandler
		{
			private readonly LoginActivity outerInstance;

			public TjHandler(LoginActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}
			public void DbOperSuccess(int p0, Java.Lang.Object obj)
			{
				if (obj != null && obj.GetType().ToString()!="Java.Lang.Long" && obj.GetType().ToString()!="Java.Lang.Integer") {
					Java.Util.ArrayList lstJsonObj = (Java.Util.ArrayList)obj;
					for (int i=0;i<lstJsonObj.Size();i++) {
						JSONObject castedJObj = (JSONObject) lstJsonObj.Get(i);
						string str=	castedJObj.GetString ("username");
					}
				}
				Log.I ("DB Oper", "Success " + p0);
			}

			public void DbOperFailure(int p0)
			{
				Log.I ("DB Oper", "Failure " + p0);
			}

			public void Dispose()
			{
				
			}
		}

		private void openHomeActivity()
		{

			Log.I(TAG, "openHomeActivity","","");

			Intent homeIntent = new Intent(mContext, typeof(HomeActivity));
			homeIntent.PutExtra ("token",tokenObj);
			homeIntent.PutExtra ("userID",userID);
			homeIntent.PutExtra ("custID",custID);
			StartActivity(homeIntent);
		}
		private void openErrorActivity(Entity error)
		{

			TJError tjError = error.JavaCast<TJError>();

			Intent errorIntent = new Intent(mContext, typeof(MessageActivity));

			if (tjError.ErrorCode != null)
			{
				errorIntent.PutExtra("Message", tjError.ErrorCode);
			}
			else
			{
				errorIntent.PutExtra("Message", "Uncaught Exception");
			}

			errorIntent.PutExtra("LocalizedMessage", tjError.ErrorMessage);
			errorIntent.PutExtra("InvokedBy", INVOKED_BY_SDK_INIT_ERROR);

			mContext.StartActivity(errorIntent);
		}

	}
}

