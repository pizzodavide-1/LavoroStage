namespace GraphicViewer
{
    partial class Form1
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
            this.buttonImportGraphic = new System.Windows.Forms.Button();
            this.pictureBoxGrafico = new System.Windows.Forms.PictureBox();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrafico)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonImportGraphic
            // 
            this.buttonImportGraphic.Location = new System.Drawing.Point(444, 58);
            this.buttonImportGraphic.Name = "buttonImportGraphic";
            this.buttonImportGraphic.Size = new System.Drawing.Size(102, 23);
            this.buttonImportGraphic.TabIndex = 1;
            this.buttonImportGraphic.Text = "Importa grafico";
            this.buttonImportGraphic.UseVisualStyleBackColor = true;
            this.buttonImportGraphic.Click += new System.EventHandler(this.buttonImportGraphic_Click);
            // 
            // pictureBoxGrafico
            // 
            this.pictureBoxGrafico.Location = new System.Drawing.Point(12, 87);
            this.pictureBoxGrafico.Name = "pictureBoxGrafico";
            this.pictureBoxGrafico.Size = new System.Drawing.Size(534, 227);
            this.pictureBoxGrafico.TabIndex = 4;
            this.pictureBoxGrafico.TabStop = false;
            this.pictureBoxGrafico.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGrafico_Paint);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(63, 36);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(451, 20);
            this.textBoxFilePath.TabIndex = 7;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(520, 34);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(26, 23);
            this.buttonBrowse.TabIndex = 8;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "FilePath:";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 326);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBoxGrafico);
            this.Controls.Add(this.buttonImportGraphic);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrafico)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonImportGraphic;
        private System.Windows.Forms.PictureBox pictureBoxGrafico;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

