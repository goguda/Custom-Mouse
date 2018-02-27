using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CustomMouseService
{
    partial class CustomMouseService : ServiceBase
    {

        internal static ServiceHost customMouseServiceHost;
        private static CustomMouseService instance;

        private CustomMouseService()
        {
            InitializeComponent();
        }

        public static CustomMouseService GetInstance()
        {
            if (instance == null)
            {
                instance = new CustomMouseService();
            }

            return instance;
        }

        public void run()
        {
            OSController.MoveCursor(100, 100);
        }

        protected override void OnStart(string[] args)
        {
            if (customMouseServiceHost != null)
            {
                customMouseServiceHost.Close();
            }

            customMouseServiceHost = new ServiceHost(typeof(CustomMousePipeService));
            customMouseServiceHost.Open();
        }

        protected override void OnStop()
        {
            if (customMouseServiceHost != null)
            {
                customMouseServiceHost.Close();
                customMouseServiceHost = null;
            }
        }

        
    }
}
