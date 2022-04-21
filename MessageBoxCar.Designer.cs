namespace machineTuring
{
    partial class MessageBoxCar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxCar));
            this.textMessage = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.imageListCars = new System.Windows.Forms.ImageList(this.components);
            this.panelPictures = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // textMessage
            // 
            this.textMessage.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textMessage.Location = new System.Drawing.Point(75, 232);
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(232, 25);
            this.textMessage.TabIndex = 1;
            this.textMessage.Text = "TEXTTEXTIITEXTTYYYYYUUUUUEXTTEXT";
            this.textMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(47)))), ((int)(((byte)(37)))));
            this.buttonOK.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOK.ForeColor = System.Drawing.Color.White;
            this.buttonOK.Location = new System.Drawing.Point(155, 275);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(66, 30);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // imageListCars
            // 
            this.imageListCars.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCars.ImageStream")));
            this.imageListCars.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCars.Images.SetKeyName(0, "Success.jpg");
            this.imageListCars.Images.SetKeyName(1, "imgonline-com-ua-Resize-ANyypPNG7t.jpg");
            // 
            // panelPictures
            // 
            this.panelPictures.BackColor = System.Drawing.Color.Transparent;
            this.panelPictures.Location = new System.Drawing.Point(43, 25);
            this.panelPictures.Name = "panelPictures";
            this.panelPictures.Size = new System.Drawing.Size(287, 179);
            this.panelPictures.TabIndex = 3;
            // 
            // MessageBoxCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(392, 315);
            this.Controls.Add(this.panelPictures);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textMessage);
            this.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MessageBoxCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Внимание";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label textMessage;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ImageList imageListCars;
        private System.Windows.Forms.Panel panelPictures;
    }
}