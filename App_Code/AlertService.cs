using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Net.Mail;
using System.Xml.Linq;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlertService" in code, svc and config file together.
public class AlertService : IAlertService
{
    //store user details in a xml file
    public string storeUserDetails(string first, string last, string email, string stock, string path)
    {
        string message = "";
        System.Xml.XmlDocument doc1 = new XmlDocument();
        {
            try
            {
                //string path = System.Web.HttpContext.Current.Server.MapPath("~/StoreUserInfo.xml");
                //doc1.Load(@"C:\Users\Latika\Desktop\DSOD-Assignment 3\StoreUserInfo.xml");
                doc1.Load(path);
                XmlNode XmlRootNode = doc1.SelectSingleNode("records");
                XmlNode XmlRecordNode = XmlRootNode.AppendChild(
                    doc1.CreateNode(XmlNodeType.Element, "records", ""));
                XmlRecordNode.AppendChild(doc1.CreateNode(XmlNodeType.Element,
                    "FirstName", "")).InnerText = first;


                XmlRecordNode.AppendChild(doc1.CreateNode(XmlNodeType.Element,
                    "LastName", "")).InnerText = last;

                XmlRecordNode.AppendChild(doc1.CreateNode(XmlNodeType.Element,
                    "Email", "")).InnerText = email;
                string s = stock;
                string[] s_arr = s.Split(';');
                for (int i = 0; i < s_arr.Count(); i++)
                {
                    XmlRecordNode.AppendChild(doc1.CreateNode(XmlNodeType.Element,
                    "s" + i, "")).InnerText = s_arr[i];
                }
                //doc1.Save(@"C:\Users\Latika\Desktop\DSOD-Assignment 3\StoreUserInfo.xml");
                doc1.Save(path);//save file
                message = "details saved successfully";
                return message;
            }

            catch (Exception ex)
            {
                message = "error!! please try again";
                return message;
            }
        }
    }
    //send alerts at a particular time. this method reads details from xml file in a list and calls a method to send mail to all subscribers
    public void sendAlerts(string path)
    {
        //string path = System.Web.HttpContext.Current.Server.MapPath("~/StoreUserInfo.xml");
        //System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader("C:\\Users\\Latika\\Desktop\\DSOD-Assignment 3\\StoreUserInfo.xml");
        System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(path);

        List<string> cont = new List<string>();
        string contents = "";
        while (reader.Read())
        {
            reader.MoveToContent();
            if (reader.NodeType == System.Xml.XmlNodeType.Element)
                contents += "<" + reader.Name + ">\n";

            if (reader.NodeType == System.Xml.XmlNodeType.Text)
            {
                contents += reader.Value + "\n";
                cont.Add(reader.Value);
            }
        }

        sendMail(cont);

    }
    public void sendMail(List<string> l)
    {
        for (int i = 0; i < l.Count; i++)

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.Body = "hello " + l[i].ToString() + " " + l[i + 1].ToString();
                mail.From = new MailAddress("testxyz477@gmail.com");
                mail.To.Add(l[i + 2].ToString());
                mail.Subject = "Test Mail";
                mail.Body += "\n";

                string[] ss = l[i + 3].ToString().Split(';');
                for (int j = 0; j < ss.Count(); j++)
                {
                    ServiceReference1.StockQuoteSoapClient client3 = new ServiceReference1.StockQuoteSoapClient();
                    string st = client3.GetQuote(ss[j].ToString());
                    string str =
@"<?xml version=""1.0""?>" + "<root>" + st + "</root>";
                    XDocument doc = XDocument.Parse(str);
                    string sym = doc.Root.Element("StockQuotes").Element("Stock").Element("Symbol").Value;
                    mail.Body += "Symbol=" + sym + "\n";
                    String last = doc.Root.Element("StockQuotes").Element("Stock").Element("Last").Value;
                    mail.Body += "Last=" + last + "\n";
                    String d = doc.Root.Element("StockQuotes").Element("Stock").Element("Date").Value;
                    mail.Body += "Date=" + d + "\n";
                    String t = doc.Root.Element("StockQuotes").Element("Stock").Element("Time").Value;
                    mail.Body += "Time=" + t + "\n";
                    String c = doc.Root.Element("StockQuotes").Element("Stock").Element("Change").Value;
                    mail.Body += "Change=" + c + "\n";
                    String o = doc.Root.Element("StockQuotes").Element("Stock").Element("Open").Value;
                    mail.Body += "Open=" + o + "\n";
                    String h = doc.Root.Element("StockQuotes").Element("Stock").Element("High").Value;
                    mail.Body += "High=" + h + "\n";
                    String lw = doc.Root.Element("StockQuotes").Element("Stock").Element("Low").Value;
                    mail.Body += "Low=" + lw + "\n";
                    String vol = doc.Root.Element("StockQuotes").Element("Stock").Element("Volume").Value;
                    mail.Body += "Volume=" + vol + "\n";
                    String MktCap = doc.Root.Element("StockQuotes").Element("Stock").Element("MktCap").Value;
                    mail.Body += "MktCAp=" + MktCap + "\n";
                    String prev = doc.Root.Element("StockQuotes").Element("Stock").Element("PreviousClose").Value;
                    mail.Body += "Previous Close=" + prev + "\n";
                    String pc = doc.Root.Element("StockQuotes").Element("Stock").Element("PercentageChange").Value;
                    mail.Body += "Percentage Change=" + pc + "\n";
                    String an = doc.Root.Element("StockQuotes").Element("Stock").Element("AnnRange").Value;
                    mail.Body += "Annual Range=" + an + "\n";
                    String earns = doc.Root.Element("StockQuotes").Element("Stock").Element("Earns").Value;
                    mail.Body += "Earns=" + earns + "\n";
                }
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("testxyz477", "Kishan123");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                i = i + 3;
            }
            catch (Exception ex)
            {

            }
    }
  

}
