namespace Cliente
{
    partial class frmChat
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
            this.lblHistorial = new System.Windows.Forms.Label();
            this.lblMiembros = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtEnviar = new System.Windows.Forms.TextBox();
            this.lstMiembros = new System.Windows.Forms.ListBox();
            this.rtxHistorial = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorial.Location = new System.Drawing.Point(22, 228);
            this.lblHistorial.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(44, 13);
            this.lblHistorial.TabIndex = 0;
            this.lblHistorial.Text = "Historial";
            // 
            // lblMiembros
            // 
            this.lblMiembros.AutoSize = true;
            this.lblMiembros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiembros.Location = new System.Drawing.Point(505, 228);
            this.lblMiembros.Margin = new System.Windows.Forms.Padding(0);
            this.lblMiembros.Name = "lblMiembros";
            this.lblMiembros.Size = new System.Drawing.Size(52, 13);
            this.lblMiembros.TabIndex = 1;
            this.lblMiembros.Text = "Miembros";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Location = new System.Drawing.Point(22, 28);
            this.btnIniciar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(102, 40);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.Location = new System.Drawing.Point(507, 28);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(104, 40);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(507, 96);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(102, 40);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(507, 148);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(102, 40);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtEnviar
            // 
            this.txtEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnviar.Location = new System.Drawing.Point(22, 78);
            this.txtEnviar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtEnviar.Multiline = true;
            this.txtEnviar.Name = "txtEnviar";
            this.txtEnviar.Size = new System.Drawing.Size(481, 146);
            this.txtEnviar.TabIndex = 6;
            // 
            // lstMiembros
            // 
            this.lstMiembros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMiembros.FormattingEnabled = true;
            this.lstMiembros.Location = new System.Drawing.Point(507, 252);
            this.lstMiembros.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.lstMiembros.Name = "lstMiembros";
            this.lstMiembros.Size = new System.Drawing.Size(121, 238);
            this.lstMiembros.TabIndex = 7;
            // 
            // rtxHistorial
            // 
            this.rtxHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxHistorial.Location = new System.Drawing.Point(22, 252);
            this.rtxHistorial.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.rtxHistorial.Name = "rtxHistorial";
            this.rtxHistorial.Size = new System.Drawing.Size(479, 238);
            this.rtxHistorial.TabIndex = 8;
            this.rtxHistorial.Text = "";
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 520);
            this.Controls.Add(this.rtxHistorial);
            this.Controls.Add(this.lstMiembros);
            this.Controls.Add(this.txtEnviar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.lblMiembros);
            this.Controls.Add(this.lblHistorial);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.558F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmChat";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.Label lblMiembros;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtEnviar;
        private System.Windows.Forms.ListBox lstMiembros;
        private System.Windows.Forms.RichTextBox rtxHistorial;
    }
}

