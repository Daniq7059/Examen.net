using System.Windows.Forms;
using System;


namespace MatriculaApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private FlowLayoutPanel panelBotones;
        private Button btnEstudiantes;
        private Button btnCursos;
        private Button btnMatriculas;
        private Button btnPagos;
        private Button btnUsuarios;
        private Button btnMediosPago;
        private Button btnApoderados;
        private Button btnCarreras;
        private Button btnInstitutos;
        private Button btnPeriodos;
        private Button btnHistorial;
        private Button btnDetalleMatricula;

        private Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelBotones = new FlowLayoutPanel();
            this.btnEstudiantes = new Button();
            this.btnCursos = new Button();
            this.btnMatriculas = new Button();
            this.btnPagos = new Button();
            this.btnUsuarios = new Button();
            this.btnMediosPago = new Button();
            this.btnApoderados = new Button();
            this.btnCarreras = new Button();
            this.btnInstitutos = new Button();
            this.btnPeriodos = new Button();
            this.btnHistorial = new Button();
            this.btnDetalleMatricula = new Button();

            this.btnSalir = new Button();

            this.SuspendLayout();

            // FlowLayoutPanel
            this.panelBotones.Dock = DockStyle.Fill;
            this.panelBotones.FlowDirection = FlowDirection.TopDown;
            this.panelBotones.AutoScroll = true;
            this.panelBotones.WrapContents = false;
            this.panelBotones.Padding = new Padding(40);
            this.Controls.Add(this.panelBotones);

            // Lista de botones
            Button[] botones = {
                btnEstudiantes, btnCursos, btnMatriculas,btnDetalleMatricula, btnPagos,
                btnUsuarios, btnMediosPago, btnApoderados, btnCarreras,
                btnInstitutos, btnPeriodos, btnHistorial, btnSalir
            };

            string[] textos = {
                "Gestión de Estudiantes", "Gestión de Cursos", "Gestión de Matrículas","btnDetalleMatricula", "Gestión de Pagos",
                "Gestión de Usuarios", "Medios de Pago", "Gestión de Apoderados", "Gestión de Carreras",
                "Gestión de Institutos", "Gestión de Periodos", "Historial Académico", "Salir del sistema"
            };

            EventHandler[] eventos = {
                btnEstudiantes_Click, btnCursos_Click, btnMatriculas_Click,btnDetalleMatricula_Click, btnPagos_Click,
                btnUsuarios_Click, btnMediosPago_Click, btnApoderados_Click, btnCarreras_Click,
                btnInstitutos_Click, btnPeriodos_Click, btnHistorial_Click, btnSalir_Click
            };

            for (int i = 0; i < botones.Length; i++)
            {
                botones[i].Size = new System.Drawing.Size(300, 50);
                botones[i].Text = textos[i];
                botones[i].Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
                botones[i].BackColor = System.Drawing.Color.LightSteelBlue;
                botones[i].Click += eventos[i];
                this.panelBotones.Controls.Add(botones[i]);
            }

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "Menú Principal";
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }
    }
}
