package assurantapplication;


public class HomeActivity_TJProgressHandlerCreate
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.cognizant.trumobi.appintegration.clientsdk.handlers.TJProgressHandler,
		com.cognizant.trumobi.appintegration.clientsdk.handlers.TJHandler
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_dismissProgress:()V:GetDismissProgressHandler:Com.Cognizant.Trumobi.Appintegration.Clientsdk.Handlers.ITJProgressHandlerInvoker, AndroidSDKLibrary\n" +
			"n_setProgressPercent:([Ljava/lang/String;)V:GetSetProgressPercent_arrayLjava_lang_String_Handler:Com.Cognizant.Trumobi.Appintegration.Clientsdk.Handlers.ITJProgressHandlerInvoker, AndroidSDKLibrary\n" +
			"n_setUpProgress:()V:GetSetUpProgressHandler:Com.Cognizant.Trumobi.Appintegration.Clientsdk.Handlers.ITJProgressHandlerInvoker, AndroidSDKLibrary\n" +
			"";
		mono.android.Runtime.register ("AssurantApplication.HomeActivity/TJProgressHandlerCreate, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", HomeActivity_TJProgressHandlerCreate.class, __md_methods);
	}


	public HomeActivity_TJProgressHandlerCreate () throws java.lang.Throwable
	{
		super ();
		if (getClass () == HomeActivity_TJProgressHandlerCreate.class)
			mono.android.TypeManager.Activate ("AssurantApplication.HomeActivity/TJProgressHandlerCreate, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public HomeActivity_TJProgressHandlerCreate (assurantapplication.HomeActivity p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == HomeActivity_TJProgressHandlerCreate.class)
			mono.android.TypeManager.Activate ("AssurantApplication.HomeActivity/TJProgressHandlerCreate, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "AssurantApplication.HomeActivity, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void dismissProgress ()
	{
		n_dismissProgress ();
	}

	private native void n_dismissProgress ();


	public void setProgressPercent (java.lang.String[] p0)
	{
		n_setProgressPercent (p0);
	}

	private native void n_setProgressPercent (java.lang.String[] p0);


	public void setUpProgress ()
	{
		n_setUpProgress ();
	}

	private native void n_setUpProgress ();

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
