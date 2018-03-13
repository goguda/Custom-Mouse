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
        private string name;
        private string path;

        [NonSerialized]
        private Icon icon;

        public ProgramInfo(string name, string path, Icon icon)
        {
            this.name = name;
            this.path = path;
            this.icon = icon;
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
