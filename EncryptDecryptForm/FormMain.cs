using System;
using System.Windows.Forms;

namespace EncryptDecryptForm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            richTextBoxDecrypt.Text = EncryptDecrypt.EncryptDecrypt.EncryptString(richTextBoxEncrypt.Text, richTextBoxKey.Text);
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            richTextBoxEncrypt.Text = EncryptDecrypt.EncryptDecrypt.DecryptString(richTextBoxDecrypt.Text, richTextBoxKey.Text);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            richTextBoxKey.Text = EncryptDecrypt.EncryptDecrypt.GetRsaFileContent() ?? string.Empty;
        }
    }
}
