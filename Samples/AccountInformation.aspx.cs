namespace Dwolla.Samples
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Web;
    using DotNetOpenAuth.OAuth2;
    using Dwolla.API;

    public partial class AccountInformation : System.Web.UI.Page
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
                client.RequestUserAuthorization(new Scope[] { Scope.ACCOUNTINFOFULL });
            }
            else
            {
                var accountInfo = client.AccountInformation(authorization.AccessToken);
                var table = WebUIUtility.BuildFieldDescTable(
                            new Tuple<string, string>[] {
                            Tuple.Create("Id", accountInfo.Id),
                            Tuple.Create("Name", accountInfo.Name),
                            Tuple.Create("Latitude", accountInfo.Latitude.ToString()),
                            Tuple.Create("Longitude", accountInfo.Longitude.ToString()),
                            Tuple.Create("Type", accountInfo.Type.Value),
                            Tuple.Create("City", accountInfo.City),
                            Tuple.Create("State", accountInfo.State),
                        }
                            );

                this.accountInfoHolder.Controls.Add(table);
                this.accountInfoHolder.Controls.Add(WebUIUtility.HorizontalLine());
            }
        }
    }
}