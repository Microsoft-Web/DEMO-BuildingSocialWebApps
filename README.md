Building Social Web Apps in ASP.NET
================================================

<a name="outline" />
## Outline
* Demonstrate how to setup an ASP.NET MVC app to use a Microsoft Account for Authentication
* Demonstrate how to create a Facebook App using the new Facebook template in ASP.NET MVC

<a name="demo-preparation" />
## Demo Preperation
- You must have the [ASP.NET Fall 2012 Update BUILD Prerelease](http://www.microsoft.com/en-us/download/details.aspx?id=35493) installed

<a name="demo1-oauth" />
## ASP.NET MVC with OAuth

1. In the Windows Azure Portal create a new Web Site with a database. You can name it whatever you like. Remember the name as you will use it later to configure the Microsoft Account settings.

	![create-web-site](images/create-web-site.png?raw=true)

1. After the website is created open the site and download the publish profile.

	![download-publish-profile](images/download-publish-profile.png?raw=true)

1. In Visual Studio, create a new ASP.NET MVC 4 Web Application, and name it "OAuthMVC". You can target either .NET Framework 4.5 or 4.

	![create-project](images/create-project.png?raw=true)

1. In the New ASP.NET MVC 4 Project window, select **Internet Application** and leave **Razor** as the view engine.

	![internet-application](images/internet-application.png?raw=true)

1. Open **App_Start/AuthConfig.cs**.

	![auth-config](images/auth-config.png?raw=true)

1. Uncomment the lines to register a Microsoft client as shown below.

<!-- mark:8-10 -->
````C#
public static class AuthConfig
{
    public static void RegisterAuth()
    {
        // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
        // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

        OAuthWebSecurity.RegisterMicrosoftClient(
            clientId: "",
            clientSecret: "");

        //OAuthWebSecurity.RegisterTwitterClient(
        //    consumerKey: "",
        //    consumerSecret: "");

        //OAuthWebSecurity.RegisterFacebookClient(
        //    appId: "",
        //    appSecret: "");

        //OAuthWebSecurity.RegisterGoogleClient();
    }
}
````

1. In Internet Explorer, navigate to [https://manage.dev.live.com/Applications/Index](https://manage.dev.live.com/Applications/Index)

1. Complete the form to create your application. You can name the application whatever you like. 

	> **Note:**: If you already have existing Live apps you will need to click to create a new application.

	![create-live-app](images/create-live-app.png?raw=true)

1. Once your application is create you need to set the redirect domain to the url of the Windows Azure Web SIte you created at the beginning of this demo.

	![live-app-settings](images/live-app-settings.png?raw=true)

1. Save the settings and copy the Client ID and Client secret values to the code in the AuthConfig.cs file as shown below.

<!-- mark:9-10 -->
````C#
public static class AuthConfig
{
    public static void RegisterAuth()
    {
        // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
        // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

        OAuthWebSecurity.RegisterMicrosoftClient(
            clientId: "your_client_id_here",
            clientSecret: "your_client_secret_here");

        //OAuthWebSecurity.RegisterTwitterClient(
        //    consumerKey: "",
        //    consumerSecret: "");

        //OAuthWebSecurity.RegisterFacebookClient(
        //    appId: "",
        //    appSecret: "");

        //OAuthWebSecurity.RegisterGoogleClient();
    }
}
````

1. Next, you will deploy your application to Windows Azure. Right click on the project and click Publish.

	![publish-website](images/publish-website.png?raw=true)

1. Import the publish profile you downloaded ealier and click Publish.

	![publish](images/publish.png?raw=true)

1. Once the site is published it will open in the browser. Click *Log In** and then click **Microsoft**.

	![login-with-microsoft-account](images/login-with-microsoft-account.png?raw=true)

1. Sign in with your Microsoft Account.

	![microsoft-account-credentials](images/microsoft-account-credentials.png?raw=true)

1. Allow access to the applicatoin by clicking **Yes**.

	![allow-access](images/allow-access.png?raw=true)

1. Register your account by clicking **Register**.

	![register-account](images/register-account.png?raw=true)

1. You are now logged in with your Microsoft Account.

	![signed-in](images/signed-in.png?raw=true)

<a name="demo2-facebook" />
## ASP.NET MVC Facebook Template

<span style="color: Red; font-size: 20px; font-weight: bold;">NOTICE: Do not share the source code of this demo outside of Microsoft. This is pre-release code. The final delivery of this source will ship with the ASP.NET Fall 2012 Update RC in a few weeks.</span>

1. In Visual Studio, create a new ASP.NET MVC 4 application and select Facebook App.

	![create-mvc-app](images/create-mvc-app.png?raw=true)

1. Select Facebook Application.	

	![facebook-applicatoin-template](images/facebook-applicatoin-template.png?raw=true)

1. Open your web browser and go to https://developers.facebook.com/apps.

	![create-facebook-app](images/create-facebook-app.png?raw=true)

1. Click "Create New App" and enter your app name and namespace.

	> This name must be unique across Facebook. Also, add an App Namespace. This is the unique part of the URL that people will use to access your Facebook App (e.g. https://apps.facebook.com/{App Namespace}). Click continue.

	![create-new-app-dialog](images/create-new-app-dialog.png?raw=true)

1. Next, edit your new Facebook app's canvas settings. Set the Canvas Url to **http://localhost:54950/** and set the Secure Canvas Url to **http://localhost:54950/**.

	![canvas-url](images/canvas-url.png?raw=true)

1. Now copy the App ID and App Secret values (pictured below).

	![appid-appsecret](images/appid-appsecret.png?raw=true)

1. Close your the Facebook Application you created in the previous steps and open the **source\SampleFacebookCanvasApplication.sln** solution from this demo.

	> **NOTE:** This is a temporary step until the Facebook Applicatoin Template ships in RC form. 

1. Paste the above values into the Web.config in the root of your new Facebook app template as show below.

	````xml
	<appSettings>
	  <add key="webpages:Version" value="2.0.0.0" />
	  <add key="webpages:Enabled" value="false" />
	  <add key="PreserveLoginUrl" value="true" />
	  <add key="ClientValidationEnabled" value="true" />
	  <add key="UnobtrusiveJavaScriptEnabled" value="true" />
	  <add key="Facebook:AppId" value="your_app_id_here" />
	  <add key="Facebook:AppSecret" value="your_app_secret_here" />
	  <add key="Facebook:AppNamespace" value="your_app_namespace_here" />
	  <add key="Facebook:AuthorizationRedirectPath" value="Home/Permissions" />
	  <add key="Facebook:VerifyToken:User" value="" />
	</appSettings>
	````

1. Run the application (Ctrl+F5). When the applicatoin first loads you will be prompted to authorize the application. Click **Go to App**

	![app-authorize](images/app-authorize.png?raw=true)

1. When you are redirected to the app, you will see a dialog notifying you the the content was blocked due to an invalid certificate. Click **Show Content**.
	
	> This dialog is show because we are using a self-signed SSL certificate for the application. In production you would great a SLL certificate from a trusted authority and your users would not see this issue.

	![show-content](images/show-content.png?raw=true)

1. Next you will see a page that informs you that you must grant permissions to the application. Click **Grant permissions on Facebook**

	![grant-permissions](images/grant-permissions.png?raw=true)

1. Click **Allow** to continue.

	![grant-permissoins-dialog](images/grant-permissoins-dialog.png?raw=true)

1. You will now see a page that shows your name, profile picture, email, birthday, and a list of 5 friends.

	![app-profile-page](images/app-profile-page.png?raw=true)

1. In Visual Studio, open the **HomeController.cs**. 

	> Talk about the FacebookAuthorize attribute and the FacebookContext. Discuss how the FacebookContext object gives you access to the current user's information such as their user Id and access token. The FacebookContext also gives you access to an instance of FacebookClient that can be used to query Facebook's Graph API.

	````C#
	[FacebookAuthorize("email", "user_birthday")]
	public async Task<ActionResult> Index(FacebookContext context)
	{
		 if (ModelState.IsValid)
		 {
			  var user = await context.Client.GetCurrentUserAsync<MyAppUser>();
			  return View(user);
		 }

		 return View("Error");
	}
	````

1. Discuss the extention methods that exist in the Microsoft.AspNet.Mvc.Facebook library that enhance the Facebook C# SDK. 

	> This extension menthod allows you to easily query information about the current user. The extension method automatically builds the Graph API query based on the model provided and returns a strongly-typed object.

	````C#
			  var user = await context.Client.GetCurrentUserAsync<MyAppUser>();
			  return View(user);
	````

1. Open the **MyAppUser.cs** object in the Models folder. 

	> Discuss how the properties are automatically mapped and how the attributes provide for filtering of the Graph API. For example, in the object below the FacebookFieldModifier attribute sets the picture to be of type(large) so the url is of the larger size profile picture rather than the default.

	````C#
	public class MyAppUser
	{
		 public string Id { get; set; }
		 public string Name { get; set; }
		 public string Email { get; set; }
		 public string Birthday { get; set; }

		 [FacebookFieldModifier("type(large)")] // This help you specify the picture size to large.
		 public FacebookConnection<FacebookPicture> Picture { get; set; }

		 [FacebookFieldModifier("limit(5)")] // This help you limit the friend list to 5, remove it to get all friends.
		 public FacebookGroupConnection<MyAppUserFriend> Friends { get; set; }
	}
	````



	




