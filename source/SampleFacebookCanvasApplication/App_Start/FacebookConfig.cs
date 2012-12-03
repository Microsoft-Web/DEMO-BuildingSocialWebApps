using System;
using System.Web.Mvc;
using Microsoft.AspNet.Mvc.Facebook;
using Microsoft.AspNet.Mvc.Facebook.Authorization;

namespace SampleFacebookCanvasApplication
{
    public static class FacebookConfig
    {
        public static void Register(FacebookConfiguration configuration)
        {
            // Loads the settings from web.config using the following app setting keys:
            // Facebook:AppId, Facebook:AppSecret, Facebook:AppNamespace
            configuration.LoadFromAppSettings();

            // Adding the authorization filter to handle all FacebookAuthorize attributes
            GlobalFilters.Filters.Add(new FacebookAuthorizeFilter(configuration));
        }
    }
}
