namespace ColorCoded
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxReadImage = new System.Windows.Forms.Button();
            this.uxOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.uxWriteMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxReadImage
            // 
            this.uxReadImage.Location = new System.Drawing.Point(67, 357);
            this.uxReadImage.Name = "uxReadImage";
            this.uxReadImage.Size = new System.Drawing.Size(401, 195);
            this.uxReadImage.TabIndex = 0;
            this.uxReadImage.Text = "Decode File";
            this.uxReadImage.UseVisualStyleBackColor = true;
            this.uxReadImage.Click += new System.EventHandler(this.uxReadImage_Click);
            // 
            // uxWriteMessage
            // 
            this.uxWriteMessage.Location = new System.Drawing.Point(67, 89);
            this.uxWriteMessage.Name = "uxWriteMessage";
            this.uxWriteMessage.Size = new System.Drawing.Size(401, 195);
            this.uxWriteMessage.TabIndex = 1;
            this.uxWriteMessage.Text = "Encode File";
            this.uxWriteMessage.UseVisualStyleBackColor = true;
            this.uxWriteMessage.Click += new System.EventHandler(this.uxWriteMessage_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 655);
            this.Controls.Add(this.uxWriteMessage);
            this.Controls.Add(this.uxReadImage);
            this.Name = "UserInterface";
            this.Text = "Color Coded";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxReadImage;
        private System.Windows.Forms.OpenFileDialog uxOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog uxSaveFileDialog;
        private System.Windows.Forms.Button uxWriteMessage;
    }
}

