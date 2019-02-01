namespace ClienteCorre
{
    partial class frmClienteCorre
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlPanel
            // 
            this.pnlPanel.Location = new System.Drawing.Point(12, 99);
            this.pnlPanel.Name = "pnlPanel";
            this.pnlPanel.Size = new System.Drawing.Size(587, 382);
            this.pnlPanel.TabIndex = 0;
            this.pnlPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);
            // 
            // frmClienteCorre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 420);
            this.Controls.Add(this.pnlPanel);
            this.Name = "frmClienteCorre";
            this.Text = "Cliente Corre";
            this.Load += new System.EventHandler(this.frmClienteCorre_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPanel;
    }
}

