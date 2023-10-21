using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Calculadora_Basica
{
    partial class FrmCalculadora : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCalculadora));
            lblPrimerOperador = new Label();
            lblSegundoOperador = new Label();
            lblOperacion = new Label();
            txtPrimerOperando = new TextBox();
            txtSegundoOperando = new TextBox();
            cmbOperacion = new ComboBox();
            btnOperar = new Button();
            btnLimpiar = new Button();
            btnCerrar = new Button();
            lblResultado = new Label();
            grpSistema = new GroupBox();
            rdbOctal = new RadioButton();
            rdbBinario = new RadioButton();
            rdbDecimal = new RadioButton();
            lstHistorial = new ListBox();
            grpSistema.SuspendLayout();
            SuspendLayout();
            // 
            // lblPrimerOperador
            // 
            resources.ApplyResources(lblPrimerOperador, "lblPrimerOperador");
            lblPrimerOperador.Name = "lblPrimerOperador";
            // 
            // lblSegundoOperador
            // 
            resources.ApplyResources(lblSegundoOperador, "lblSegundoOperador");
            lblSegundoOperador.Name = "lblSegundoOperador";
            // 
            // lblOperacion
            // 
            resources.ApplyResources(lblOperacion, "lblOperacion");
            lblOperacion.Name = "lblOperacion";
            // 
            // txtPrimerOperando
            // 
            txtPrimerOperando.BackColor = Color.FromArgb(162, 192, 255);
            resources.ApplyResources(txtPrimerOperando, "txtPrimerOperando");
            txtPrimerOperando.Name = "txtPrimerOperando";
            txtPrimerOperando.TextChanged += txtPrimerOperador_TextChanged;
            // 
            // txtSegundoOperando
            // 
            txtSegundoOperando.BackColor = Color.FromArgb(162, 192, 255);
            resources.ApplyResources(txtSegundoOperando, "txtSegundoOperando");
            txtSegundoOperando.Name = "txtSegundoOperando";
            txtSegundoOperando.TextChanged += txtSegundoOperador_TextChanged;
            // 
            // cmbOperacion
            // 
            cmbOperacion.BackColor = Color.FromArgb(162, 192, 255);
            resources.ApplyResources(cmbOperacion, "cmbOperacion");
            cmbOperacion.FormattingEnabled = true;
            cmbOperacion.Name = "cmbOperacion";
            cmbOperacion.SelectedIndexChanged += cmbOperacion_SelectedIndexChanged;
            // 
            // btnOperar
            // 
            btnOperar.BackColor = Color.FromArgb(192, 255, 192);
            resources.ApplyResources(btnOperar, "btnOperar");
            btnOperar.ForeColor = Color.Black;
            btnOperar.Name = "btnOperar";
            btnOperar.UseVisualStyleBackColor = false;
            btnOperar.Click += btnOperar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(192, 255, 255);
            resources.ApplyResources(btnLimpiar, "btnLimpiar");
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(255, 192, 192);
            resources.ApplyResources(btnCerrar, "btnCerrar");
            btnCerrar.Name = "btnCerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblResultado
            // 
            resources.ApplyResources(lblResultado, "lblResultado");
            lblResultado.Name = "lblResultado";
            // 
            // grpSistema
            // 
            grpSistema.BackColor = Color.FromArgb(162, 192, 255);
            grpSistema.Controls.Add(rdbOctal);
            grpSistema.Controls.Add(rdbBinario);
            grpSistema.Controls.Add(rdbDecimal);
            resources.ApplyResources(grpSistema, "grpSistema");
            grpSistema.Name = "grpSistema";
            grpSistema.TabStop = false;
            // 
            // rdbOctal
            // 
            resources.ApplyResources(rdbOctal, "rdbOctal");
            rdbOctal.Name = "rdbOctal";
            rdbOctal.TabStop = true;
            rdbOctal.UseVisualStyleBackColor = true;
            rdbOctal.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // rdbBinario
            // 
            resources.ApplyResources(rdbBinario, "rdbBinario");
            rdbBinario.Name = "rdbBinario";
            rdbBinario.UseVisualStyleBackColor = true;
            rdbBinario.CheckedChanged += rdbBinario_CheckedChanged;
            // 
            // rdbDecimal
            // 
            resources.ApplyResources(rdbDecimal, "rdbDecimal");
            rdbDecimal.Checked = true;
            rdbDecimal.Name = "rdbDecimal";
            rdbDecimal.TabStop = true;
            rdbDecimal.UseVisualStyleBackColor = true;
            rdbDecimal.CheckedChanged += rdbDecimal_CheckedChanged;
            // 
            // lstHistorial
            // 
            lstHistorial.BackColor = Color.FromArgb(162, 192, 255);
            lstHistorial.FormattingEnabled = true;
            resources.ApplyResources(lstHistorial, "lstHistorial");
            lstHistorial.Name = "lstHistorial";
            // 
            // FrmCalculadora
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(162, 192, 215);
            Controls.Add(lstHistorial);
            Controls.Add(grpSistema);
            Controls.Add(lblResultado);
            Controls.Add(btnCerrar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnOperar);
            Controls.Add(cmbOperacion);
            Controls.Add(txtSegundoOperando);
            Controls.Add(txtPrimerOperando);
            Controls.Add(lblOperacion);
            Controls.Add(lblSegundoOperador);
            Controls.Add(lblPrimerOperador);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCalculadora";
            FormClosing += FrmCalculadora_FormClosing;
            Load += FrmCalculadora_Load;
            grpSistema.ResumeLayout(false);
            grpSistema.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPrimerOperador;
        private Label lblSegundoOperador;
        private Label lblOperacion;
        private TextBox txtPrimerOperando;
        private TextBox txtSegundoOperando;
        private ComboBox cmbOperacion;
        private Button btnOperar;
        private Button btnLimpiar;
        private Button btnCerrar;
        private Label lblResultado;
        private GroupBox grpSistema;
        private RadioButton rdbBinario;
        private RadioButton rdbDecimal;
        private ListBox lstHistorial;
        private RadioButton rdbOctal;
    }
}
