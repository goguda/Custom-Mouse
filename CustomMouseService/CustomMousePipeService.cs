using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CustomMouseService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomMousePipeService" in both code and config file together.
    public class CustomMousePipeService : ICustomMousePipeService
    {
        //public void SetButtonSetting(int buttonNumber, ButtonSetting toSet)
       // {

        //}

      /*  public ButtonSetting GetButtonSetting(int buttonNumber)
        {
            return null;
        }*/

        public int Test()
        {
            CustomMouseService.GetInstance().run();
            return 4;
        }
    }
}
