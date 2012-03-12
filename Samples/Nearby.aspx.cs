namespace Dwolla.Samples
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.UI.WebControls;
    using DotNetOpenAuth.OAuth2;
    using Dwolla.API;

    public partial class Nearby : System.Web.UI.Page
    {
        private static readonly DwollaClient client = new DwollaClient
        {
            ClientIdentifier = ConfigurationManager.AppSettings["dwollaAppID"],
            ClientSecret = ConfigurationManager.AppSettings["dwollaAppSecret"],
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            var nearby = client.Nearby(client.ClientIdentifier, client.ClientSecret, new Decimal(41.58454600), new Decimal(-93.63416700));

            if (!nearby.Any())
            {
                var l = new Label();
                l.Text = "No spots found.";
                this.nearbyHolder.Controls.Add(l);
            }
            else
            {
                foreach (NearbyResult spot in nearby)
                {
                    var table = WebUIUtility.BuildFieldDescTable(
                    new Tuple<string, string>[] {
                    Tuple.Create("Id", spot.Id),
                    Tuple.Create("Name", spot.Name),
                    Tuple.Create("Latitude", spot.Latitude.ToString()),
                    Tuple.Create("Longitude", spot.Longitude.ToString()),
                    Tuple.Create("Address", spot.Address),
                    Tuple.Create("City", spot.City),
                    Tuple.Create("State", spot.State),
                    Tuple.Create("PostalCode", spot.PostalCode),
                    Tuple.Create("Group", string.Join(",", spot.Group)),
                    Tuple.Create("Image", spot.Image)
                    }
                    );

                    this.nearbyHolder.Controls.Add(table);
                    this.nearbyHolder.Controls.Add(WebUIUtility.HorizontalLine());
                }
            }
        }
    }
}