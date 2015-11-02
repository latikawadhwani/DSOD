using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UploadFileService" in code, svc and config file together.
public class UploadFileService : IUploadFileService
{
	public string UploadFile(string fileName)
    {


        string oldfileName = Path.GetFileName(fileName);
        //String path="C:\\Users\\Latika\\Desktop\\DSOD-Assignment 3\\StorageService\\";
        //fileName = path + fileName;


        FileStream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        BinaryReader br = new BinaryReader(fStream);

        FileInfo fInfo = new FileInfo(fileName);
        long numBytes = fInfo.Length;
        double dLen = Convert.ToDouble(fInfo.Length / 1000000);

        
        byte[] data = br.ReadBytes((int)numBytes);
        br.Close();
        
        try
        {
            
            MemoryStream ms = new MemoryStream(data);

           
            string uploadPAth = System.Web.Hosting.HostingEnvironment.MapPath("~/FileStore/") + oldfileName;
            FileStream fs = new FileStream(uploadPAth, FileMode.Create);

            
            ms.WriteTo(fs);

          
            ms.Close();
            fs.Close();
            fs.Dispose();

            
            return uploadPAth;
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }
}
