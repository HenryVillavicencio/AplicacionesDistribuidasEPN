namespace Cliente
{
    partial class frmCliente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResolver = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTexto = new System.Windows.Forms.CheckBox();
            this.txtTextoAEnviar = new System.Windows.Forms.TextBox();
            this.txtIPServidor = new System.Windows.Forms.TextBox();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnActualizarBinario = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtBinarioEnviar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnProbar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.txtRecibidoBinario = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConectar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPuerto);
            this.groupBox1.Controls.Add(this.txtIPServidor);
            this.groupBox1.Controls.Add(this.btnResolver);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtServidor);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 189);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conexión:";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(9, 49);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(185, 20);
            this.txtServidor.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de Equipo";
            // 
            // btnResolver
            // 
            this.btnResolver.Location = new System.Drawing.Point(119, 75);
            this.btnResolver.Name = "btnResolver";
            this.btnResolver.Size = new System.Drawing.Size(75, 23);
            this.btnResolver.TabIndex = 2;
            this.btnResolver.Text = "Resolver";
            this.btnResolver.UseVisualStyleBackColor = true;
            this.btnResolver.Click += new System.EventHandler(this.btnResolver_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtBinarioEnviar);
            this.groupBox2.Controls.Add(this.btnActualizarBinario);
            this.groupBox2.Controls.Add(this.btnEnviar);
            this.groupBox2.Controls.Add(this.txtTextoAEnviar);
            this.groupBox2.Controls.Add(this.chkTexto);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 296);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Envío:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Puede emplear catacteres hexadecimales separados por espacio o solamente texto";
            // 
            // chkTexto
            // 
            this.chkTexto.AutoSize = true;
            this.chkTexto.Checked = true;
            this.chkTexto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTexto.Location = new System.Drawing.Point(416, 19);
            this.chkTexto.Name = "chkTexto";
            this.chkTexto.Size = new System.Drawing.Size(53, 17);
            this.chkTexto.TabIndex = 1;
            this.chkTexto.Text = "Texto";
            this.chkTexto.UseVisualStyleBackColor = true;
            // 
            // txtTextoAEnviar
            // 
            this.txtTextoAEnviar.Location = new System.Drawing.Point(7, 37);
            this.txtTextoAEnviar.Multiline = true;
            this.txtTextoAEnviar.Name = "txtTextoAEnviar";
            this.txtTextoAEnviar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTextoAEnviar.Size = new System.Drawing.Size(462, 115);
            this.txtTextoAEnviar.TabIndex = 2;
            // 
            // txtIPServidor
            // 
            this.txtIPServidor.Location = new System.Drawing.Point(76, 104);
            this.txtIPServidor.Name = "txtIPServidor";
            this.txtIPServidor.Size = new System.Drawing.Size(118, 20);
            this.txtIPServidor.TabIndex = 3;
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(76, 130);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(118, 20);
            this.txtPuerto.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dirección IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Puerto";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(118, 157);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 7;
            this.btnConectar.Text = "Conectar!";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(279, 158);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "Enviar!";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnActualizarBinario
            // 
            this.btnActualizarBinario.Location = new System.Drawing.Point(360, 158);
            this.btnActualizarBinario.Name = "btnActualizarBinario";
            this.btnActualizarBinario.Size = new System.Drawing.Size(109, 23);
            this.btnActualizarBinario.TabIndex = 4;
            this.btnActualizarBinario.Text = "Actualizar Binario";
            this.btnActualizarBinario.UseVisualStyleBackColor = true;
            this.btnActualizarBinario.Click += new System.EventHandler(this.btnActualizarBinario_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnProbar);
            this.groupBox3.Controls.Add(this.lblEstado);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 208);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Prueba de conexión";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Puede conectarce?";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(124, 30);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(70, 13);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Desconocido";
            // 
            // txtBinarioEnviar
            // 
            this.txtBinarioEnviar.Enabled = false;
            this.txtBinarioEnviar.Location = new System.Drawing.Point(10, 196);
            this.txtBinarioEnviar.Multiline = true;
            this.txtBinarioEnviar.Name = "txtBinarioEnviar";
            this.txtBinarioEnviar.Size = new System.Drawing.Size(459, 94);
            this.txtBinarioEnviar.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Datos enviados";
            // 
            // btnProbar
            // 
            this.btnProbar.Location = new System.Drawing.Point(45, 60);
            this.btnProbar.Name = "btnProbar";
            this.btnProbar.Size = new System.Drawing.Size(104, 23);
            this.btnProbar.TabIndex = 2;
            this.btnProbar.Text = "Probar Conexión";
            this.btnProbar.UseVisualStyleBackColor = true;
            this.btnProbar.Click += new System.EventHandler(this.btnProbar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtLog);
            this.groupBox4.Controls.Add(this.txtRecibidoBinario);
            this.groupBox4.Controls.Add(this.txtRespuesta);
            this.groupBox4.Location = new System.Drawing.Point(13, 315);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(674, 278);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Resultados:";
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Location = new System.Drawing.Point(6, 19);
            this.txtRespuesta.Multiline = true;
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRespuesta.Size = new System.Drawing.Size(662, 80);
            this.txtRespuesta.TabIndex = 0;
            // 
            // txtRecibidoBinario
            // 
            this.txtRecibidoBinario.Enabled = false;
            this.txtRecibidoBinario.Location = new System.Drawing.Point(5, 105);
            this.txtRecibidoBinario.Multiline = true;
            this.txtRecibidoBinario.Name = "txtRecibidoBinario";
            this.txtRecibidoBinario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRecibidoBinario.Size = new System.Drawing.Size(662, 79);
            this.txtRecibidoBinario.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.Enabled = false;
            this.txtLog.Location = new System.Drawing.Point(6, 189);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(662, 82);
            this.txtLog.TabIndex = 2;
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 605);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCliente";
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.frmCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnResolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkTexto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTextoAEnviar;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.TextBox txtIPServidor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBinarioEnviar;
        private System.Windows.Forms.Button btnActualizarBinario;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnProbar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtRecibidoBinario;
        private System.Windows.Forms.TextBox txtRespuesta;
    }
}

