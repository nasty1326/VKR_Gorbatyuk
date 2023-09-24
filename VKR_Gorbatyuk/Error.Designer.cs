namespace VKR_Gorbatyuk
{
    partial class FormError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormError));
            this.lbNameError = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbNameError
            // 
            this.lbNameError.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbNameError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbNameError.Location = new System.Drawing.Point(0, 0);
            this.lbNameError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNameError.Name = "lbNameError";
            this.lbNameError.Size = new System.Drawing.Size(584, 86);
            this.lbNameError.TabIndex = 0;
            this.lbNameError.Text = "label1";
            this.lbNameError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNameError.Click += new System.EventHandler(this.lbNameError_Click);
            // 
            // lbError
            // 
            this.lbError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbError.Location = new System.Drawing.Point(0, 86);
            this.lbError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(584, 155);
            this.lbError.TabIndex = 1;
            this.lbError.Text = "label1";
            this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbError.Click += new System.EventHandler(this.lbError_Click);
            // 
            // FormError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 241);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.lbNameError);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormError";
            this.Text = "Ошибка";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbNameError;
        private System.Windows.Forms.Label lbError;
    }
}