using Microsoft.AspNet.Mvc.Facebook;

// Add any fields you want to be saved for each user and specify the field name in the JSON coming back from Facebook
// https://developers.facebook.com/docs/reference/api/user/

namespace SampleFacebookCanvasApplication.Models
{
    public class MyAppUserFriend
    {
        public string Name { get; set; }

        public FacebookConnection<FacebookPicture> Picture { get; set; }
    }
}
