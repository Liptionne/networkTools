using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;

namespace networkScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            networkTools.listAllInterfacesWithIPs();

            string resultatPing = networkTools.PingAdresse("127.0.0.1");
            Debug.WriteLine(resultatPing);
        }
    }
}