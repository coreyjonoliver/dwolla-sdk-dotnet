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

    public partial class TransactionsListing : System.Web.UI.Page
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
                client.RequestUserAuthorization(new Scope[] { Scope.TRANSACTIONS });
            }
            else
            {
                var transactions = client.TransactionsListing(authorization.AccessToken);

                if (!transactions.Any())
                {
                    var l = new Label();
                    l.Text = "No transactions found";
                    this.transactionsHolder.Controls.Add(l);
                }
                else
                {
                    foreach (TransactionsResult transaction in transactions)
                    {
                        var table = WebUIUtility.BuildFieldDescTable(
                        new Tuple<string, string>[] {
                            Tuple.Create("Id", transaction.Id),
                            Tuple.Create("Date", transaction.Date.ToString()),
                            Tuple.Create("Amount", transaction.Amount.ToString()),
                            Tuple.Create("DestinationId", transaction.DestinationId),
                            Tuple.Create("DestinationName", transaction.DestinationName),
                            Tuple.Create("SourceId", transaction.SourceId),
                            Tuple.Create("SourceName", transaction.SourceName),
                            Tuple.Create("SourceType", transaction.Type.Value),
                            Tuple.Create("UserType", transaction.UserType.Value),
                            Tuple.Create("Status", transaction.Status.Value),
                            Tuple.Create("ClearingDate", transaction.ClearingDate.ToString()),
                        }
                        );

                        this.transactionsHolder.Controls.Add(table);
                        this.transactionsHolder.Controls.Add(WebUIUtility.HorizontalLine());

                    }
                }
            }
        }
    }
}