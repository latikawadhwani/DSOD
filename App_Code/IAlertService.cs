using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlertService" in both code and config file together.
[ServiceContract]
public interface IAlertService
{
    [OperationContract]
    string storeUserDetails(string first, string last, string email, string stock, string path);
    [OperationContract]
    void sendAlerts(string path);
    [OperationContract]
    void sendMail(List<string> l);
}
