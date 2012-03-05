namespace Dwolla.Samples
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Web;
    using DotNetOpenAuth.OAuth2;
    using Dwolla.API;

    public partial class AccountBalance : System.Web.UI.Page
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
                client.RequestUserAuthorization(new Scope[] {Scope.BALANCE});
            }
            else
            {
                var balance = client.AccountBalance(authorization.AccessToken);
                this.nameLabel.Text = HttpUtility.HtmlEncode(balance);
            }
        }
    }
}