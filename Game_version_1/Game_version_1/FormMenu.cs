using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_version_1
{
    public partial class FormMenu : Form
    {
        Game1 g;
        public FormMenu()
        {
            InitializeComponent();
        }
        private void start_Click(object sender, EventArgs e)
        {
          //  FormServer fs = new FormServer();
            //fs.Show();
                g = new Game1();
                g.ShowDialog();
            
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnServer_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
