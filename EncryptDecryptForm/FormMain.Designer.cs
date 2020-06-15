namespace EnryptDecryptForm
{
    partial class FormMain
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelEncrypt = new System.Windows.Forms.Label();
            this.richTextBoxEncrypt = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDecrypt = new System.Windows.Forms.RichTextBox();
            this.labelDecrypt = new System.Windows.Forms.Label();
            this.ButtonEncrypt = new System.Windows.Forms.Button();
            this.ButtonDecrypt = new System.Windows.Forms.Button();
            this.richTextBoxKey = new System.Windows.Forms.RichTextBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelEncrypt
            // 
            this.labelEncrypt.AutoSize = true;
            this.labelEncrypt.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelEncrypt.Location = new System.Drawing.Point(12, 9);
            this.labelEncrypt.Name = "labelEncrypt";
            this.labelEncrypt.Size = new System.Drawing.Size(141, 17);
            this.labelEncrypt.TabIndex = 0;
            this.labelEncrypt.Text = "Text do zakodowania";
            // 
            // richTextBoxEncrypt
            // 
            this.richTextBoxEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxEncrypt.Location = new System.Drawing.Point(15, 29);
            this.richTextBoxEncrypt.Name = "richTextBoxEncrypt";
            this.richTextBoxEncrypt.Size = new System.Drawing.Size(773, 96);
            this.richTextBoxEncrypt.TabIndex = 1;
            this.richTextBoxEncrypt.Text = "";
            // 
            // richTextBoxDecrypt
            // 
            this.richTextBoxDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDecrypt.Location = new System.Drawing.Point(15, 153);
            this.richTextBoxDecrypt.Name = "richTextBoxDecrypt";
            this.richTextBoxDecrypt.Size = new System.Drawing.Size(773, 96);
            this.richTextBoxDecrypt.TabIndex = 3;
            this.richTextBoxDecrypt.Text = "";
            // 
            // labelDecrypt
            // 
            this.labelDecrypt.AutoSize = true;
            this.labelDecrypt.ForeColor = System.Drawing.Color.Crimson;
            this.labelDecrypt.Location = new System.Drawing.Point(12, 133);
            this.labelDecrypt.Name = "labelDecrypt";
            this.labelDecrypt.Size = new System.Drawing.Size(142, 17);
            this.labelDecrypt.TabIndex = 2;
            this.labelDecrypt.Text = "Text do odkodowania";
            // 
            // ButtonEncrypt
            // 
            this.ButtonEncrypt.Location = new System.Drawing.Point(12, 415);
            this.ButtonEncrypt.Name = "ButtonEncrypt";
            this.ButtonEncrypt.Size = new System.Drawing.Size(75, 23);
            this.ButtonEncrypt.TabIndex = 4;
            this.ButtonEncrypt.Text = "Zakoduj";
            this.ButtonEncrypt.UseVisualStyleBackColor = true;
            this.ButtonEncrypt.Click += new System.EventHandler(this.ButtonEncrypt_Click);
            // 
            // ButtonDecrypt
            // 
            this.ButtonDecrypt.Location = new System.Drawing.Point(93, 415);
            this.ButtonDecrypt.Name = "ButtonDecrypt";
            this.ButtonDecrypt.Size = new System.Drawing.Size(75, 23);
            this.ButtonDecrypt.TabIndex = 5;
            this.ButtonDecrypt.Text = "Odkoduj";
            this.ButtonDecrypt.UseVisualStyleBackColor = true;
            this.ButtonDecrypt.Click += new System.EventHandler(this.ButtonDecrypt_Click);
            // 
            // richTextBoxKey
            // 
            this.richTextBoxKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxKey.Location = new System.Drawing.Point(12, 275);
            this.richTextBoxKey.Name = "richTextBoxKey";
            this.richTextBoxKey.Size = new System.Drawing.Size(773, 96);
            this.richTextBoxKey.TabIndex = 7;
            this.richTextBoxKey.Text = "";
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.ForeColor = System.Drawing.Color.Crimson;
            this.labelKey.Location = new System.Drawing.Point(9, 255);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(42, 17);
            this.labelKey.TabIndex = 6;
            this.labelKey.Text = "Klucz";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBoxKey);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.ButtonDecrypt);
            this.Controls.Add(this.ButtonEncrypt);
            this.Controls.Add(this.richTextBoxDecrypt);
            this.Controls.Add(this.labelDecrypt);
            this.Controls.Add(this.richTextBoxEncrypt);
            this.Controls.Add(this.labelEncrypt);
            this.Name = "FormMain";
            this.Text = "Zakoduj odkoduj";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEncrypt;
        private System.Windows.Forms.RichTextBox richTextBoxEncrypt;
        private System.Windows.Forms.RichTextBox richTextBoxDecrypt;
        private System.Windows.Forms.Label labelDecrypt;
        private System.Windows.Forms.Button ButtonEncrypt;
        private System.Windows.Forms.Button ButtonDecrypt;
        private System.Windows.Forms.RichTextBox richTextBoxKey;
        private System.Windows.Forms.Label labelKey;
    }
}

