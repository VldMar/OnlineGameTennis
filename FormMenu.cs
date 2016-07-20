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
        SocketManagment sock;
        Game1 g;// = new SocketManagment("192.168.0.9", 8005);
        public FormMenu()
        {
            InitializeComponent();
        }

        private void DisableAll()
        {
            portBox.Enabled = false;
            ipBox.Enabled = false;
            start.Enabled = false;
        }

        private void EnabledAll()
        {
            portBox.Enabled = true;
            ipBox.Enabled = true;
            start.Enabled = true;
        }
        private void ConnectAsServ(string ip, int port)
        {
            sock = new SocketManagment(ip, port);
            if(sock.StartAsServer())
            {
                g = new Game1();
                g.ShowDialog();
            }
        }

        private void ConnectAsClient(string ip, int port)
        {
            sock = new SocketManagment(ip, port);
            if(sock.StartAsClient())
            {
                g = new Game1();
                g.ShowDialog();
            }
        }
        private void start_Click(object sender, EventArgs e)
        {
            //DisableAll();
            try
            {

                if (btnServer.Enabled == true)
                {
                    ConnectAsServ(ipBox.Text, int.Parse(portBox.Text));
                }
                else if (btnClient.Enabled == true)
                {
                    ConnectAsClient(ipBox.Text, int.Parse(portBox.Text));
                }

                else start.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           /* if (btnServer.Enabled == true)
            {
                sock.StartAsServer();
                Game1 g = new Game1();
                g.ShowDialog();
            }
            else if(btnClient.Enabled==true)
            {
                sock.StartAsClient();
            }*/
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
