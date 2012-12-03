using Microsoft.AspNet.Mvc.Facebook;

// Add any fields you want to be saved for each user and specify the field name in the JSON coming back from Facebook
// https://developers.facebook.com/docs/reference/api/user/

namespace SampleFacebookCanvasApplication.Models
{
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
}
