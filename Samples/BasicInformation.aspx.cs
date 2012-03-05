namespace Dwolla.Samples
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Web;
    using DotNetOpenAuth.OAuth2;
    using Dwolla.API;

    public partial class BasicInformation : System.Web.UI.Page
    {
        private static readonly DwollaClient client = new DwollaClient
        {
            ClientIdentifier = ConfigurationManager.AppSettings["dwollaAppID"],
            ClientSecret = ConfigurationManager.AppSettings["dwollaAppSecret"],
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            var accountInfo = client.BasicInformation(client.ClientIdentifier, client.ClientSecret, "812-111-1111");
            var table = WebUIUtility.BuildFieldDescTable(
                        new Tuple<string, string>[] {
                            Tuple.Create("Id", accountInfo.Id),
                            Tuple.Create("Name", accountInfo.Name),
                            Tuple.Create("Latitude", accountInfo.Latitude.ToString()),
                            Tuple.Create("Longitude", accountInfo.Longitude.ToString()),
                        }
                        );

            this.accountInfoHolder.Controls.Add(table);
            this.accountInfoHolder.Controls.Add(WebUIUtility.HorizontalLine());
        }
    }
}