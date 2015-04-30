package assurantapplication;


public class LoginActivity_TjHandler
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.cognizant.trumobi.appintegration.clientsdk.handlers.TJDBHandler
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_dbOperFailure:(I)V:GetDbOperFailure_IHandler:Com.Cognizant.Trumobi.Appintegration.Clientsdk.Handlers.ITJDBHandlerInvoker, AndroidSDKLibrary\n" +
			"n_dbOperSuccess:(ILjava/lang/Object;)V:GetDbOperSuccess_ILjava_lang_Object_Handler:Com.Cognizant.Trumobi.Appintegration.Clientsdk.Handlers.ITJDBHandlerInvoker, AndroidSDKLibrary\n" +
			"";
		mono.android.Runtime.register ("AssurantApplication.LoginActivity/TjHandler, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LoginActivity_TjHandler.class, __md_methods);
	}


	public LoginActivity_TjHandler () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LoginActivity_TjHandler.class)
			mono.android.TypeManager.Activate ("AssurantApplication.LoginActivity/TjHandler, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public LoginActivity_TjHandler (assurantapplication.LoginActivity p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == LoginActivity_TjHandler.class)
			mono.android.TypeManager.Activate ("AssurantApplication.LoginActivity/TjHandler, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "AssurantApplication.LoginActivity, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void dbOperFailure (int p0)
	{
		n_dbOperFailure (p0);
	}

	private native void n_dbOperFailure (int p0);


	public void dbOperSuccess (int p0, java.lang.Object p1)
	{
		n_dbOperSuccess (p0, p1);
	}

	private native void n_dbOperSuccess (int p0, java.lang.Object p1);

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
