using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using Appmodel;
using ClientSDKHelper = Com.Cognizant.Trumobi.Appintegration.Clientsdk.Core.ClientSDKHelper;
using Entity = Com.Cognizant.Trumobi.Appintegration.Clientsdk.DB.Entity;
using TJError = Com.Cognizant.Trumobi.Appintegration.Clientsdk.Exception.TJError;
using TJResponseHandler = Com.Cognizant.Trumobi.Appintegration.Clientsdk.Handlers.ITJResponseHandler;
using ClientSdkConfiguration = Com.Cognizant.Trumobi.Appintegration.Clientsdk.Core.ClientSdkConfiguration;//179535 Mobfeb15
using Log = Com.Cognizant.Trumobi.Appintegration.Clientsdk.Util.Log;
using TJProgressHandler = Com.Cognizant.Trumobi.Appintegration.Clientsdk.Handlers.ITJProgressHandler;
//using appmodel = Appmodel.DigitalHub;
//using appmodels = Appmodel.Orchestration.Breakdowncreate.Model;
using NetworkType = Com.Cognizant.Trumobi.Appintegration.Clientsdk.Context.SyncContext.NetworkType;
using DigitalHubModel = Appmodel.Orchestration;
//using breakdownCallCreate = Appmodel.Orchestration.Breakdowncreate.clsBreakdownCreate;//.clsBreakdownCreate;
//using eligibleCust = Appmodel.Orchestration.Eligiblecustomer.clsEligibleCustomer;//.clsEligibleCustomer;
using Com.Cognizant.Trumobi.Appintegration.Clientsdk.Core;
using System.Collections.Generic;
using System.Linq;
//using Appmodel = Appmo
using System.Collections;
using Android.Preferences;

namespace AssurantApplication
{
	[Activity (Label = "AssurantApplication", MainLauncher = false)]
	public class HomeActivity : Activity
	{

		//Appmodel.DigitalHub assurantApp;

		ClientSDKHelper clientSDKHelper;
		ProgressDialog progressDialog;
		public string token = string.Empty;
		public string userid = string.Empty;
		public string custID = string.Empty;
		String strEPSType = string.Empty;
		string strFormID = string.Empty;
		internal Context mContext;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Home);
			clientSDKHelper = ClientSDKHelper.GetInstance(this);
			mContext = this;
		
			Appmodel.AssurantDigitalHub assurantApp = new Appmodel.AssurantDigitalHub(this);
			//Appmodel.DigitalHub = new Appmodel.DigitalHub()
			//Appmodel.DigitalHub 
			//Appmodel.AssurantDigitalHub assurantApp = new Appmodel.AssurantDigitalHub(this);
			//assurantApp = new Appmodel.DigitalHub(this);

			//SecurityUtil.Encrypt (this.ApplicationContext.Assets.Open("MetaJSON.txt"));
			//Console.WriteLine ();
			//DigitalHubModel.Integratedlogin.Model.IntegratedLogin_AssurantLogin_CREATE_RESPONSE loginResponse = new DigitalHubModel.Integratedlogin.Model.IntegratedLogin_AssurantLogin_CREATE_RESPONSE ();
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences (mContext);
			token= prefs.GetString("Token","");
			//token = Intent.GetStringExtra ("token");
			userid = Intent.GetStringExtra ("userID");
			custID = Intent.GetStringExtra ("custID");
			progressDialog = new ProgressDialog(this);
			Button syncBtn = FindViewById<Button> (Resource.Id.Sync);
			syncBtn.Click += delegate {
				assurantApp.Sync ();		
			};

			Button btnBreakDownInfo = FindViewById<Button> (Resource.Id.btnBreakDownInfo);
			btnBreakDownInfo.Click+= delegate {
				RequestBreakDownInfo(assurantApp);
			};
//
			Button btnEligibleCustomer = FindViewById<Button> (Resource.Id.btnEligibleCustomer);
			btnEligibleCustomer.Click += delegate {
				RequestEligableCustomer (assurantApp);
			};
//
			Button btnEligibleCustomerEmail = FindViewById<Button> (Resource.Id.btnEligibleCustomerEmail);
			btnEligibleCustomerEmail.Click+= delegate {
				RequestEligibleCustomerEmail(assurantApp);
			};
			Button btnOTPCreate = FindViewById<Button> (Resource.Id.btnOTPCreate);
			btnOTPCreate.Click+= delegate {
				RequestOTPCreate(assurantApp);
			};
			Button btnOTPValidate = FindViewById<Button> (Resource.Id.btnOTPValidate);
			btnOTPValidate.Click+= delegate {
				RequestOTPValidate(assurantApp);
			};
			Button btnFormDefinitions = FindViewById<Button> (Resource.Id.btnFormDefinitions);
			btnFormDefinitions.Click += delegate {
				RequestFormDefinitions(assurantApp);
			};
		    Button btnFormDefinitionName = FindViewById<Button>(Resource.Id.btnFormDefinitionName);

			btnFormDefinitionName.Click += delegate {
				RequestFormDefinitionName(assurantApp);
			};

			Button btnFormCollecction = FindViewById<Button> (Resource.Id.btnFormCollection);

			btnFormCollecction.Click+= delegate {
				RequestFormCollecction(assurantApp);
			};

			Button btnFormPost = FindViewById<Button>(Resource.Id.btnFormPost);

			btnFormPost.Click+= delegate {
				RequestFormPost(assurantApp);
			};

			Button btnGetForm = FindViewById<Button> (Resource.Id.btnGetForm);

			btnGetForm.Click+= delegate {
				RequestGetForm(assurantApp);
			};

			Button btnFormUpdate = FindViewById<Button> (Resource.Id.btnFormUpdate);

			btnFormUpdate.Click+= delegate {
				RequestFormUpdate(assurantApp);
			};

			Button btnFormDelete = FindViewById<Button> (Resource.Id.btnFormDelete);

			btnFormDelete.Click+= delegate {
				RequestFormDelete(assurantApp);
			};

			Button btnCreateCustomer = FindViewById<Button> (Resource.Id.btnCreateCustomer);

			btnCreateCustomer.Click+= delegate {
				RequestCreateCustomer(assurantApp);
			};
//
			Button btnGetCutomerWithID = FindViewById<Button> (Resource.Id.btnCustomerWithID);

			btnGetCutomerWithID.Click+= delegate {
				RequestGetCustomerWithID(assurantApp);
			};
//
			Button btnGetCustomerWithQuery = FindViewById<Button> (Resource.Id.btnGetCustomerWithQuery);

			btnGetCustomerWithQuery.Click += delegate {
				RequestGetCustomerWithQuery (assurantApp);
			};
//
			Button btnEmailPhoneUpdate = FindViewById<Button> (Resource.Id.btnEmailPhoneUpdate);

			btnEmailPhoneUpdate.Click+= delegate {
				RequestEmailPhoneUpdate(assurantApp);
			};
//	        
			Button btnCustomerMiscellaneous = FindViewById<Button> (Resource.Id.btnCustomerMiscellaneouns);

			btnCustomerMiscellaneous.Click+= delegate {
				RequestCustomerMiscellaneous(assurantApp);
			};
//
			Button btnLogOutCreate = FindViewById<Button> (Resource.Id.btnLogOutCreate);
			btnLogOutCreate.Click+= delegate {
				RequestLogoutCreate(assurantApp);
			};
//
			Button btnValidateTokenCreate = FindViewById<Button> (Resource.Id.btnValidateTokenCreate);
			btnValidateTokenCreate.Click+= delegate {
				RequestValidateCreateToken(assurantApp);
			};
//
			Button btnSAML = FindViewById<Button> (Resource.Id.btnSAML);
			btnSAML.Click+= delegate {
				RequestSAML(assurantApp);
			};
			Button btnCreateMessage = FindViewById<Button> (Resource.Id.btnCreateMessage);
			btnCreateMessage.Click+= delegate {
				RequestCreateMessage(assurantApp);
			};

			Button btnEligibleCustomerUpdate = FindViewById<Button> (Resource.Id.btnEligibleCustomerUpdate);
			btnEligibleCustomerUpdate.Click+= delegate {
				RequestEligibleCustomerUpdate(assurantApp);
			};
			Button btnGetMessage = FindViewById<Button> (Resource.Id.btnGetMessage);
			btnGetMessage.Click+= delegate {
				RequestGetMessage(assurantApp);
			};
			Button btnShasignread = FindViewById<Button> (Resource.Id.btnShasignRead);
			btnShasignread.Click+= delegate {
				//RequestShasignRead(assurantApp);
				RequestCarDeatilsGet (assurantApp);

			};
			//RequestCarDeatilsGet (assurantApp);


//		    


			//			//Logincreate
			//			DigitalHubModel.Login.Model.Login_Login_CREATE_REQUEST LoginCreateRequest = new DigitalHubModel.Login.Model.Login_Login_CREATE_REQUEST ();
			//			DigitalHubModel.Login.Model.Login_LocalDBUser_CREATE_REQUEST localDBUserRequest = new DigitalHubModel.Login.Model.Login_LocalDBUser_CREATE_REQUEST ();
			//
			//			//LoginCreateRequest.Authorization = "Huzzle 78fd5c3d-c8ac-4f5c-8e37-5b61ca0c7d0b.c7ef6bb2c5460d9dc54784f23455bb1b";
			//			LoginCreateRequest.Company = "halifax";
			//			LoginCreateRequest.ID = "halifax";
			//
			//			localDBUserRequest.COMPANY_NAME = "dev";
			//
			//			LoginCreateRequest.Channel = "app";
			//			LoginCreateRequest.Password ="TruJunction@01";
			//			LoginCreateRequest.Username ="Sally.Neesom@dev.lifestylegroup.co.uk";
			//
			//			DigitalHubModel.Login.clsLogIn Request = assurantApp.LoginResource;
			//			Request.SetResponseHandler (new TJResponseHandlerCreate (this));
			//			Request.SetProgressHandler (new TJProgressHandlerCreate (this));
			//			Request.Create (LoginCreateRequest);






