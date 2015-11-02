using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml;

public partial class user : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Response.ContentType = "APPLICATION/OCTET-STREAM";
        String Header = "Attachment; Filename=stocks.xlsx";
        Response.AppendHeader("Content-Disposition", Header);
        string downloadPAth = System.Web.Hosting.HostingEnvironment.MapPath("~/FileStore/") + "stocks.xlsx";
        System.IO.FileInfo Dfile = new System.IO.FileInfo(downloadPAth);
        Response.WriteFile(Dfile.FullName);
        //Don't forget to add the following line
        Response.End();
    }

    protected void btnSubscribe_Click(object sender, EventArgs e)
    {
        string path = System.Web.HttpContext.Current.Server.MapPath("~/StoreUserInfo.xml");
        ServiceReferenceAlert.AlertServiceClient c = new ServiceReferenceAlert.AlertServiceClient();
        string m = c.storeUserDetails(txtName.Text, txtLastNAme.Text, txtEmail.Text, txtSymbol.Text, path);
        txtShow.Text = m;
    }
    protected void btnSsubmit_Click(object sender, EventArgs e)
    {
        String symbol   = txtsymbolBox.Text;
            String sDate    = txtstartBox.Text;
            String eDate    = txtendBox.Text;
            char[] del      = {' ', '/', '-'};

            String[] sDateComponents    = sDate.Split(del);
            String[] eDateComponents    = eDate.Split(del);

            int sMonth      = Int32.Parse(sDateComponents[0]);
            int sDay        = Int32.Parse(sDateComponents[1]);
            int sYear       = Int32.Parse(sDateComponents[2]);

            int eMonth      = Int32.Parse(eDateComponents[0]);
            int eDay        = Int32.Parse(eDateComponents[1]);
            int eYear       = Int32.Parse(eDateComponents[2]);
            
            
            HttpWebRequest request      = (HttpWebRequest)WebRequest.Create(string.Format("http://localhost:50054/StockHandle.svc/GetStockHistory/GetStockHistory?symbol={0}&startMonth={1}&startDay={2}&startYear={3}&endMonth={4}&endDay={5}&endYear={6}", symbol, sMonth, sDay, sYear, eMonth, eDay, eYear));
            HttpWebResponse response    = request.GetResponse() as HttpWebResponse;
            Stream responseStream       = response.GetResponseStream();
            StreamReader reader         = new StreamReader(responseStream);

            XmlDocument doc             = new XmlDocument();
            doc.Load(reader);

            XmlNodeList nodes           = doc.GetElementsByTagName("string");
            XmlNode node                = nodes[0];
            String output               = node.InnerText;

            txtoutputBox.Text=output;
        }
    }
    }
}
