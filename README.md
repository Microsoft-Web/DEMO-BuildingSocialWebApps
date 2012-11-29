DEMO-BuildingAndLeveragingSocialServicesInAspNet
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

The Facebook template is currently in transition. 

For now this demo should be used: http://www.asp.net/vnext/overview/fall-2012-update/facebook-application-template-tutorial

This demo script will be updated in a few days after the RC version of the Facebook Template is ready.
