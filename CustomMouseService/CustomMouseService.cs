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
    public partial class CustomMouseService : ServiceBase
    {
        internal static ServiceHost host = null;
        public CustomMouseService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (host != null)
            {
                host.Close();
            }
        }

        protected override void OnStop()
        {
        }
    }
}
