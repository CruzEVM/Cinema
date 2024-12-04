namespace Cinema
{
    partial class Form1
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
            this.btnProbarConexio = new System.Windows.Forms.Button();
            this.btnGestionarPeliculas = new System.Windows.Forms.Button();
            this.btnOpenRooms = new System.Windows.Forms.Button();
            this.btnOpenReservations = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProbarConexio
            // 
            this.btnProbarConexio.Location = new System.Drawing.Point(325, 240);
            this.btnProbarConexio.Name = "btnProbarConexio";
            this.btnProbarConexio.Size = new System.Drawing.Size(75, 23);
            this.btnProbarConexio.TabIndex = 0;
            this.btnProbarConexio.Text = "Probar conexión";
            this.btnProbarConexio.UseVisualStyleBackColor = true;
            this.btnProbarConexio.Click += new System.EventHandler(this.btnProbarConexion_Click);
            // 
            // btnGestionarPeliculas
            // 
            this.btnGestionarPeliculas.Location = new System.Drawing.Point(299, 201);
            this.btnGestionarPeliculas.Name = "btnGestionarPeliculas";
            this.btnGestionarPeliculas.Size = new System.Drawing.Size(123, 23);
            this.btnGestionarPeliculas.TabIndex = 1;
            this.btnGestionarPeliculas.Text = "Gestionar Peliculas";
            this.btnGestionarPeliculas.UseVisualStyleBackColor = true;
            this.btnGestionarPeliculas.Click += new System.EventHandler(this.btnGestionarPeliculas_Click);
            // 
            // btnOpenRooms
            // 
            this.btnOpenRooms.Location = new System.Drawing.Point(299, 162);
            this.btnOpenRooms.Name = "btnOpenRooms";
            this.btnOpenRooms.Size = new System.Drawing.Size(123, 23);
            this.btnOpenRooms.TabIndex = 2;
            this.btnOpenRooms.Text = "Gestionar Salas";
            this.btnOpenRooms.UseVisualStyleBackColor = true;
            this.btnOpenRooms.Click += new System.EventHandler(this.btnOpenRooms_Click);
            // 
            // btnOpenReservations
            // 
            this.btnOpenReservations.Location = new System.Drawing.Point(299, 120);
            this.btnOpenReservations.Name = "btnOpenReservations";
            this.btnOpenReservations.Size = new System.Drawing.Size(123, 23);
            this.btnOpenReservations.TabIndex = 3;
            this.btnOpenReservations.Text = "Gestionar Reservas";
            this.btnOpenReservations.UseVisualStyleBackColor = true;
            this.btnOpenReservations.Click += new System.EventHandler(this.btnOpenReservations_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOpenReservations);
            this.Controls.Add(this.btnOpenRooms);
            this.Controls.Add(this.btnGestionarPeliculas);
            this.Controls.Add(this.btnProbarConexio);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProbarConexio;
        private System.Windows.Forms.Button btnGestionarPeliculas;
        private System.Windows.Forms.Button btnOpenRooms;
        private System.Windows.Forms.Button btnOpenReservations;
    }
}

