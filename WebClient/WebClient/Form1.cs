using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace WebClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri(this.txtUrl.Text, UriKind.Absolute);
            System.Net.WebClient webClient = new System.Net.WebClient();

            //方法一
            //webClient.OpenReadAsync(uri);
            //webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);

            //方法二
            var response = webClient.OpenRead(uri);
            if (response != null) this.picBox.Image=new Bitmap(response);
            
            //其它方法自行测试...
        }

        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            Stream stream = e.Result;
            Image img = new Bitmap(stream);
            this.picBox.Image = img;
        }
    }
}
