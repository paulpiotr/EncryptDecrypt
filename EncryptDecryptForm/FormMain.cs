using System;
using System.Windows.Forms;

namespace EnryptDecryptForm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            richTextBoxDecrypt.Text = EnryptDecrypt.EnryptDecrypt.EncryptString(richTextBoxEncrypt.Text, richTextBoxKey.Text);
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            richTextBoxEncrypt.Text = EnryptDecrypt.EnryptDecrypt.DecryptString(richTextBoxDecrypt.Text, richTextBoxKey.Text);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            richTextBoxKey.Text = EnryptDecrypt.EnryptDecrypt.GetRsaFileContent();
        }
    }
}
