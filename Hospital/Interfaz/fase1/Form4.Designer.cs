namespace fase1
{
    partial class Form4
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
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.imagen = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnEditarFecha = new System.Windows.Forms.Button();
            this.btnEditarHora = new System.Windows.Forms.Button();
            this.rrr = new System.Windows.Forms.PictureBox();
            this.pbDetallePaciente = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaCita = new System.Windows.Forms.Label();
            this.lblNombrePaciente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rrr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetallePaciente)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(574, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Historial de citas";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // imagen
            // 
            this.imagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imagen.BackColor = System.Drawing.Color.Transparent;
            this.imagen.Location = new System.Drawing.Point(16, 50);
            this.imagen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.imagen.Name = "imagen";
            this.imagen.Size = new System.Drawing.Size(162, 110);
            this.imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagen.TabIndex = 13;
            this.imagen.TabStop = false;
            this.imagen.Click += new System.EventHandler(this.imagen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(530, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "Hospital Don Bosco";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 185);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(752, 301);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(666, 553);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 41);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar cita";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(549, 553);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 41);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar cambios";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(13, 163);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "label15";
            // 
            // btnEditarFecha
            // 
            this.btnEditarFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditarFecha.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEditarFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarFecha.Location = new System.Drawing.Point(549, 499);
            this.btnEditarFecha.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEditarFecha.Name = "btnEditarFecha";
            this.btnEditarFecha.Size = new System.Drawing.Size(97, 26);
            this.btnEditarFecha.TabIndex = 24;
            this.btnEditarFecha.Text = "Editar fecha";
            this.btnEditarFecha.UseVisualStyleBackColor = false;
            this.btnEditarFecha.Click += new System.EventHandler(this.btnEditarFecha_Click);
            // 
            // btnEditarHora
            // 
            this.btnEditarHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarHora.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEditarHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarHora.Location = new System.Drawing.Point(666, 501);
            this.btnEditarHora.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEditarHora.Name = "btnEditarHora";
            this.btnEditarHora.Size = new System.Drawing.Size(97, 22);
            this.btnEditarHora.TabIndex = 25;
            this.btnEditarHora.Text = "Editar hora";
            this.btnEditarHora.UseVisualStyleBackColor = false;
            this.btnEditarHora.Click += new System.EventHandler(this.button2_Click);
            // 
            // rrr
            // 
            this.rrr.BackColor = System.Drawing.Color.Transparent;
            this.rrr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rrr.Image = global::fase1.Properties.Resources.hospital;
            this.rrr.Location = new System.Drawing.Point(464, 6);
            this.rrr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rrr.Name = "rrr";
            this.rrr.Size = new System.Drawing.Size(58, 45);
            this.rrr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rrr.TabIndex = 26;
            this.rrr.TabStop = false;
            // 
            // pbDetallePaciente
            // 
            this.pbDetallePaciente.BackColor = System.Drawing.Color.Transparent;
            this.pbDetallePaciente.Location = new System.Drawing.Point(857, 185);
            this.pbDetallePaciente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbDetallePaciente.Name = "pbDetallePaciente";
            this.pbDetallePaciente.Size = new System.Drawing.Size(246, 162);
            this.pbDetallePaciente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDetallePaciente.TabIndex = 27;
            this.pbDetallePaciente.TabStop = false;
            this.pbDetallePaciente.Click += new System.EventHandler(this.pbDetallePaciente_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblFechaCita);
            this.groupBox1.Controls.Add(this.lblNombrePaciente);
            this.groupBox1.Location = new System.Drawing.Point(843, 358);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(272, 128);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Fecha de cita:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nombre del paciente:";
            // 
            // lblFechaCita
            // 
            this.lblFechaCita.AutoSize = true;
            this.lblFechaCita.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCita.Location = new System.Drawing.Point(33, 77);
            this.lblFechaCita.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaCita.Name = "lblFechaCita";
            this.lblFechaCita.Size = new System.Drawing.Size(74, 29);
            this.lblFechaCita.TabIndex = 6;
            this.lblFechaCita.Text = "Nombre:";
            // 
            // lblNombrePaciente
            // 
            this.lblNombrePaciente.AutoSize = true;
            this.lblNombrePaciente.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePaciente.Location = new System.Drawing.Point(33, 35);
            this.lblNombrePaciente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombrePaciente.Name = "lblNombrePaciente";
            this.lblNombrePaciente.Size = new System.Drawing.Size(74, 29);
            this.lblNombrePaciente.TabIndex = 3;
            this.lblNombrePaciente.Text = "Nombre:";
            this.lblNombrePaciente.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::fase1.Properties.Resources.new_fondo;
            this.ClientSize = new System.Drawing.Size(1133, 701);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbDetallePaciente);
            this.Controls.Add(this.rrr);
            this.Controls.Add(this.btnEditarHora);
            this.Controls.Add(this.btnEditarFecha);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imagen);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rrr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetallePaciente)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox imagen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnEditarFecha;
        private System.Windows.Forms.Button btnEditarHora;
        private System.Windows.Forms.PictureBox rrr;
        private System.Windows.Forms.PictureBox pbDetallePaciente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNombrePaciente;
        private System.Windows.Forms.Label lblFechaCita;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}