namespace PicArchive
{
    partial class Form_SelectDatabase
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
            this.textBox_DatabasePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Ok = new System.Windows.Forms.Button();
            this.button_SelectDatabasePath = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // textBox_DatabasePath
            // 
            this.textBox_DatabasePath.Location = new System.Drawing.Point(12, 37);
            this.textBox_DatabasePath.Name = "textBox_DatabasePath";
            this.textBox_DatabasePath.Size = new System.Drawing.Size(198, 20);
            this.textBox_DatabasePath.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "Pfad zur Programmdatenbank:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_Cancel.Location = new System.Drawing.Point(168, 78);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 90;
            this.button_Cancel.Text = "Abbrechen";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_Ok
            // 
            this.button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Ok.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_Ok.Location = new System.Drawing.Point(12, 78);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(75, 23);
            this.button_Ok.TabIndex = 89;
            this.button_Ok.Text = "Ok";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.Button_Ok_Click);
            // 
            // button_SelectDatabasePath
            // 
            this.button_SelectDatabasePath.Location = new System.Drawing.Point(216, 37);
            this.button_SelectDatabasePath.Name = "button_SelectDatabasePath";
            this.button_SelectDatabasePath.Size = new System.Drawing.Size(27, 20);
            this.button_SelectDatabasePath.TabIndex = 96;
            this.button_SelectDatabasePath.Text = "...";
            this.button_SelectDatabasePath.UseVisualStyleBackColor = true;
            this.button_SelectDatabasePath.Click += new System.EventHandler(this.Button_SelectDatabasePath_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Dialog_SelectDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 113);
            this.Controls.Add(this.button_SelectDatabasePath);
            this.Controls.Add(this.textBox_DatabasePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog_SelectDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programmdatenbank auswählen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_DatabasePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.Button button_SelectDatabasePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}