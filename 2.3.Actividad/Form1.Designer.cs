using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace _2._3Actividad
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            lblDiscos = new Label();
            numDiscos = new NumericUpDown();
            lblVelocidad = new Label();
            trackVelocidad = new TrackBar();
            btnIniciar = new Button();
            btnReiniciar = new Button();
            btnAnalizar = new Button();
            picTorres = new PictureBox();
            lblEstado = new Label();
            txtResultado = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numDiscos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackVelocidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTorres).BeginInit();
            SuspendLayout();
            // 
            // lblDiscos
            // 
            lblDiscos.AutoSize = true;
            lblDiscos.Location = new Point(17, 24);
            lblDiscos.Name = "lblDiscos";
            lblDiscos.Size = new Size(55, 20);
            lblDiscos.TabIndex = 0;
            lblDiscos.Text = "Discos:";
            // 
            // numDiscos
            // 
            numDiscos.Location = new Point(74, 20);
            numDiscos.Margin = new Padding(3, 4, 3, 4);
            numDiscos.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numDiscos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDiscos.Name = "numDiscos";
            numDiscos.Size = new Size(57, 27);
            numDiscos.TabIndex = 1;
            numDiscos.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numDiscos.ValueChanged += numDiscos_ValueChanged;
            // 
            // lblVelocidad
            // 
            lblVelocidad.AutoSize = true;
            lblVelocidad.Location = new Point(154, 24);
            lblVelocidad.Name = "lblVelocidad";
            lblVelocidad.Size = new Size(78, 20);
            lblVelocidad.TabIndex = 2;
            lblVelocidad.Text = "Velocidad:";
            // 
            // trackVelocidad
            // 
            trackVelocidad.AutoSize = false;
            trackVelocidad.Location = new Point(229, 19);
            trackVelocidad.Margin = new Padding(3, 4, 3, 4);
            trackVelocidad.Maximum = 1000;
            trackVelocidad.Minimum = 50;
            trackVelocidad.Name = "trackVelocidad";
            trackVelocidad.Size = new Size(149, 37);
            trackVelocidad.TabIndex = 3;
            trackVelocidad.TickStyle = TickStyle.None;
            trackVelocidad.Value = 400;
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = Color.LightGreen;
            btnIniciar.Location = new Point(394, 16);
            btnIniciar.Margin = new Padding(3, 4, 3, 4);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(126, 40);
            btnIniciar.TabIndex = 4;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnReiniciar
            // 
            btnReiniciar.Location = new Point(531, 16);
            btnReiniciar.Margin = new Padding(3, 4, 3, 4);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(114, 40);
            btnReiniciar.TabIndex = 5;
            btnReiniciar.Text = "Reiniciar";
            btnReiniciar.Click += btnReiniciar_Click;
            // 
            // btnAnalizar
            // 
            btnAnalizar.BackColor = Color.LightSkyBlue;
            btnAnalizar.Location = new Point(1087, 17);
            btnAnalizar.Name = "btnAnalizar";
            btnAnalizar.Size = new Size(160, 35);
            btnAnalizar.TabIndex = 9;
            btnAnalizar.Text = "Analizar Profundidades";
            btnAnalizar.UseVisualStyleBackColor = false;
            btnAnalizar.Click += btnAnalizar_Click;
            // 
            // picTorres
            // 
            picTorres.BackColor = Color.White;
            picTorres.BorderStyle = BorderStyle.FixedSingle;
            picTorres.Location = new Point(17, 73);
            picTorres.Margin = new Padding(3, 4, 3, 4);
            picTorres.Name = "picTorres";
            picTorres.Size = new Size(628, 413);
            picTorres.TabIndex = 6;
            picTorres.TabStop = false;
            picTorres.Paint += picTorres_Paint;
            // 
            // lblEstado
            // 
            lblEstado.Font = new System.Drawing.Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblEstado.ForeColor = Color.DarkSlateBlue;
            lblEstado.Location = new Point(17, 496);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(629, 31);
            lblEstado.TabIndex = 7;
            lblEstado.Text = "Listo para iniciar la simulación.";
            // 
            // txtResultado
            // 
            txtResultado.Font = new System.Drawing.Font("Consolas", 9F);
            txtResultado.Location = new Point(663, 73);
            txtResultado.Margin = new Padding(3, 4, 3, 4);
            txtResultado.Multiline = true;
            txtResultado.Name = "txtResultado";
            txtResultado.ReadOnly = true;
            txtResultado.ScrollBars = ScrollBars.Vertical;
            txtResultado.Size = new Size(584, 452);
            txtResultado.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 547);
            Controls.Add(lblDiscos);
            Controls.Add(numDiscos);
            Controls.Add(lblVelocidad);
            Controls.Add(trackVelocidad);
            Controls.Add(btnIniciar);
            Controls.Add(btnReiniciar);
            Controls.Add(picTorres);
            Controls.Add(lblEstado);
            Controls.Add(txtResultado);
            Controls.Add(btnAnalizar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Simulación Visual - Torres de Hanoi";
            ((System.ComponentModel.ISupportInitialize)numDiscos).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackVelocidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)picTorres).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label lblDiscos;
        private NumericUpDown numDiscos;
        private Label lblVelocidad;
        private TrackBar trackVelocidad;
        private Button btnIniciar;
        private Button btnReiniciar;
        private Button btnAnalizar;
        private PictureBox picTorres;
        private Label lblEstado;
        private TextBox txtResultado;
    }
}