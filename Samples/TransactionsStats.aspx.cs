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

    public partial class TransactionsStats : System.Web.UI.Page
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
                var transactionstat = client.TransactionsStats(
                    authorization.AccessToken,
                    new TransactionStatsType[] { TransactionStatsType.TRANSACTIONSCOUNT, TransactionStatsType.TRANSACTIONSTOTAL },
                    new DateTime(2011, 6, 1),
                    new DateTime(2011, 6, 15));

                if (transactionstat == null)
                {
                    var l = new Label();
                    l.Text = "No transaction stat found";
                    this.transactionstatHolder.Controls.Add(l);
                }
                else
                {
                    var table = WebUIUtility.BuildFieldDescTable(
                    new Tuple<string, string>[] {
                            Tuple.Create("TransactionsCount", transactionstat.TransactionsCount.ToString()),
                            Tuple.Create("TransactionsTotal", transactionstat.TransactionsTotal.ToString()),
                        });

                    this.transactionstatHolder.Controls.Add(table);
                    this.transactionstatHolder.Controls.Add(WebUIUtility.HorizontalLine());
                }

            }
        }
    }
}