using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {

    }
    protected void btnUplaod_Click(object sender, EventArgs e)
    {
        ServiceReferenceFileUpload.UploadFileServiceClient clientUpload = new ServiceReferenceFileUpload.UploadFileServiceClient();
        string path=clientUpload.UploadFile(txtFilePath.Text);
        Label1.Text = "your file is uploaded at " + path;
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string path = System.Web.HttpContext.Current.Server.MapPath("~/StoreUserInfo.xml");
        ServiceReferenceAlert.AlertServiceClient c1 = new ServiceReferenceAlert.AlertServiceClient();
        c1.sendAlerts(path);
        
    }
}