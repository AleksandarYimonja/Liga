
namespace Liga
{
    partial class Meni
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.meceviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.igraciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sezonuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meceviToolStripMenuItem,
            this.igraciToolStripMenuItem,
            this.dodajToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // meceviToolStripMenuItem
            // 
            this.meceviToolStripMenuItem.Name = "meceviToolStripMenuItem";
            this.meceviToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.meceviToolStripMenuItem.Text = "Mecevi";
            this.meceviToolStripMenuItem.Click += new System.EventHandler(this.meceviToolStripMenuItem_Click);
            // 
            // igraciToolStripMenuItem
            // 
            this.igraciToolStripMenuItem.Name = "igraciToolStripMenuItem";
            this.igraciToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.igraciToolStripMenuItem.Text = "Igraci";
            this.igraciToolStripMenuItem.Click += new System.EventHandler(this.igraciToolStripMenuItem_Click);
            // 
            // dodajToolStripMenuItem
            // 
            this.dodajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klubToolStripMenuItem,
            this.sezonuToolStripMenuItem});
            this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            this.dodajToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.dodajToolStripMenuItem.Text = "Dodaj";
            // 
            // klubToolStripMenuItem
            // 
            this.klubToolStripMenuItem.Name = "klubToolStripMenuItem";
            this.klubToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.klubToolStripMenuItem.Text = "Klub";
            this.klubToolStripMenuItem.Click += new System.EventHandler(this.klubToolStripMenuItem_Click);
            // 
            // sezonuToolStripMenuItem
            // 
            this.sezonuToolStripMenuItem.Name = "sezonuToolStripMenuItem";
            this.sezonuToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sezonuToolStripMenuItem.Text = "Sezonu";
            this.sezonuToolStripMenuItem.Click += new System.EventHandler(this.sezonuToolStripMenuItem_Click);
            // 
            // Meni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 319);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Meni";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem meceviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem igraciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sezonuToolStripMenuItem;
    }
}

