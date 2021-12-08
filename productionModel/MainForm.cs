using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace productionModel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            HashSet<string> r = new HashSet<string>();
            r.Add("a");
            r.Add("b");
            r.Add("c");
            foreach (var item in r)
            {
                checkedFactsBox.Items.Add(item);
            }
        }
    }
}
