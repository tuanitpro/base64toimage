using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBase64toImage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                Image img = Helper.Base64ToImage(richTextBox1.Text);
                pictureBox1.Image = img;
                if (img != null)
                {
                    SaveFileDialog sdg = new SaveFileDialog();
                    sdg.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|All files (*.*)|*.*";
                    if (sdg.ShowDialog() == DialogResult.OK)
                    {
                        img.Save(sdg.FileName);
                    }
                }
            }
        }

        private void btnImageToBase64_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|All files (*.*)|*.*";
            if (dlg.ShowDialog()== DialogResult.OK)
            {
                pictureBox1.Load(dlg.FileName);
                var image = Image.FromFile(dlg.FileName);
                if (image != null)
                {
                    string base64 = Helper.ImageToBase64(image, ImageFormat.Jpeg);
                    richTextBox1.Text = base64;
                }
            }
        }
    }
}
