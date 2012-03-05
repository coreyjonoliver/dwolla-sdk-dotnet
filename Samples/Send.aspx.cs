namespace Dwolla.Samples
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Web;
    using DotNetOpenAuth.OAuth2;
    using Dwolla.API;

    public partial class Send : System.Web.UI.Page
    {
        private static readonly DwollaClient client = new DwollaClient
        {
            ClientIdentifier = ConfigurationManager.AppSettings["dwollaAppID"],
            ClientSecret = ConfigurationManager.AppSettings["dwollaAppSecret"],
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            IAuthorizationState authorization = client.ProcessUserAuthorization();
            if (authorization == null)
            {
                client.RequestUserAuthorization(new Scope[] { Scope.SEND });
            }
            else
            {
                var send = client.Send(authorization.AccessToken, 1111, "812-111-1111", null, 1, 0, null, "Test");
                this.sendLabel.Text = HttpUtility.HtmlEncode(send);
            }
        }
    }
}