namespace GoToPdfPage
{
    partial class GoToPageForm
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
            this.cboSuggestions = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboSuggestions
            // 
            this.cboSuggestions.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSuggestions.FormattingEnabled = true;
            this.cboSuggestions.Location = new System.Drawing.Point(13, 13);
            this.cboSuggestions.Name = "cboSuggestions";
            this.cboSuggestions.Size = new System.Drawing.Size(259, 21);
            this.cboSuggestions.TabIndex = 0;
            this.cboSuggestions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CboSuggestions_KeyUp);
            // 
            // PDFPageJump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 45);
            this.Controls.Add(this.cboSuggestions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PDFPageJump";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gehe zur Seite:";
            this.Load += new System.EventHandler(this.Window_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSuggestions;
    }
}