using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMouseController
{
    [Serializable]
    public class ProgramInfo
    {
        string name;
        private string path;
        private Icon icon;

        public ProgramInfo(string name, Icon icon, string path)
        {
            this.name = name;
            this.icon = icon;
            this.path = path;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        public Icon Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
            }
        }
    }
}