			//=============================================================================================================================================
						//GetMessageWithID
//						DigitalHubModel..Getmessagewithidread.Model.OrchGetMessageWithIDREAD_GetMessageWithID_READ_REQUEST readMsgRqstwthID= new DigitalHubModel.Getmessagewithidread.Model.OrchGetMessageWithIDREAD_GetMessageWithID_READ_REQUEST ();
//						readMsgRqstwthID.Authorization = token; //"Huzzle 14dec742-77a0-46d2-90f6-bdd88735f826.a040a22611d0c3e2de909ecdaae28da8";
//						readMsgRqstwthID.Company = "halifax";
//						readMsgRqstwthID.ID = userid;//"johnnycrappleseed@ex";
//						readMsgRqstwthID.CustomerID = custID; //"63548728028";
//						readMsgRqstwthID.MessageID = "465987B7-3144-4DF4-9101-C0FEC075EB39";
//			
//						DigitalHubModel.Getmessagewithidread.clsMessageWithIDREAD Request = assurantApp.GetMessageWithIDREADResource;
//						Request.SetResponseHandler(new TJResponseHandlerCreate(this));
//						Request.SetProgressHandler(new TJProgressHandlerCreate(this));
//						Request.Read(readMsgRqstwthID);


			//=============================================================================================================================================
		


		}

		private class TJResponseHandlerCreate :Java.Lang.Object, TJResponseHandler
		{
			private readonly HomeActivity outerInstance;

			public TJResponseHandlerCreate(HomeActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}


			public void OnSuccess(Java.Lang.Object createResponse)
			{

				if (outerInstance.strEPSType == EPSType.BreakDownCreate.ToString ()) {
					DigitalHubModel.Breakdowncreate.Model.Response.BreakDown_CREATE breakDownCreateResponse = createResponse.JavaCast<DigitalHubModel.Breakdowncreate.Model.Response.BreakDown_CREATE> ();				
					IDictionary<string, string> dict = breakDownCreateResponse.HttpResponseHeaders;
					foreach (KeyValuePair<string, string> pair in dict) {
						Console.WriteLine ("{0}, {1}",
							pair.Key,
							pair.Value);
					}
				}
//					if (outerInstance.strEPSType == EPSType.EligibleCustomer.ToString ()) {
//						DigitalHubModel.Eligiblecustomer.Model.Response.EligibleCustomerService_READ eligibleCustomerResponse = createResponse.JavaCast<DigitalHubModel.Eligiblecustomer.Model.Response.EligibleCustomerService_READ> ();
//						IDictionary<string, string> dictEligibleCstr = eligibleCustomerResponse.HttpResponseHeaders;
//						foreach (KeyValuePair<string, string> pairEligibleCstr in dictEligibleCstr) {
//							Console.WriteLine ("{0}, {1}",
//								pairEligibleCstr.Key,
//								pairEligibleCstr.Value);
//						}
//					}
					if (outerInstance.strEPSType == EPSType.EligibleCustomerEmail.ToString ()) {
						DigitalHubModel.Eligiblecustomeremail.Model.Response.EligibleCustomerEmail_READ eligbleCustEmailResponse = createResponse.JavaCast<DigitalHubModel.Eligiblecustomeremail.Model.Response.EligibleCustomerEmail_READ> ();
						IDictionary<string, string> dict1 = eligbleCustEmailResponse.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pair1 in dict1) {
							Console.WriteLine ("{0}, {1}",
								pair1.Key,
								pair1.Value);
						}

					}

					if (outerInstance.strEPSType == EPSType.OTPCreate.ToString ()) {
					DigitalHubModel.Otpcreateassurantdigitalhubcreate.Model.Response.OTPCreate  OTPCreateResponse = createResponse.JavaCast<DigitalHubModel.Otpcreateassurantdigitalhubcreate.Model.Response.OTPCreate> (); 
						IDictionary<string, string> dictOTPCreate = OTPCreateResponse.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pairOTPCreate in dictOTPCreate) {
							Console.WriteLine ("{0}, {1}",
								pairOTPCreate.Key,
								pairOTPCreate.Value);
						}
					}
					if (outerInstance.strEPSType == EPSType.OTPValidate.ToString ()) {
					DigitalHubModel.Otp_validateassurantdigitalhubread.Model.Response.OTP_Validate OTPValidateResponse = createResponse.JavaCast<DigitalHubModel.Otp_validateassurantdigitalhubread.Model.Response.OTP_Validate> (); 
						IDictionary<string, string> dictOTPValidate = OTPValidateResponse.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pairOTPValidate in dictOTPValidate) {
							Console.WriteLine ("{0}, {1}",
								pairOTPValidate.Key,
								pairOTPValidate.Value);
						}
					}
					if (outerInstance.strEPSType == EPSType.FormDefinitions.ToString ()) {
						DigitalHubModel.Formdefinitions.Model.Response.FormsDefinition_READ FormDefinitionResponse = createResponse.JavaCast<DigitalHubModel.Formdefinitions.Model.Response.FormsDefinition_READ> ();
						IDictionary<string, string> dictFormDefinition = FormDefinitionResponse.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pairFormDefinition in dictFormDefinition) {
							Console.WriteLine ("{0}, {1}",
								pairFormDefinition.Key,
								pairFormDefinition.Value);
						}
					}
					if (outerInstance.strEPSType == EPSType.FormDefinitionName.ToString ()) {
						DigitalHubModel.Formdefinitionname.Model.Response.FormDefinitionName_READ FormDefinitionName = createResponse.JavaCast<DigitalHubModel.Formdefinitionname.Model.Response.FormDefinitionName_READ> ();
						IDictionary<string, string> dictFormDefinitionName = FormDefinitionName.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pairFormDefinitionName in dictFormDefinitionName) {
							Console.WriteLine ("{0}, {1}",
								pairFormDefinitionName.Key,
								pairFormDefinitionName.Value);
						}
					}
					if (outerInstance.strEPSType == EPSType.FormCollecction.ToString ()) {
						DigitalHubModel.Formscollection.Model.Response.FormCollections_READ FormCollectionResponse = createResponse.JavaCast<DigitalHubModel.Formscollection.Model.Response.FormCollections_READ> ();
						IDictionary<string, string> dictFormCollection = FormCollectionResponse.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pairFormCollection in dictFormCollection) {
							Console.WriteLine ("{0}, {1}",
								pairFormCollection.Key,
								pairFormCollection.Value);
						}
					}
					if (outerInstance.strEPSType == EPSType.FormPost.ToString ()) {
						DigitalHubModel.Formspost.Model.Response.FormsPost_CREATE formPostResponse = createResponse.JavaCast<DigitalHubModel.Formspost.Model.Response.FormsPost_CREATE> ();
						DigitalHubModel.Formspost.Model.Response.Links.Links FormResponse = formPostResponse.Getlinks () [0] as DigitalHubModel.Formspost.Model.Response.Links.Links;
						string strFormID = string.Empty;
						strFormID = FormResponse.Href.Split ('/') [6];
						outerInstance.strFormID = strFormID;
						IDictionary<string, string> dict2 = formPostResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pair2 in dict2) {
							Console.WriteLine ("{0}, {1}",
								pair2.Key,
								pair2.Value);
						}
		
					}
					if (outerInstance.strEPSType == EPSType.GetForm.ToString ()) {
						DigitalHubModel.Getform.Model.Response.FormsGetForm_READ formGetResponse = createResponse.JavaCast<DigitalHubModel.Getform.Model.Response.FormsGetForm_READ> ();
						IDictionary<string, string> dictformGet = formGetResponse.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pairformGet in dictformGet) {
							Console.WriteLine ("{0}, {1}",
								pairformGet.Key,
								pairformGet.Value);
						}
					}
					if (outerInstance.strEPSType == EPSType.FormUpdate.ToString ()) {
						DigitalHubModel.Formupdate.Model.Response.FormsUpdate_UPDATE formUpdateResponse = createResponse.JavaCast<DigitalHubModel.Formupdate.Model.Response.FormsUpdate_UPDATE> ();
						IDictionary<string, string> dictformUpdate = formUpdateResponse.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pairformUpdate in dictformUpdate) {
							Console.WriteLine ("{0}, {1}",
								pairformUpdate.Key,
								pairformUpdate.Value);
						}
					}
		
					if (outerInstance.strEPSType == EPSType.FormDelete.ToString ()) {
						DigitalHubModel.Formsdeletedelete.Model.Response.FormsDELETE_DELETE formDeleteResponse = createResponse.JavaCast<DigitalHubModel.Formsdeletedelete.Model.Response.FormsDELETE_DELETE> ();
						IDictionary<string, string> dictformDelete = formDeleteResponse.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pairformDelete in dictformDelete) {
							Console.WriteLine ("{0}, {1}",
								pairformDelete.Key,
								pairformDelete.Value);
						}
					}
					if (outerInstance.strEPSType == EPSType.CustomerCreate.ToString ()) {

//						DigitalHubModel.Customercreate.Model.Response.CustomerCreate_CREATE customerCreateResponse = createResponse.JavaCast<DigitalHubModel.Customercreate.Model.Response.CustomerCreate_CREATE> ();
//						IDictionary<string, string> dictcustomerCreate = customerCreateResponse.HttpResponseHeaders;
//						foreach (KeyValuePair<string, string> paircustomerCreate in dictcustomerCreate) {
//							Console.WriteLine ("{0}, {1}",
//								paircustomerCreate.Key,
//								paircustomerCreate.Value);
//						}
					}	
					if (outerInstance.strEPSType == EPSType.GetCustomerWithID.ToString ()) {
						DigitalHubModel.Getcustomerwithid.Model.Response.GetCustom_READ getCustomerResponse = createResponse.JavaCast<DigitalHubModel.Getcustomerwithid.Model.Response.GetCustom_READ> ();
						IDictionary<string, string> dictgetCustomer = getCustomerResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pairgetCustomer in dictgetCustomer) {
							Console.WriteLine ("{0}, {1}",
								pairgetCustomer.Key,
								pairgetCustomer.Value);
						}
					}
					if (outerInstance.strEPSType == EPSType.EmailPhoneUpdate.ToString ()) {
						DigitalHubModel.Emailphoneupdate.Model.Response.CustomerUpdate_UPDATE EmailPhoneUpdateResponse = createResponse.JavaCast<DigitalHubModel.Emailphoneupdate.Model.Response.CustomerUpdate_UPDATE> ();
						IDictionary<string, string> dictEmailPhoneUpdate = EmailPhoneUpdateResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pairEmailPhoneUpdate in dictEmailPhoneUpdate) {
							Console.WriteLine ("{0}, {1}",
								pairEmailPhoneUpdate.Key,
								pairEmailPhoneUpdate.Value);
						}
					}
					if (outerInstance.strEPSType == EPSType.CustomerMiscellaneous.ToString ()) {
						DigitalHubModel.Customermiscellaneous.Model.Response.CustomerMiscellaneous_CREATE CustomerMiscellaneousResponse = createResponse.JavaCast<DigitalHubModel.Customermiscellaneous.Model.Response.CustomerMiscellaneous_CREATE> ();
						IDictionary<string, string> dictCustomerMiscellaneous = CustomerMiscellaneousResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pairCustomerMiscellaneous in dictCustomerMiscellaneous) {
							Console.WriteLine ("{0}, {1}",
								pairCustomerMiscellaneous.Key,
								pairCustomerMiscellaneous.Value);
						}
					}
					if (outerInstance.strEPSType == EPSType.LogOutCreate.ToString ()) {
						DigitalHubModel.Logoutcreate.Model.Response.LogOut_CREATE LogOutCreateResponse = createResponse.JavaCast<DigitalHubModel.Logoutcreate.Model.Response.LogOut_CREATE> ();
						IDictionary<string, string> dictLogOutCreate = LogOutCreateResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pairLogOutCreate in dictLogOutCreate) {
							Console.WriteLine ("{0}, {1}",
								pairLogOutCreate.Key,
								pairLogOutCreate.Value);
						}
						return;
					}
					if (outerInstance.strEPSType == EPSType.ValidateTokenCreate.ToString ()) {
						DigitalHubModel.Validatetokencreate.Model.Response.ValidateToken_CREATE ValidateTokenCreateResponse = createResponse.JavaCast<DigitalHubModel.Validatetokencreate.Model.Response.ValidateToken_CREATE> ();
						IDictionary<string, string> dictValidateTokenCreate = ValidateTokenCreateResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						foreach (KeyValuePair<string, string> pairValidateTokenCreate in dictValidateTokenCreate) {
							Console.WriteLine ("{0}, {1}",
								pairValidateTokenCreate.Key,
								pairValidateTokenCreate.Value);
						}
					}

					if (outerInstance.strEPSType == EPSType.GetVersion.ToString ()) {
//						DigitalHubModel.Getversionread.Model.Response.GetVersion_READ GetVersionResponse = createResponse.JavaCast<DigitalHubModel.Getversionread.Model.Response.GetVersion_READ> ();
//						IDictionary<string, string> dictValidateTokenCreate = GetVersionResponse.HttpResponseHeaders;//.HttpResponseHeaders;
//						foreach (KeyValuePair<string, string> pairValidateTokenCreate in dictValidateTokenCreate) {
//							Console.WriteLine ("{0}, {1}",
//								pairValidateTokenCreate.Key,
//								pairValidateTokenCreate.Value);
//						}
					}
					if (outerInstance.strEPSType == EPSType.SAML.ToString ()) {
						DigitalHubModel.Samlread.Model.Response.SAML_READ SAMLResponse = createResponse.JavaCast<DigitalHubModel.Samlread.Model.Response.SAML_READ> ();
						IDictionary<string, string> dictSAML = SAMLResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						if (dictSAML != null) {
							foreach (KeyValuePair<string, string> pairValidateTokenCreate in dictSAML) {
								Console.WriteLine ("{0}, {1}",
									pairValidateTokenCreate.Key,
									pairValidateTokenCreate.Value);
							}
						}
						return;
					}
					if (outerInstance.strEPSType == EPSType.CreateMessage.ToString ()) {
						DigitalHubModel.Createmessagecreate.Model.Response.CreateMessage_CREATE createMessageResponse = createResponse.JavaCast<DigitalHubModel.Createmessagecreate.Model.Response.CreateMessage_CREATE> ();
						IDictionary<string, string> dictcreateMessage = createMessageResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						if (dictcreateMessage != null) {
							foreach (KeyValuePair<string, string> paircreateMessage in dictcreateMessage) {
								Console.WriteLine ("{0}, {1}",
									paircreateMessage.Key,
									paircreateMessage.Value);
							}
						}

						return;
					}
					if (outerInstance.strEPSType == EPSType.EligibleCustomerUpdate.ToString ()) {
						DigitalHubModel.Eligiblecustomerupdatedread.Model.Response.EligibleCustomerUpdated_READ EligibleCustUpdateResponse = createResponse.JavaCast<DigitalHubModel.Eligiblecustomerupdatedread.Model.Response.EligibleCustomerUpdated_READ> ();

						IDictionary<string, string> dictEligibleCustUpdate = EligibleCustUpdateResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						if (dictEligibleCustUpdate != null) {
							foreach (KeyValuePair<string, string> pairdictEligibleCustUpdate in dictEligibleCustUpdate) {
								Console.WriteLine ("{0}, {1}",
									pairdictEligibleCustUpdate.Key,
									pairdictEligibleCustUpdate.Value);
							}
						}

						return;
					}


					if (outerInstance.strEPSType == EPSType.KillSwitch.ToString ()) {
//						DigitalHubModel.Getswitchstatusread.Model.Response.GetSwitchStatus_READ KillSwitchresponse = createResponse.JavaCast<DigitalHubModel.Getswitchstatusread.Model.Response.GetSwitchStatus_READ> ();
//						IDictionary<string, string> dictEligibleCustUpdate = KillSwitchresponse.HttpResponseHeaders;//.HttpResponseHeaders;
//						if (dictEligibleCustUpdate != null) {
//							foreach (KeyValuePair<string, string> pairdictEligibleCustUpdate in dictEligibleCustUpdate) {
//								Console.WriteLine ("{0}, {1}",
//									pairdictEligibleCustUpdate.Key,
//									pairdictEligibleCustUpdate.Value);
//							}
//						}

						return;

					}
					if (outerInstance.strEPSType == EPSType.CarDetailsGet.ToString ()) {
						DigitalHubModel.Cardetailsgetformread.Model.Response.CarDetailsGetForm_READ carResponse = createResponse.JavaCast<DigitalHubModel.Cardetailsgetformread.Model.Response.CarDetailsGetForm_READ> ();
					DigitalHubModel.Cardetailsgetformread.Model.Response.Fields.Fields fieldResponse = carResponse.Getfields ();	
					IDictionary<string, string> dictCarDetailsGetForm_READ = carResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						if (dictCarDetailsGetForm_READ != null) {
							foreach (KeyValuePair<string, string> pairdictCarDetailsGetForm_READ in dictCarDetailsGetForm_READ) {
								Console.WriteLine ("{0}, {1}",
									pairdictCarDetailsGetForm_READ.Key,
									pairdictCarDetailsGetForm_READ.Value);
							}
						}
					}
					if (outerInstance.strEPSType == EPSType.CarDetailsFormPostDetails.ToString ()) {
						DigitalHubModel.Cardetailsformpostcreate.Model.Response.CarDetailsFormPost_CREATE carCreateResponse = createResponse.JavaCast<DigitalHubModel.Cardetailsformpostcreate.Model.Response.CarDetailsFormPost_CREATE> ();
						IDictionary<string, string> dictCarDetailsFormPost_CREATE = carCreateResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						if (dictCarDetailsFormPost_CREATE != null) {
							foreach (KeyValuePair<string, string> pairdictCarDetailsFormPost_CREATE in dictCarDetailsFormPost_CREATE) {
								Console.WriteLine ("{0}, {1}",
									pairdictCarDetailsFormPost_CREATE.Key,
									pairdictCarDetailsFormPost_CREATE.Value);
							}
						}
					}
					if (outerInstance.strEPSType == EPSType.CreateMessage.ToString ()) {
						DigitalHubModel.Createmessagecreate.Model.Response.CreateMessage_CREATE createMessageResponse = createResponse.JavaCast<DigitalHubModel.Createmessagecreate.Model.Response.CreateMessage_CREATE> ();
						IDictionary<string, string> dictCreateMessage_CREATE = createMessageResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						if (dictCreateMessage_CREATE != null) {
							foreach (KeyValuePair<string, string> pairdictCreateMessage_CREATE in dictCreateMessage_CREATE) {
								Console.WriteLine ("{0}, {1}",
									pairdictCreateMessage_CREATE.Key,
									pairdictCreateMessage_CREATE.Value);
							}
						}
					}
					if (outerInstance.strEPSType == EPSType.GetMessage.ToString ()) {
						DigitalHubModel.Getmessagesread.Model.Response.GetMessages_READ getMessageResponse = createResponse.JavaCast<DigitalHubModel.Getmessagesread.Model.Response.GetMessages_READ> ();
						
					IList<DigitalHubModel.Getmessagesread.Model.Response.Messages.Messages> messages = getMessageResponse.Getmessages ();
					string msgId, msgSource, msgTitle;
					foreach (DigitalHubModel.Getmessagesread.Model.Response.Messages.Messages msg in messages) {
						msgId = msg.MessageId;
						msgSource = msg.MessageSource;
						msgTitle = msg.MessageTitle;
					}
					IDictionary<string, string> dictGetMessages_READ = getMessageResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						if (dictGetMessages_READ != null) {
							foreach (KeyValuePair<string, string> pairdictGetMessages_READ in dictGetMessages_READ) {
								Console.WriteLine ("{0}, {1}",
									pairdictGetMessages_READ.Key,
									pairdictGetMessages_READ.Value);
							}
						}
					}
