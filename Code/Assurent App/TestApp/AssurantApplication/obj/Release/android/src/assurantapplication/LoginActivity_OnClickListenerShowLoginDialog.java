package assurantapplication;


public class LoginActivity_OnClickListenerShowLoginDialog
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnClickListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("AssurantApplication.LoginActivity/OnClickListenerShowLoginDialog, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LoginActivity_OnClickListenerShowLoginDialog.class, __md_methods);
	}


	public LoginActivity_OnClickListenerShowLoginDialog () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LoginActivity_OnClickListenerShowLoginDialog.class)
			mono.android.TypeManager.Activate ("AssurantApplication.LoginActivity/OnClickListenerShowLoginDialog, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public LoginActivity_OnClickListenerShowLoginDialog (assurantapplication.LoginActivity p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == LoginActivity_OnClickListenerShowLoginDialog.class)
			mono.android.TypeManager.Activate ("AssurantApplication.LoginActivity/OnClickListenerShowLoginDialog, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "AssurantApplication.LoginActivity, AssurantApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);

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
