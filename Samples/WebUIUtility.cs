using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Dwolla.Samples
{
    public class WebUIUtility
    {
        public static Table BuildFieldDescTable(IEnumerable<Tuple<string, string>> dataRows)
        {
            Table table = new Table();
            TableHeaderRow thr = new TableHeaderRow();
            TableCell hc1 = new TableCell();
            TableCell hc2 = new TableCell();
            hc1.Text = "Field";
            hc2.Text = "Description";
            thr.Cells.Add(hc1);
            thr.Cells.Add(hc2);

            foreach (Tuple<string, string> dataRow in dataRows)
            {
                TableRow r = new TableRow();
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                c1.Text = dataRow.Item1;
                c2.Text = dataRow.Item2;
                r.Cells.Add(c1);
                r.Cells.Add(c2);
                table.Rows.Add(r);
            }

            return table;
        }

        public static Literal HorizontalLine()
        {
            var hr = new Literal();
            hr.Text = "<hr>";
            return hr;
        }
    }
}