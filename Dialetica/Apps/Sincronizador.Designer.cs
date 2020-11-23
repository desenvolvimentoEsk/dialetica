namespace Dialetica.Apps
{
    partial class Sincronizador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sincronizador));
            this.btn_iniciar = new System.Windows.Forms.Button();
            this.backgroundWorker_iniciaProcesso = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_enviaImpressora = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_MontaloteCapa = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_MontaloteMiolo = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_iniciar
            // 
            this.btn_iniciar.Location = new System.Drawing.Point(66, 91);
            this.btn_iniciar.Name = "btn_iniciar";
            this.btn_iniciar.Size = new System.Drawing.Size(165, 34);
            this.btn_iniciar.TabIndex = 0;
            this.btn_iniciar.Text = "Iniciar";
            this.btn_iniciar.UseVisualStyleBackColor = true;
            this.btn_iniciar.Click += new System.EventHandler(this.btn_iniciar_Click);
            // 
            // backgroundWorker_iniciaProcesso
            // 
            this.backgroundWorker_iniciaProcesso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_iniciaProcesso_DoWork);
            // 
            // backgroundWorker_enviaImpressora
            // 
            this.backgroundWorker_enviaImpressora.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_enviaImpressora_DoWork);
            // 
            // backgroundWorker_MontaloteCapa
            // 
            this.backgroundWorker_MontaloteCapa.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_MontaloteCapa_DoWork);
            // 
            // backgroundWorker_MontaloteMiolo
            // 
            this.backgroundWorker_MontaloteMiolo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_MontaloteMiolo_DoWork);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(90, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Sincronizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 137);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_iniciar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sincronizador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sincronizador Dialetica";
            this.Load += new System.EventHandler(this.Sincronizador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_iniciar;
        private System.ComponentModel.BackgroundWorker backgroundWorker_iniciaProcesso;
        private System.ComponentModel.BackgroundWorker backgroundWorker_enviaImpressora;
        private System.ComponentModel.BackgroundWorker backgroundWorker_MontaloteCapa;
        private System.ComponentModel.BackgroundWorker backgroundWorker_MontaloteMiolo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}