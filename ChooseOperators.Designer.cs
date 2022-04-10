namespace machineTuring
{
    partial class ChooseOperators
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.operatorsMenu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.operatorsMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // operatorsMenu
            // 
            this.operatorsMenu.AllowUserToResizeColumns = false;
            this.operatorsMenu.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.operatorsMenu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.operatorsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.operatorsMenu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.operatorsMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operatorsMenu.Location = new System.Drawing.Point(12, 14);
            this.operatorsMenu.Name = "operatorsMenu";
            this.operatorsMenu.RowHeadersWidth = 20;
            this.operatorsMenu.RowTemplate.Height = 24;
            this.operatorsMenu.Size = new System.Drawing.Size(450, 47);
            this.operatorsMenu.TabIndex = 0;
            this.operatorsMenu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.operatorsMenu_CellContentClick);
            // 
            // ChooseOperators
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 73);
            this.Controls.Add(this.operatorsMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChooseOperators";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выберите символ";
            ((System.ComponentModel.ISupportInitialize)(this.operatorsMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView operatorsMenu;
    }
}