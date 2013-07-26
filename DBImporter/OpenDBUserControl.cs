using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBImporter
{
    public partial class OpenDBUserControl : UserControl
    {
       public AccessReader reader;

        public OpenDBUserControl()
        {
            InitializeComponent();
        }        
    }
}
