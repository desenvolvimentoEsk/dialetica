namespace Dialetica
{
    partial class Dash
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dash));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iniciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sincronizadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cedetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.montalotecapaTesteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.complementosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeVirgulaDeNomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarToolStripMenuItem,
            this.testesToolStripMenuItem,
            this.complementosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(330, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iniciarToolStripMenuItem
            // 
            this.iniciarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sincronizadorToolStripMenuItem,
            this.cedetToolStripMenuItem});
            this.iniciarToolStripMenuItem.Name = "iniciarToolStripMenuItem";
            this.iniciarToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.iniciarToolStripMenuItem.Text = "Iniciar";
            // 
            // sincronizadorToolStripMenuItem
            // 
            this.sincronizadorToolStripMenuItem.Name = "sincronizadorToolStripMenuItem";
            this.sincronizadorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sincronizadorToolStripMenuItem.Text = "Sincronizador";
            this.sincronizadorToolStripMenuItem.Click += new System.EventHandler(this.sincronizadorToolStripMenuItem_Click);
            // 
            // cedetToolStripMenuItem
            // 
            this.cedetToolStripMenuItem.Name = "cedetToolStripMenuItem";
            this.cedetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cedetToolStripMenuItem.Text = "Cedet";
            this.cedetToolStripMenuItem.Click += new System.EventHandler(this.cedetToolStripMenuItem_Click);
            // 
            // testesToolStripMenuItem
            // 
            this.testesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nomeToolStripMenuItem,
            this.montalotecapaTesteToolStripMenuItem});
            this.testesToolStripMenuItem.Name = "testesToolStripMenuItem";
            this.testesToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.testesToolStripMenuItem.Text = "testes";
            this.testesToolStripMenuItem.Visible = false;
            // 
            // nomeToolStripMenuItem
            // 
            this.nomeToolStripMenuItem.Name = "nomeToolStripMenuItem";
            this.nomeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.nomeToolStripMenuItem.Text = "nome";
            this.nomeToolStripMenuItem.Click += new System.EventHandler(this.nomeToolStripMenuItem_Click);
            // 
            // montalotecapaTesteToolStripMenuItem
            // 
            this.montalotecapaTesteToolStripMenuItem.Name = "montalotecapaTesteToolStripMenuItem";
            this.montalotecapaTesteToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.montalotecapaTesteToolStripMenuItem.Text = "montalotecapa teste";
            this.montalotecapaTesteToolStripMenuItem.Click += new System.EventHandler(this.montalotecapaTesteToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(59, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 126);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // complementosToolStripMenuItem
            // 
            this.complementosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeVirgulaDeNomeToolStripMenuItem});
            this.complementosToolStripMenuItem.Name = "complementosToolStripMenuItem";
            this.complementosToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.complementosToolStripMenuItem.Text = "complementos";
            // 
            // removeVirgulaDeNomeToolStripMenuItem
            // 
            this.removeVirgulaDeNomeToolStripMenuItem.Name = "removeVirgulaDeNomeToolStripMenuItem";
            this.removeVirgulaDeNomeToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.removeVirgulaDeNomeToolStripMenuItem.Text = "remove virgula de nome";
            this.removeVirgulaDeNomeToolStripMenuItem.Click += new System.EventHandler(this.removeVirgulaDeNomeToolStripMenuItem_Click);
            // 
            // Dash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 282);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialetica";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iniciarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sincronizadorToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem testesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem montalotecapaTesteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cedetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem complementosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeVirgulaDeNomeToolStripMenuItem;
    }
}

