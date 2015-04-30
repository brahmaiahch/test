package assurantapplication;


public class HomeActivity_TJResponseHandlerCreate
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.cognizant.trumobi.appintegration.clientsdk.handlers.TJResponseHandler,
		com.cognizant.trumobi.appintegration.clientsdk.handlers.TJHandler
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onError:(Lcom/cognizant/trumobi/appintegration/clientsdk/db/Entity;)V:GetOnError_Lcom_cognizant_trumobi_appintegration_clientsdk_db_Entity_Handler:Com.Cognizant.Trumobi.Appintegration.Clientsdk.Handlers.ITJResponseHandlerInvoker, AndroidSDKLibrary\n" +
			"n_onSuccess:(Ljava/lang/Object;)V:GetOnSuccess_Ljava_lang_Object_Handler:Com.Cognizant.Trumobi.Appintegration.Clientsdk.Handlers.ITJResponseHandlerInvoker, AndroidSDKLibrary\n" +
			"";
		mono.android.Runtime.register ("AssurantApplication.HomeActivity/TJResponseHandlerCreate, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", HomeActivity_TJResponseHandlerCreate.class, __md_methods);
	}


	public HomeActivity_TJResponseHandlerCreate () throws java.lang.Throwable
	{
		super ();
		if (getClass () == HomeActivity_TJResponseHandlerCreate.class)
			mono.android.TypeManager.Activate ("AssurantApplication.HomeActivity/TJResponseHandlerCreate, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public HomeActivity_TJResponseHandlerCreate (assurantapplication.HomeActivity p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == HomeActivity_TJResponseHandlerCreate.class)
			mono.android.TypeManager.Activate ("AssurantApplication.HomeActivity/TJResponseHandlerCreate, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "AssurantApplication.HomeActivity, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void onError (com.cognizant.trumobi.appintegration.clientsdk.db.Entity p0)
	{
		n_onError (p0);
	}

	private native void n_onError (com.cognizant.trumobi.appintegration.clientsdk.db.Entity p0);


	public void onSuccess (java.lang.Object p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (java.lang.Object p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
