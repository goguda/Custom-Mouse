using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CustomMouseService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomMousePipeService" in both code and config file together.
    [ServiceContract]
    public interface ICustomMousePipeService
    {
        //[OperationContract]
        //ButtonSetting GetButtonSetting(int buttonNumber);
        //[OperationContract]
        //void SetButtonSetting(int buttonNumber, ButtonSetting toSet);
        [OperationContract]
        int Test();
    }
}