//				if (outerInstance.strEPSType == EPSType.GetMessageWithID.ToString ()) {
//					DigitalHubModel.Getmessagewithidread.Model.OrchGetMessageWithIDREAD_GetMessageWithID_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Getmessagewithidread.Model.OrchGetMessageWithIDREAD_GetMessageWithID_READ_RESPONSE> ();			
//				}
					if (outerInstance.strEPSType == EPSType.MessageMiscellaneousUpdate.ToString ()) {
						DigitalHubModel.Messagesmiscellaneousupdate.Model.Response.MessagesMiscellaneous_UPDATE messageMiscellaneousResponse = createResponse.JavaCast<DigitalHubModel.Messagesmiscellaneousupdate.Model.Response.MessagesMiscellaneous_UPDATE> ();
						IDictionary<string, string> dictMessagesMiscellaneous_UPDATE = messageMiscellaneousResponse.HttpResponseHeaders;//.HttpResponseHeaders;
						if (dictMessagesMiscellaneous_UPDATE != null) {
							foreach (KeyValuePair<string, string> pairdictMessagesMiscellaneous_UPDATE in dictMessagesMiscellaneous_UPDATE) {
								Console.WriteLine ("{0}, {1}",
									pairdictMessagesMiscellaneous_UPDATE.Key,
									pairdictMessagesMiscellaneous_UPDATE.Value);
							}
						}
					}

					//==========================================================================================================================================================================================================================================================
					//				DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_address_RESPONSE addressResponse = response.Address.JavaCast<DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_address_RESPONSE>();
					//				DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_security_questions_RESPONSE secQuesResponse = response.SecurityQuestions.JavaCast<DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_security_questions_RESPONSE> ();
					//				if (secQuesResponse != null) {
					//					DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_security_questions_security_question_one_RESPONSE secQuesResponse1 = response.SecurityQuestions.SecurityQuestionOne.JavaCast<DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_security_questions_security_question_one_RESPONSE> ();
					//					DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_security_questions_security_question_two_RESPONSE secQuesResponse2 = response.SecurityQuestions.SecurityQuestionTwo.JavaCast<DigitalHubModel.Getcustomerwithid.Model.GetCustomerWithID_GetCustom_READ_security_questions_security_question_two_RESPONSE> ();
					//					string code1 = secQuesResponse1.SecurityQuestionCode;
					//					string amswer1 = secQuesResponse1.SecurityAnswer;
					//
					//					string code2 = secQuesResponse2.SecurityQuestionCode;
					//					string answer2 = secQuesResponse2.SecurityAnswer;
					//				}
					//								string postalcode = addressResponse.Postalcode;
					//								string countrycode = addressResponse.CountryCode;
					//								string line1 = addressResponse.Line1;
					//								string line2 = addressResponse.Line2;
					//								string line3 = addressResponse.Line3;
					//								string line4 = addressResponse.Line4;
					//				
					//								
					//				

					//								string sortcode = response.Sortcode;
					//								string firstname = response.Forename;




					//==========================================================================================================================================================================================================================================================

					//DigitalHubModel.Emailphoneupdate.Model.EmailPhoneUpdate_CustomerUpdate_UPDATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Emailphoneupdate.Model.EmailPhoneUpdate_CustomerUpdate_UPDATE_RESPONSE> ();

