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

    public partial class UserContacts : System.Web.UI.Page
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
                client.RequestUserAuthorization(new Scope[] { Scope.CONTACTS });
            }
            else
            {
                var contacts = client.Contacts(authorization.AccessToken);

                if (!contacts.Any())
                {
                    var l = new Label();
                    l.Text = "No contacts found.";
                    this.contactsHolder.Controls.Add(l);
                }
                else
                {
                    foreach (ContactsResult contact in contacts)
                    {
                        var table = WebUIUtility.BuildFieldDescTable(
                        new Tuple<string, string>[] {
                    Tuple.Create("Id", contact.Id),
                    Tuple.Create("Name", contact.Name),
                    Tuple.Create("Image", contact.Image),
                    Tuple.Create("Type", contact.Type.Value),
                    }
                        );

                        this.contactsHolder.Controls.Add(table);
                        this.contactsHolder.Controls.Add(WebUIUtility.HorizontalLine());
                    }
                }
            }
        }
    }
}