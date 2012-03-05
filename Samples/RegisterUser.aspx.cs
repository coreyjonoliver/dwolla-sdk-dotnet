namespace Dwolla.Samples
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Web;
    using DotNetOpenAuth.OAuth2;
    using Dwolla.API;

    public partial class RegisterUser : System.Web.UI.Page
    {
        private static readonly DwollaClient client = new DwollaClient
        {
            ClientIdentifier = ConfigurationManager.AppSettings["dwollaAppID"],
            ClientSecret = ConfigurationManager.AppSettings["dwollaAppSecret"],
        };

        protected void Page_Load(object sender, EventArgs e)
        {
                var response = client.RegisterUser(
                    client.ClientIdentifier, 
                    client.ClientSecret,
                    true,
                    "test@test.com", 
                    "d8Ce#2f3Db", 
                    1111, 
                    "Test", 
                    "User", 
                    "Des Moines", 
                    "IA",
                    "11111",
                    8001234567,
                    new DateTime(1990,6,1),
                    "111 Test St. NW",
                    "Ste 510", 
                    AccountInformationType.COMMERCIAL,
                    "Test Company",
                    12345);
                var table = WebUIUtility.BuildFieldDescTable(
                    new Tuple<string, string>[] {
                        Tuple.Create("Id", response.Id),
                        Tuple.Create("Name", response.Name),
                        Tuple.Create("Latitude", response.Latitude.ToString()),
                        Tuple.Create("Longitude", response.Longitude.ToString()),
                        Tuple.Create("Type", response.Type.ToString()),
                        Tuple.Create("City", response.City),
                        Tuple.Create("State", response.State)
                    });

                this.regHolder.Controls.Add(table);
        }
    }
}