//					if (outerInstance.strEPSType.Equals ("")) 




						//	DigitalHubModel.Cardetailsgetformread.Model.OrchCarDetailsGetFormREAD_CarDetailsGetForm_READ_RESPONSE carResponse = createResponse.JavaCast<DigitalHubModel.Cardetailsgetformread.Model.OrchCarDetailsGetFormREAD_CarDetailsGetForm_READ_RESPONSE>();
						//DigitalHubModel.Cardetailsformpostcreate.Model.OrchCarDetailsFormPostCREATE_CarDetailsFormPost_CREATE_RESPONSE carCreateResponse = createResponse.JavaCast<DigitalHubModel.Cardetailsformpostcreate.Model.OrchCarDetailsFormPostCREATE_CarDetailsFormPost_CREATE_RESPONSE> ();

						//DigitalHubModel.Createmessagecreate.Model.OrchCreateMessageCREATE_CreateMessage_CREATE_RESPONSE createMessageResponse = createResponse.JavaCast<DigitalHubModel.Createmessagecreate.Model.OrchCreateMessageCREATE_CreateMessage_CREATE_RESPONSE> ();
						//				DigitalHubModel.Getmessagesread.Model.OrchGetMessagesREAD_GetMessages_READ_RESPONSE getMessageResponse = createResponse.JavaCast<DigitalHubModel.Getmessagesread.Model.OrchGetMessagesREAD_GetMessages_READ_RESPONSE> ();
						//DigitalHubModel.Getmessagewithidread.Model.OrchGetMessageWithIDREAD_GetMessageWithID_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Getmessagewithidread.Model.OrchGetMessageWithIDREAD_GetMessageWithID_READ_RESPONSE> ();			
						//DigitalHubModel.Messagesmiscellaneousupdate.Model.OrchMessagesMiscellaneousUPDATE_MessagesMiscellaneous_UPDATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Messagesmiscellaneousupdate.Model.OrchMessagesMiscellaneousUPDATE_MessagesMiscellaneous_UPDATE_RESPONSE> ();



						//DigitalHubModel.Customer.Model.Customer_GetCustom_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Customer.Model.Customer_GetCustom_READ_RESPONSE> ();
						//DigitalHubModel.Getcustomerwithquery.Model.GetCustomerWithQuery_GetCustomer_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Getcustomerwithquery.Model.GetCustomerWithQuery_GetCustomer_READ_RESPONSE> ();
						//DigitalHubModel.Customermiscellaneous.Model.CustomerMiscellaneous_CustomerMiscellaneous_CREATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Customermiscellaneous.Model.CustomerMiscellaneous_CustomerMiscellaneous_CREATE_RESPONSE> ();
						//DigitalHubModel.Formdefinitionname.Model.FormDefinitionName_FormDefinitionName_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Formdefinitionname.Model.FormDefinitionName_FormDefinitionName_READ_RESPONSE> ();
						//DigitalHubModel.

						//string one = response.

						//DigitalHubModel.Eligiblecustomeremail.Model.EligibleCustomerEmail_EligibleCustomerEmail_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Eligiblecustomeremail.Model.EligibleCustomerEmail_EligibleCustomerEmail_READ_RESPONSE> ();
						//DigitalHubModel.Customercreate.Model.CustomerCreate_CustomerCreate_CREATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Customercreate.Model.CustomerCreate_CustomerCreate_CREATE_RESPONSE> ();
						//DigitalHubModel.Login.Model.Login_Login_CREATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Login.Model.Login_Login_CREATE_RESPONSE> ();
						//DigitalHubModel.Logoutcreate.Model.OrchLogOutCREATE_LogOut_CREATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Logoutcreate.Model.OrchLogOutCREATE_LogOut_CREATE_RESPONSE> ();
						//Toast.MakeText (outerInstance, response.DateOfBirth, ToastLength.Long).Show ();
						//DigitalHubModel.Createmessagecreate.Model.OrchCreateMessageCREATE_CreateMessage_CREATE_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Createmessagecreate.Model.OrchCreateMessageCREATE_CreateMessage_CREATE_RESPONSE> ();
						//DigitalHubModel.Getmessagesread.Model.OrchGetMessagesREAD_GetMessages_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Getmessagesread.Model.OrchGetMessagesREAD_GetMessages_READ_RESPONSE> ();			
						//					DigitalHubModel.Getmessagesread.Model.OrchGetMessagesREAD_GetMessages_READ_RESPONSE readResponse = createResponse.JavaCast<DigitalHubModel.Getmessagesread.Model.OrchGetMessagesREAD_GetMessages_READ_RESPONSE> ();
						//					DigitalHubModel.Getmessagesread.Model.OrchGetMessagesREAD_GetMessages_READ_messages_RESPONSE MessageResponse = readResponse.Getmessages () [0];
						//					//createResponse.JavaCast<DigitalHubModel.Getmessagesread.Model.OrchGetMessagesREAD_GetMessages_READ_messages_RESPONSE> ();
						//					string messageSource = MessageResponse.MessageSource;

						//DigitalHubModel.Shasignread.Model.OrchSHASignREAD_SHASign_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Shasignread.Model.OrchSHASignREAD_SHASign_READ_RESPONSE> ();



						//DigitalHubModel.Formscollection.Model.FormsCollection_FormCollections_READ_RESPONSE response = createResponse.JavaCast<DigitalHubModel.Formscollection.Model.FormsCollection_FormCollections_READ_RESPONSE> ();
						//var linkResponse = response.Formlinks.JavaCast<DigitalHubModel.Formscollection.Model.FormsCollection_FormCollections_READ_formlinks_RESPONSE>();

						//Console.WriteLine (messageSource);


						//response.Formlinks = 
						//response.Formlinks = response.ToArray<DigitalHubModel.Formscollection.Model.FormsCollection_FormCollections_READ_formlinks_RESPONSE> ();

						//				List<object> ol = new List<object> ();
						//				ol.Add (linkResponse);
						//				response.Formlinks = ol;

						//string formDefination = linkResponse.Formdefinition;
						//string hrefObj = linkResponse.Href;


						//==========================================================================================================================================================================================================================================================


						//Toast.MakeText(outerInstance, response.Getprop_question1, ToastLength.Long).Show();
						//   
						//				Console.WriteLine("Breakdown Call Success","Result is - " + response.Getprop_question1 + "");
						//
						//				Log.I("Breakdown Call Success","Result is - " + response.Getprop_question1 + "","","");

						//outerInstance.Finish();
					
				

			}
			public void OnError(Entity errorObj)
			{
				TJError tjError = errorObj.JavaCast<TJError>();
				string errorStr = tjError.ErrorCode + "-" + tjError.ErrorMessage;


				//string error = tjError.ToString ();
				//				Toast.MakeText(outerInstance, errorStr, ToastLength.Long).Show();
				//				outerInstance.Finish();
			}
		}
		private class TJProgressHandlerCreate :Java.Lang.Object, TJProgressHandler
		{
			private readonly HomeActivity outerInstance;

			public TJProgressHandlerCreate(HomeActivity outerInstance)
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

//		public void RequestOTPNew(Appmodel.AssurantDigitalHub assurantApp)
//		{
//			Appmodel.Orchestration.Otpcreatecreate.Model.Request.OTPCreateCREATE OTPCreate= new Appmodel.Orchestration.Otpcreatecreate.Model.Request.OTPCreateCREATE();
//			OTPCreate.Company = "Halifax";
//			OTPCreate.ID = custID;
//			OTPCreate.Reference = custID;
//			Appmodel.Orchestration.Otpcreatecreate.Model.Request.Endpoint.clsEndpoint endPoint = new Appmodel.Orchestration.Otpcreatecreate.Model.Request.Endpoint.clsEndpoint ();
//			endPoint.Channel = "email";
//			endPoint.Destination = "Benjamin.Cole@dev.lifestylegroup.co.uk";
//			endPoint.TemplateCode = "forgotten_password";
//
//			OTPCreate.Endpoint = endPoint;
//
//			Appmodel.Orchestration.Otpcreatecreate.clsOTPCreateCREATE OTPRequest = assurantApp.OTPCreateCREATEResource;
//			OTPRequest.SetProgressHandler (new TJProgressHandlerCreate (this));
//			OTPRequest.SetResponseHandler (new TJResponseHandlerCreate (this));
//			OTPRequest.Create (OTPCreate);
//		}
//
//		public void RequestCarUpdate(Appmodel.AssurantDigitalHub assurantApp)
//		{
//			Appmodel.Orchestration.Cardetailsgetupdate.Model.Request.CarDetailsGetUPDATE CarDeatilsUpdate = new Appmodel.Orchestration.Cardetailsgetupdate.Model.Request.CarDetailsGetUPDATE();
//			//CarDeatilsUpdate
//		}

		private void RequestBreakDownInfo(Appmodel.AssurantDigitalHub assurantApp)
		{
						strEPSType = EPSType.BreakDownCreate.ToString();
			Appmodel.Orchestration.Breakdowncreate.Model.Request.Breakdowncallinfo.Location.Location location =
				new Appmodel.Orchestration.Breakdowncreate.Model.Request.Breakdowncallinfo.Location.Location ();

			location.Accuracy = "10.0";
			location.Altitude = "0";
			location.Latitude = "51.3";
			location.Longitude = "-1.2";

			Appmodel.Orchestration.Breakdowncreate.Model.Request.Breakdowncallinfo.Membershipdetails.MembershipDetails membershipDetails =
				new Appmodel.Orchestration.Breakdowncreate.Model.Request.Breakdowncallinfo.Membershipdetails.MembershipDetails ();

			membershipDetails.MembershipNo = "2313123";
			membershipDetails.MobileNumber = "1234567890";
			membershipDetails.Name = "234234";
			membershipDetails.VehicleReg = "232";

			Appmodel.Orchestration.Breakdowncreate.Model.Request.Breakdowncallinfo.BreakdownCallInfo breakDownCallInfo =
				new Appmodel.Orchestration.Breakdowncreate.Model.Request.Breakdowncallinfo.BreakdownCallInfo ();

			breakDownCallInfo.Company = "Halifax";
			breakDownCallInfo.Key = "79905c20ff2c3b20465b9df58bb0ecd3";

			breakDownCallInfo.Location = location;
			breakDownCallInfo.MembershipDetails = membershipDetails;

			Appmodel.Orchestration.Breakdowncreate.Model.Request.BreakDown_CREATE req = new Appmodel.Orchestration.Breakdowncreate.Model.Request.BreakDown_CREATE();

			req.BreakdownCallInfo = breakDownCallInfo;

			Appmodel.Orchestration.Breakdowncreate.clsBreakdownCreate createRequset = assurantApp.BreakDownCREATEResource;

			//Appmodel.BreakDownCall.SyncContext.SetNetworkType (NetworkType.ThreeGNetwork);

			createRequset.SetProgressHandler (new TJProgressHandlerCreate (this));
			createRequset.SetResponseHandler (new TJResponseHandlerCreate (this));
			createRequset.Create (req);
		}
//
		private void RequestEligableCustomer(Appmodel.AssurantDigitalHub assurentApp)
		{
			strEPSType  = EPSType.EligibleCustomer.ToString();
//			DigitalHubModel.Eligiblecustomer.Model.Request.EligibleCustomerService_READ  eligibleReq = new 
//				DigitalHubModel.Eligiblecustomer.Model.Request.EligibleCustomerService_READ ();
//
//			eligibleReq.Company = "halifax";
//			eligibleReq.ID = userid;
//
//			eligibleReq.AccountNumber ="77524162";
//			eligibleReq.DateOfBirth ="1948-11-12";
//			//eligibleReq.
//			//eligibleReq.DateOfBirth = "1-Mar";
//			eligibleReq.Forename ="Fredb";
//			eligibleReq.Postalcode ="TD50DN";
//			eligibleReq.Sortcode ="150306";
//			eligibleReq.Surname ="Fredb";
//
////			eligibleUpdateReq.Company = "halifax";
////			eligibleUpdateReq.ID = userid;
////
////			//			//Tenant Set ID 1
////			eligibleUpdateReq.AccountNumber ="77524162";
////			eligibleUpdateReq.DateOfBirth ="null";
////			eligibleUpdateReq.DateOfBirthDay="12";
////			eligibleUpdateReq.DateOfBirthMonth = "11";
////			eligibleUpdateReq.Forename ="Fredb";
////			eligibleUpdateReq.Postalcode ="null";
////			eligibleUpdateReq.Sortcode ="150306";
////			eligibleUpdateReq.Surname ="null";
//
//			DigitalHubModel.Eligiblecustomer.clsEligibleCustomer cust = assurentApp.EligibleCustomerResource;
//			cust.SetResponseHandler (new TJResponseHandlerCreate (this));
//			cust.SetProgressHandler (new TJProgressHandlerCreate (this));
//			cust.Read (eligibleReq);
		}
//
	public void RequestEligibleCustomerUpdate(Appmodel.AssurantDigitalHub assurantApp)
		{
		strEPSType = EPSType.EligibleCustomerUpdate.ToString();
//			DigitalHubModel.Eligiblecustomerupdatedread.Model.OrchEligibleCustomerUpdatedREAD_EligibleCustomerUpdated_READ_REQUEST eligibleUpdateReq = new 
//				DigitalHubModel.Eligiblecustomerupdatedread.Model.OrchEligibleCustomerUpdatedREAD_EligibleCustomerUpdated_READ_REQUEST ();
			DigitalHubModel.Eligiblecustomerupdatedread.Model.Request.EligibleCustomerUpdated_READ  eligibleUpdateReq = new 
				DigitalHubModel.Eligiblecustomerupdatedread.Model.Request.EligibleCustomerUpdated_READ ();
   
//		obj.AccountNumber = "71524166";
//		obj.DateOfBirth ="null";
//		obj.DateOfBirthDay="14";
//		obj.DateOfBirthMonth = "03";
//		obj.Forename ="Benjamin";
//		obj.Postalcode ="null";
//		obj.Sortcode ="150130";
//		obj.Surname ="null";

//			DigitalHubModel.Eligiblecustomerupdatedread.EligibleCustomerUpdatedREAD RequestRead = assurantApp.EligibleCustomerUpdatedREADResource;
//			RequestRead.Read (eligibleUpdateReq);


			eligibleUpdateReq.Company = "halifax";
			eligibleUpdateReq.ID = userid;

//			//Tenant Set ID 1
			eligibleUpdateReq.AccountNumber ="79933674";
			eligibleUpdateReq.DateOfBirth ="null";
			eligibleUpdateReq.DateOfBirthDay="13";
			eligibleUpdateReq.DateOfBirthMonth = "04";
			eligibleUpdateReq.Forename ="Canceld";
			eligibleUpdateReq.Postalcode ="CW4 7AA";
			eligibleUpdateReq.Sortcode ="150424";
			eligibleUpdateReq.Surname ="Canceld";

			//Tenant Set ID 2
//			eligibleUpdateReq.AccountNumber ="null";
//			eligibleUpdateReq.DateOfBirth ="1972-03-14";
//			eligibleUpdateReq.DateOfBirthDay="null";
//			eligibleUpdateReq.DateOfBirthMonth = "null";
//			eligibleUpdateReq.Forename ="Benjamin";
//			eligibleUpdateReq.Postalcode ="TD50DN";
//			eligibleUpdateReq.Sortcode ="null";
//			eligibleUpdateReq.Surname ="Cole";
//

			//Tenant Set ID
//			eligibleUpdateReq.AccountNumber ="71524166";
//			eligibleUpdateReq.DateOfBirth ="1972-03-14";
//			eligibleUpdateReq.DateOfBirthDay="14";
//			eligibleUpdateReq.DateOfBirthMonth = "03";
//			eligibleUpdateReq.Forename ="Benjamin";
//			eligibleUpdateReq.Postalcode ="TD50DN";
//			eligibleUpdateReq.Sortcode ="150130";
//			eligibleUpdateReq.Surname ="Cole";

			DigitalHubModel.Eligiblecustomerupdatedread.EligibleCustomerUpdatedREAD custUpdate = assurantApp.EligibleCustomerUpdatedREADResource;
			custUpdate.SetResponseHandler (new TJResponseHandlerCreate (this));
			custUpdate.SetProgressHandler (new TJProgressHandlerCreate (this));
			custUpdate.Read (eligibleUpdateReq);
		}
//
		private void RequestOTPCreate(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.OTPCreate.ToString();
		
			DigitalHubModel.Otpcreateassurantdigitalhubcreate.Model.Request.OTPCreate OnePasswordCreate = new DigitalHubModel.Otpcreateassurantdigitalhubcreate.Model.Request.OTPCreate ();
			OnePasswordCreate.Reference = custID;
			OnePasswordCreate.Authorization = token;
			OnePasswordCreate.Company = "halifax";
			OnePasswordCreate.ID = userid;
			
			DigitalHubModel.Otpcreateassurantdigitalhubcreate.Model.Request.Endpoint.Endpoint endPointRequest = new DigitalHubModel.Otpcreateassurantdigitalhubcreate.Model.Request.Endpoint.Endpoint ();
						endPointRequest.Channel = "email";
			endPointRequest.Destination = userid;
						endPointRequest.TemplateCode = "forgotten_password";
			OnePasswordCreate.Endpoint = endPointRequest;
			
			DigitalHubModel.Otpcreateassurantdigitalhubcreate.OTPCreateAssurantDigitalHubCREATE OneTimePassword = assurantApp.OTPCreateAssurantDigitalHubCREATEResource;
						OneTimePassword.SetProgressHandler (new TJProgressHandlerCreate (this));
						OneTimePassword.SetResponseHandler (new TJResponseHandlerCreate (this));
			OneTimePassword.Create (OnePasswordCreate);
						

		}
			
		private void RequestEligibleCustomerEmail(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.EligibleCustomerEmail.ToString();
			DigitalHubModel.Eligiblecustomeremail.Model.Request.EligibleCustomerEmail_READ EligibleCustomerReadRequest = new  DigitalHubModel.Eligiblecustomeremail.Model.Request.EligibleCustomerEmail_READ ();
			//EligibleCustomerReadRequest.Authorization = "Huzzle f12d483d-8919-4d1b-9dd6-34390b5ead26.8b4ade9e5284531029680e5618cf6d79";
			EligibleCustomerReadRequest.Company = "halifax";
			//EligibleCustomerReadRequest.ID = "johnnycrappleseed@ex";
			EligibleCustomerReadRequest.ID = "halifax";
			EligibleCustomerReadRequest.EmailAddress = userid;

			DigitalHubModel.Eligiblecustomeremail.clsEligibleCustomerEmail Request = assurantApp.EligibleCustomerEmailResource;
			Request.SetResponseHandler (new TJResponseHandlerCreate (this));
			Request.SetProgressHandler (new TJProgressHandlerCreate (this));
			Request.Read (EligibleCustomerReadRequest);
		}
//
		private void RequestOTPValidate(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.OTPValidate.ToString();
			DigitalHubModel.Otp_validateassurantdigitalhubread.Model.Request.OTP_Validate OnePasswordValidate = new DigitalHubModel.Otp_validateassurantdigitalhubread.Model.Request.OTP_Validate ();
			OnePasswordValidate.Reference = custID;
			OnePasswordValidate.Authorization =token;
			OnePasswordValidate.Company = "Halifax";
			OnePasswordValidate.ID = userid;

			DigitalHubModel.Otp_validateassurantdigitalhubread.OTP_ValidateAssurantDigitalHubREAD OneTimePassword = assurantApp.OTP_ValidateAssurantDigitalHubREADResource;
			OneTimePassword.SetProgressHandler (new TJProgressHandlerCreate (this));
			OneTimePassword.SetResponseHandler (new TJResponseHandlerCreate (this));
			OneTimePassword.Read (OnePasswordValidate);

		}
//
//
		public void RequestFormDefinitions(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.FormDefinitions.ToString();
			DigitalHubModel.Formdefinitions.Model.Request.FormsDefinition_READ eligibleQuestions = new  DigitalHubModel.Formdefinitions.Model.Request.FormsDefinition_READ ();
			//DigitalHubModel.Formsdefeligques.Model.FormsDefEligQues_FormDefinitionsEligibilityQuestions_READ_REQUEST eligibleQuestns = new DigitalHubModel.Formsdefeligques.Model.FormsDefEligQues_FormDefinitionsEligibilityQuestions_READ_REQUEST ();
			eligibleQuestions.Authorization = token;
			eligibleQuestions.Company="halifax";
			eligibleQuestions.ID= userid;
			//string s = eligibleQuestns.Getid ();
			DigitalHubModel.Formdefinitions.clsFormDefinitions Questions = assurantApp.FormDefinitionsResource;
			//DigitalHubModel.Formsdefeligques.clsFormsDefEligQues Questions = assurantApp.FormDefinitionsResource;
			Questions.SetResponseHandler (new TJResponseHandlerCreate (this));
			Questions.SetProgressHandler( new TJProgressHandlerCreate (this));
			Questions.Read (eligibleQuestions);


		}
		private void RequestFormDefinitionName(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.FormDefinitionName.ToString();
			DigitalHubModel.Formdefinitionname.Model.Request.FormDefinitionName_READ FormdefinationnameRequest = new DigitalHubModel.Formdefinitionname.Model.Request.FormDefinitionName_READ ();
			FormdefinationnameRequest.Authorization = token;
			FormdefinationnameRequest.Company = "halifax";
			FormdefinationnameRequest.ID = userid;
			FormdefinationnameRequest.Name = "eligibility-questions";

			DigitalHubModel.Formdefinitionname.clsFormDefinitionName Request = assurantApp.FormDefinitionNameResource;
			Request.SetResponseHandler (new TJResponseHandlerCreate (this));
			Request.SetProgressHandler (new TJProgressHandlerCreate (this));
			Request.Read (FormdefinationnameRequest);
		}
//
		public void RequestFormCollecction(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.FormCollecction.ToString();
			DigitalHubModel.Formscollection.Model.Request.FormCollections_READ FormsCollectionReadRequest = new DigitalHubModel.Formscollection.Model.Request.FormCollections_READ ();
			FormsCollectionReadRequest.Authorization =token;
			FormsCollectionReadRequest.Company = "halifax";
			FormsCollectionReadRequest.ID = userid;
			FormsCollectionReadRequest.CustomerID = custID;
			FormsCollectionReadRequest.FilterFormdefinition = "car-details";
			//FormsCollectionReadRequest.FilterFormdefinition = "eligibility-questions";
			DigitalHubModel.Formscollection.clsFormsCollection Request = assurantApp.FormsCollectionResource;
			Request.SetResponseHandler (new TJResponseHandlerCreate (this));
			Request.SetProgressHandler (new TJProgressHandlerCreate (this));
			Request.Read (FormsCollectionReadRequest);
		}

		public void RequestFormPost(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.FormPost.ToString();
			DigitalHubModel.Formspost.Model.Request.FormsPost_CREATE FormsPostCreateRquest = new DigitalHubModel.Formspost.Model.Request.FormsPost_CREATE ();
			FormsPostCreateRquest.Authorization = token;
			FormsPostCreateRquest.Company = "halifax";
			FormsPostCreateRquest.ID = userid;
			FormsPostCreateRquest.Formdefinition = "eligibility-questions";

			DigitalHubModel.Formspost.Model.Request.Fields.Fields FormsPostCreatefieldsRequest = new DigitalHubModel.Formspost.Model.Request.Fields.Fields ();
			FormsPostCreatefieldsRequest.PropQuestion1 = "No";
			FormsPostCreatefieldsRequest.PropQuestion2 ="No";
			FormsPostCreatefieldsRequest.PropQuestion3 = "Yes";
			FormsPostCreatefieldsRequest.PropQuestion4 = "Yes";
			FormsPostCreatefieldsRequest.PropQuestion5 = "Yes";
			FormsPostCreatefieldsRequest.PropQuestion6 = "Yes";

			FormsPostCreateRquest.Fields = FormsPostCreatefieldsRequest;
			FormsPostCreateRquest.CustomerID = custID;

			DigitalHubModel.Formspost.clsFormsPost Request = assurantApp.FormsPostResource;
			Request.SetResponseHandler (new TJResponseHandlerCreate (this));
			Request.SetProgressHandler (new TJProgressHandlerCreate (this));
			Request.Create (FormsPostCreateRquest);
		}
//
		public void RequestGetForm(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.GetForm.ToString();
			DigitalHubModel.Getform.Model.Request.FormsGetForm_READ GetFormReadRequest = new DigitalHubModel.Getform.Model.Request.FormsGetForm_READ ();
			GetFormReadRequest.Authorization = token;
			GetFormReadRequest.Company = "halifax";
			GetFormReadRequest.ID = userid;
			GetFormReadRequest.CustomerID = custID;;
			if(!strFormID.Equals(string.Empty))
				GetFormReadRequest.FormID = strFormID;//"31546";
			else
				GetFormReadRequest.FormID = "31546";

			DigitalHubModel.Getform.clsGetForm Request = assurantApp.GetFormResource;
			Request.SetResponseHandler (new TJResponseHandlerCreate (this));
			Request.SetProgressHandler (new TJProgressHandlerCreate (this));
			Request.Read (GetFormReadRequest);
		}
//
		public void RequestFormUpdate(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.FormUpdate.ToString();
			DigitalHubModel.Formupdate.Model.Request.FormsUpdate_UPDATE FormUpdateRequest = new DigitalHubModel.Formupdate.Model.Request.FormsUpdate_UPDATE ();
			FormUpdateRequest.Authorization = token;
			FormUpdateRequest.Company = "halifax";
			FormUpdateRequest.ID = userid;
			FormUpdateRequest.CustomerID = custID;
			if (!strFormID.Equals (string.Empty))
				FormUpdateRequest.FormID = strFormID;// "31546";
			else
				FormUpdateRequest.FormID = "31546";

			DigitalHubModel.Formupdate.FormUpdate Request = assurantApp.FormUpdateResource;
			Request.SetResponseHandler (new TJResponseHandlerCreate (this));
			Request.SetProgressHandler (new TJProgressHandlerCreate (this));
			Request.Update (FormUpdateRequest);
		}

		public void RequestFormDelete(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.FormDelete.ToString();
			DigitalHubModel.Formsdeletedelete.Model.Request.FormsDELETE_DELETE Formsdeletedelete = new DigitalHubModel.Formsdeletedelete.Model.Request.FormsDELETE_DELETE ();
			Formsdeletedelete.Authorization = token;
			Formsdeletedelete.Company = "halifax";
			Formsdeletedelete.ID = userid;
			Formsdeletedelete.CustomerID = custID;
			if (!strFormID.Equals (string.Empty))
				Formsdeletedelete.FormID = strFormID;// "31624";
			else
				Formsdeletedelete.FormID = "31624";
			DigitalHubModel.Formsdeletedelete.FormsDELETEDELETE FormsdeletedeleteRequest = assurantApp.FormsDELETEDELETEResource;

			FormsdeletedeleteRequest.SetResponseHandler (new TJResponseHandlerCreate (this));
			FormsdeletedeleteRequest.SetProgressHandler (new TJProgressHandlerCreate (this));
			FormsdeletedeleteRequest.Delete (Formsdeletedelete);

		}

		public void RequestGetCustomerWithID(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.GetCustomerWithID.ToString();
			DigitalHubModel.Getcustomerwithid.Model.Request.GetCustom_READ GetCustomerRequest = new DigitalHubModel.Getcustomerwithid.Model.Request.GetCustom_READ();
			GetCustomerRequest.Authorization = token;
			GetCustomerRequest.Company ="halifax";
			GetCustomerRequest.ID = userid;
			GetCustomerRequest.CustomerID = custID;
			GetCustomerRequest.Representation = "full";
			DigitalHubModel.Getcustomerwithid.clsGetCustomerWithID GetCustomer = assurantApp.GetCustomerWithIDResource;
			GetCustomer.SetProgressHandler (new TJProgressHandlerCreate (this));
			GetCustomer.SetResponseHandler (new TJResponseHandlerCreate (this));
			GetCustomer.Read (GetCustomerRequest);
		}
      
		public void RequestCreateCustomer(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType  = EPSType.CustomerCreate.ToString();

			DigitalHubModel.Customercreate.Model.Request.CustomerCreate CustomerCreateRequest = new DigitalHubModel.Customercreate.Model.Request.CustomerCreate ();
			//CustomerCreateRequest.Authorization = token;
			CustomerCreateRequest.Company = "halifax";
			CustomerCreateRequest.ID = "73548770250";
            		    

			CustomerCreateRequest.AccountNumber = "79933674";
			CustomerCreateRequest.AccountParties = "1";

			DigitalHubModel.Customercreate.Model.Request.Address.Address CustomerCreateAddressRequest = new DigitalHubModel.Customercreate.Model.Request.Address.Address ();
			CustomerCreateAddressRequest.CountryCode = "XXX";
			CustomerCreateAddressRequest.Line1 = "1-3 Tester Street";
			CustomerCreateAddressRequest.Line2 = "2-Crewe";
			CustomerCreateAddressRequest.Line3 = "";
			CustomerCreateAddressRequest.Line4 = "";
			CustomerCreateAddressRequest.Postalcode = "CW4 7AA";

			CustomerCreateRequest.Address = CustomerCreateAddressRequest;
			CustomerCreateRequest.DateOfBirth = "1980-04-13";
			CustomerCreateRequest.EmailAddress = "ted3@test.lifestylegroup.co.uk";
			CustomerCreateRequest.Forename ="Canceld";
			CustomerCreateRequest.GenderCode = "M";
			CustomerCreateRequest.HomePhoneNumber = "01270123458";
			CustomerCreateRequest.CustID = "73548769677";
			CustomerCreateRequest.MiddleNames = "";
			CustomerCreateRequest.MobilePhoneNumber = "07123456789";
			CustomerCreateRequest.Password = "Tester12!";
			CustomerCreateRequest.SalutationCode = "Mr";
			CustomerCreateRequest.Sortcode = "150424";
			CustomerCreateRequest.Surname = "Canceld";
			CustomerCreateRequest.WorkPhoneNumber = "";

			DigitalHubModel.Customercreate.clsCustomerCreate Request = assurantApp.CustomerCreateResource;
			Request.SetResponseHandler (new TJResponseHandlerCreate (this));
			Request.SetProgressHandler (new TJProgressHandlerCreate (this));
			Request.Create (CustomerCreateRequest);

			//			DigitalHubModel.Customercreate.Model.CustomerCreate_CustomerCreate_CREATE_REQUEST CustomerCreateRequest = new DigitalHubModel.Customercreate.Model.CustomerCreate_CustomerCreate_CREATE_REQUEST ();
			//			CustomerCreateRequest.Authorization = "Huzzle 14dec742-77a0-46d2-90f6-bdd88735f826.a040a22611d0c3e2de909ecdaae28da8";
			//			CustomerCreateRequest.Company = "halifax";
			//			CustomerCreateRequest.ID = "johnnycrappleseed@ex";
			//
			//			CustomerCreateRequest.AccountNumber = "11000009";
			//			CustomerCreateRequest.AccountParties = "1";
			//
			//			//Customercreate
			//			DigitalHubModel.Customercreate.Model.CustomerCreate_CustomerCreate_CREATE_address_REQUEST CustomerCreateAddressRequest = new DigitalHubModel.Customercreate.Model.CustomerCreate_CustomerCreate_CREATE_address_REQUEST ();
			//			CustomerCreateAddressRequest.CountryCode = "XXX";
			//			CustomerCreateAddressRequest.Line1 = "9 Terrance Square";
			//			CustomerCreateAddressRequest.Line2 = "Carr Bridge";
			//			CustomerCreateAddressRequest.Line3 = "";
			//			CustomerCreateAddressRequest.Line4 = "";
			//			CustomerCreateAddressRequest.Postalcode = "CW1 1AD";
			//
			//			CustomerCreateRequest.Address = CustomerCreateAddressRequest;
			//			CustomerCreateRequest.DateOfBirth = "1975-01-06";
			//			CustomerCreateRequest.EmailAddress = "Michael9.Ferrara9@dev.lifestylegroup.co.uk";
			//			CustomerCreateRequest.Forename ="Michael9";
			//			CustomerCreateRequest.GenderCode = "M";
			//			CustomerCreateRequest.HomePhoneNumber = "01270123464";
			//			CustomerCreateRequest.CustID = "63548729083";
			//			CustomerCreateRequest.MiddleNames = "";
			//			CustomerCreateRequest.MobilePhoneNumber = "07000123456";
			//			CustomerCreateRequest.Password = "TruJunction@3";
			//			CustomerCreateRequest.SalutationCode = "Mr";
			//			CustomerCreateRequest.Sortcode = "141218";
			//			//CustomerCreateRequest.Surname = "Ferrara9";
			//			CustomerCreateRequest.WorkPhoneNumber = "07000123456";
			//
			//			DigitalHubModel.Customercreate.clsCustomerCreate Request = assurantApp.CustomerCreateResource;
			//			Request.SetResponseHandler (new TJResponseHandlerCreate (this));
			//			Request.SetProgressHandler (new TJProgressHandlerCreate (this));
			//			Request.Create (CustomerCreateRequest);

		}
//
		public void RequestGetCustomerWithQuery(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.GetCustomerWithQuery.ToString();
			DigitalHubModel.Getcustomerwithquery.Model.Request.GetCustomer_READ GetCustomerWithQuery = new DigitalHubModel.Getcustomerwithquery.Model.Request.GetCustomer_READ ();
			GetCustomerWithQuery.Authorization = "Huzzle 62f6f9a0-6a02-4302-bbbd-e435799449c4.9fbe3cd40a2ec1912916af9e860cd218";
			GetCustomerWithQuery.ID = "johnnycrappleseed@ex";
			GetCustomerWithQuery.Company = "halifax";
			GetCustomerWithQuery.Forename = "Sally";
			GetCustomerWithQuery.Surname = "Neesom";
			GetCustomerWithQuery.DateOfBirth = "1975-02-08";
			GetCustomerWithQuery.Postalcode = "NG10 1PB";
			//GetCustomerWithQuery.Sortcode = null;
			GetCustomerWithQuery.AccountNumber = "null";
			GetCustomerWithQuery.Representation = "full";

			DigitalHubModel.Getcustomerwithquery.clsGetCustomerWithQuery Request = assurantApp.GetCustomerWithQueryResource;
			Request.SetResponseHandler (new TJResponseHandlerCreate (this));
			Request.SetProgressHandler (new TJProgressHandlerCreate (this));
			Request.Read (GetCustomerWithQuery);
		}
//
		public void RequestEmailPhoneUpdate(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.EmailPhoneUpdate.ToString();
			DigitalHubModel.Emailphoneupdate.Model.Request.CustomerUpdate_UPDATE EmailUpdateReq = new DigitalHubModel.Emailphoneupdate.Model.Request.CustomerUpdate_UPDATE ();
			EmailUpdateReq.Authorization = token;
			EmailUpdateReq.Company = "halifax";
			EmailUpdateReq.ID = userid;
			EmailUpdateReq.CustomerID =custID;
			EmailUpdateReq.EmailAddress =userid;

			EmailUpdateReq.MobilePhoneNumber ="07777777777";
			DigitalHubModel.Emailphoneupdate.clsEmailPhoneUpdate EmailUpdateReqMain = assurantApp.EmailPhoneUpdateResource;
			EmailUpdateReqMain.SetProgressHandler (new TJProgressHandlerCreate (this));
			EmailUpdateReqMain.SetResponseHandler (new TJResponseHandlerCreate (this));
			EmailUpdateReqMain.Update (EmailUpdateReq);
			//EmailUpdateReqMain.Read (EmailUpdateReq);
		}
//
		public void RequestCustomerMiscellaneous(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.CustomerMiscellaneous.ToString();
			DigitalHubModel.Customermiscellaneous.Model.Request.CustomerMiscellaneous_CREATE CustomerMiscellaneousRequest = new DigitalHubModel.Customermiscellaneous.Model.Request.CustomerMiscellaneous_CREATE ();
			CustomerMiscellaneousRequest.Authorization = token;
			CustomerMiscellaneousRequest.Company ="halifax";
			CustomerMiscellaneousRequest.ID = userid;
			CustomerMiscellaneousRequest.CustomerID =custID;
			CustomerMiscellaneousRequest.Type = "mobilephoneverified";

			DigitalHubModel.Customermiscellaneous.clsGetCustomerMiscellaneous Request = assurantApp.CustomerMiscellaneousResource;
			Request.SetResponseHandler (new TJResponseHandlerCreate (this));
			Request.SetProgressHandler (new TJProgressHandlerCreate (this));
			Request.Create (CustomerMiscellaneousRequest);
		}
//
		public void RequestLogoutCreate(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.LogOutCreate.ToString();
			DigitalHubModel.Logoutcreate.Model.Request.LogOut_CREATE LogoutCreateRequest = new DigitalHubModel.Logoutcreate.Model.Request.LogOut_CREATE ();
			LogoutCreateRequest.Authorization = token;
			LogoutCreateRequest.Company = "halifax";
			LogoutCreateRequest.ID = userid;
			LogoutCreateRequest.Username =userid;
			LogoutCreateRequest.Token =token;

			DigitalHubModel.Logoutcreate.clsLogOutCREATE Request = assurantApp.LogOutCREATEResource;
			Request.SetResponseHandler (new TJResponseHandlerCreate (this));
			Request.SetProgressHandler (new TJProgressHandlerCreate (this));
			Request.Create (LogoutCreateRequest);

		}
//
		public void RequestValidateCreateToken(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.ValidateTokenCreate.ToString();
			DigitalHubModel.Validatetokencreate.Model.Request.ValidateToken_CREATE ValidateTokenCreateRequest = new DigitalHubModel.Validatetokencreate.Model.Request.ValidateToken_CREATE ();
			ValidateTokenCreateRequest.Authorization = token;
			ValidateTokenCreateRequest.Company = "halifax";
			ValidateTokenCreateRequest.ID = userid;
			ValidateTokenCreateRequest.Username = userid;
			ValidateTokenCreateRequest.Token = token;
			//DigitalHubModel.Validatetokencreate.clsValidateTokenCREATE Request = new DigitalHubModel.Validatetokencreate.clsValidateTokenCREATE();
			DigitalHubModel.Validatetokencreate.clsValidateTokenCREATE Request = assurantApp.ValidateTokenCREATEResource;
			Request.SetResponseHandler(new TJResponseHandlerCreate(this));
			Request.SetProgressHandler(new TJProgressHandlerCreate(this));
			Request.Create(ValidateTokenCreateRequest);
		}
//
		public void RequestSAML(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.SAML.ToString();
			DigitalHubModel.Samlread.Model.Request.SAML_READ samlReadRequest = new DigitalHubModel.Samlread.Model.Request.SAML_READ ();
			samlReadRequest.CustomerID =custID;
			samlReadRequest.FromSource = "portal";
			samlReadRequest.ToDestination = "mpi";

			samlReadRequest.Authorization = token;
			samlReadRequest.Company = "halifax";
			samlReadRequest.ID = userid;
			DigitalHubModel.Samlread.clsSAMLREAD Request = assurantApp.SAMLREADResource;
			Request.SetResponseHandler(new TJResponseHandlerCreate(this));
			Request.SetProgressHandler(new TJProgressHandlerCreate(this));
			Request.Read(samlReadRequest);
		}
//
		public void RequestCreateMessage(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.CreateMessage.ToString();
			DigitalHubModel.Createmessagecreate.Model.Request.CreateMessage_CREATE createMsgRqst= new DigitalHubModel.Createmessagecreate.Model.Request.CreateMessage_CREATE ();
			createMsgRqst.Authorization = token; //"Huzzle 14dec742-77a0-46d2-90f6-bdd88735f826.a040a22611d0c3e2de909ecdaae28da8";
			createMsgRqst.Company = "halifax";
			createMsgRqst.ID = userid	; //"johnnycrappleseed@ex";

			createMsgRqst.MessageGroup = "BENEFIT";
			createMsgRqst.CustomerID = custID;
			createMsgRqst.MessageType = "Notification";
			createMsgRqst.MessageTitle = "Account Notification";
			createMsgRqst.MessageBody = "This is an alert that will show on your account page/app";
			createMsgRqst.MessageSource = "source";
			createMsgRqst.MessageDestination = "destination";
			createMsgRqst.CreatedDate = "2015-01-22 16:29:00.670";
			createMsgRqst.SnoozeUntilDate = "2015-01-22 16:30:00.671";
			createMsgRqst.ActionedDate = "2015-01-22 16:29:00.672";

			DigitalHubModel.Createmessagecreate.clsMessageCREATE Request = assurantApp.CreateMessageCREATEResource;
			Request.SetResponseHandler(new TJResponseHandlerCreate(this));
			Request.SetProgressHandler(new TJProgressHandlerCreate(this));
			Request.Create(createMsgRqst);
		}

		public void RequestGetMessage(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.GetMessage.ToString ();
			DigitalHubModel.Getmessagesread.Model.Request.GetMessages_READ readMsgRqst= new DigitalHubModel.Getmessagesread.Model.Request.GetMessages_READ ();
			readMsgRqst.Authorization = token; //"Huzzle 14dec742-77a0-46d2-90f6-bdd88735f826.a040a22611d0c3e2de909ecdaae28da8";
			readMsgRqst.Company = "halifax";
			readMsgRqst.ID = "johnnycrappleseed@ex";
			readMsgRqst.CustomerID = "63548728028";

			DigitalHubModel.Getmessagesread.clsMessagesREAD Request = assurantApp.GetMessagesREADResource;
			Request.SetResponseHandler(new TJResponseHandlerCreate(this));
			Request.SetProgressHandler(new TJProgressHandlerCreate(this));
			Request.Read(readMsgRqst);
		}

		public void RequestShasignRead(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.ShaSignRead.ToString ();
			DigitalHubModel.Shasignread.Model.Request.SHASign_READ readShaSign = new DigitalHubModel.Shasignread.Model.Request.SHASign_READ ();
			readShaSign.Destination = "destination9";
			readShaSign.Source = "source9";
			readShaSign.Timestamp = "2014-08-24T23:59:59Z";
			readShaSign.Userid = "laurencenoton";
			readShaSign.Authorization = token;
			readShaSign.Company = "halifax";
			readShaSign.ID = userid;

			DigitalHubModel.Shasignread.clsSHASignREAD Request = assurantApp.SHASignREADResource;
			Request.SetResponseHandler(new TJResponseHandlerCreate(this));
			Request.SetProgressHandler(new TJProgressHandlerCreate(this));
			Request.Read(readShaSign);
		}
		public void RequestKillSwitch(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.KillSwitch.ToString();
			DigitalHubModel.Getswitchstatusassurantdigitalhubread.Model.Request.GetSwitchStatus GetKillSwitch = new DigitalHubModel.Getswitchstatusassurantdigitalhubread.Model.Request.GetSwitchStatus ();
			GetKillSwitch.AppName = "AssurantDigitalHub";

			DigitalHubModel.Getswitchstatusassurantdigitalhubread.GetSwitchStatusAssurantDigitalHubREAD  Request = assurantApp.GetSwitchStatusAssurantDigitalHubREADResource;
			Request.SetResponseHandler(new TJResponseHandlerCreate(this));
			Request.SetProgressHandler(new TJProgressHandlerCreate(this));
			Request.Read(GetKillSwitch);

		}
		public void RequestGetVersion(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.GetVersion.ToString();
			DigitalHubModel.Getappversionassurantdigitalhubread.Model.Request.GetAppVersion  GetVersion = new DigitalHubModel.Getappversionassurantdigitalhubread.Model.Request.GetAppVersion ();
			GetVersion.AppName= "AssurantDigitalHub";

			DigitalHubModel.Getappversionassurantdigitalhubread.GetAppVersionAssurantDigitalHubREAD  Request = assurantApp.GetAppVersionAssurantDigitalHubREADResource;
			Request.SetResponseHandler(new TJResponseHandlerCreate(this));
			Request.SetProgressHandler(new TJProgressHandlerCreate(this));
			Request.Read(GetVersion);

		}
		public void RequestCarDeatilsGet(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.CarDetailsGet.ToString ();
			DigitalHubModel.Cardetailsgetformread.Model.Request.CarDetailsGetForm_READ req = new DigitalHubModel.Cardetailsgetformread.Model.Request.CarDetailsGetForm_READ ();
			req.FormID = "31916";
			req.Company = "halifax";
			req.Authorization = token;
			req.ID = userid;
			req.CustomerID = "73548729544";

			DigitalHubModel.Cardetailsgetformread.clsCarDetailsGetFormREAD formRead = assurantApp.CarDetailsGetFormREADResource;



			//DigitalHubModel.Formdefinitionscardetailsread.clsFormDefinitionsCarDetailsREAD Request = assurantApp.FormDefinitionsCarDetailsREADResource;
			formRead.SetResponseHandler(new TJResponseHandlerCreate(this));
			formRead.SetProgressHandler(new TJProgressHandlerCreate(this));
			formRead.Read(req);
		}

		public void RequestMessageMiscellaneous(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.MessageMiscellaneousUpdate.ToString ();
			DigitalHubModel.Messagesmiscellaneousupdate.Model.Request.MessagesMiscellaneous_UPDATE MiscellaneousRequest= new DigitalHubModel.Messagesmiscellaneousupdate.Model.Request.MessagesMiscellaneous_UPDATE();
			DigitalHubModel.Messagesmiscellaneousupdate.clsMessagesMiscellaneousUPDATE updateMessage = assurantApp.MessagesMiscellaneousUPDATEResource;
			MiscellaneousRequest.CustomerID  = custID;
			MiscellaneousRequest.Authorization =token;
			MiscellaneousRequest.Company="halifax";
			MiscellaneousRequest.ID= userid;
			MiscellaneousRequest.ActionType = "archive";
			MiscellaneousRequest.CustomerID = custID;
			MiscellaneousRequest.MessageID = "465987B7-3144-4DF4-9101-C0FEC075EB39";

			//DigitalHubModel.Createmessagecreate.clsMessageCREATE Request = assurantApp.CreateMessageCREATEResource;
			updateMessage.SetResponseHandler(new TJResponseHandlerCreate(this));
			updateMessage.SetProgressHandler(new TJProgressHandlerCreate(this));
			updateMessage.Update(MiscellaneousRequest);
		}

		public void RequestCarDetailsFormPostDetails(Appmodel.AssurantDigitalHub assurantApp)
		{
			strEPSType = EPSType.CarDetailsFormPostDetails.ToString ();
			DigitalHubModel.Cardetailsformpostcreate.Model.Request.CarDetailsFormPost_CREATE createCar = new DigitalHubModel.Cardetailsformpostcreate.Model.Request.CarDetailsFormPost_CREATE();
			createCar.Authorization = token;
			createCar.Company = "halifax";
			createCar.ID = userid;
			createCar.Formdefinition= "car-details";



			DigitalHubModel.Cardetailsformpostcreate.Model.Request.Fields.Fields carFieldRequest = new DigitalHubModel.Cardetailsformpostcreate.Model.Request.Fields.Fields();
			DigitalHubModel.Cardetailsformpostcreate.Model.Request.Fields.Car.Car fieldsRequest = new DigitalHubModel.Cardetailsformpostcreate.Model.Request.Fields.Car.Car ();
			carFieldRequest.Car = fieldsRequest;
			carFieldRequest.Car.Name = "car1";
			carFieldRequest.Car.RoadTaxDueDate = "2015-04-23 17:10:49.240";


			DigitalHubModel.Cardetailsformpostcreate.Model.Request.Fields.Car.Mot.Mot carMotRequest = new DigitalHubModel.Cardetailsformpostcreate.Model.Request.Fields.Car.Mot.Mot();
			carMotRequest.DueDate = "2015-04-23 17:10:49.240";
			carMotRequest.Garage = "garage";
			carMotRequest.TelephoneNumber = "telephoneNumber";

			DigitalHubModel.Cardetailsformpostcreate.Model.Request.Fields.Car.Service.Service carServiceRequest = new DigitalHubModel.Cardetailsformpostcreate.Model.Request.Fields.Car.Service.Service();
			carServiceRequest.DueDate = "2015-04-23 17:10:49.240";
			carServiceRequest.Garage = "garage";
			carServiceRequest.TelephoneNumber = "telephoneNumber";

			DigitalHubModel.Cardetailsformpostcreate.Model.Request.Fields.Car.Insurance.Insurance carInsurenceRequest = new DigitalHubModel.Cardetailsformpostcreate.Model.Request.Fields.Car.Insurance.Insurance ();
			carInsurenceRequest.RenewalDate = "2015-04-23 17:10:49.240";
			carInsurenceRequest.TelephoneNumber = "telephoneNumber";
			carInsurenceRequest.PolicyNumber = "policyNumber";
			carInsurenceRequest.PolicyCompany = "policyCompany";

			carFieldRequest.Car.Mot = carMotRequest;
			carFieldRequest.Car.Service = carServiceRequest;
			carFieldRequest.Car.Insurance = carInsurenceRequest;

			createCar.Fields = carFieldRequest;

			DigitalHubModel.Cardetailsformpostcreate.clsCarDetailsFormPostCREATE CreateCarRequest = assurantApp.CarDetailsFormPostCREATEResource;
			CreateCarRequest.SetResponseHandler (new TJResponseHandlerCreate (this));
			CreateCarRequest.SetProgressHandler (new TJProgressHandlerCreate (this));
			CreateCarRequest.Create (createCar);
		}

	}
}


