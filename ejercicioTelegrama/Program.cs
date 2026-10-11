// MMR2627 - Práctica 1: Visual Studio y GitHub (Entornos de Desarrollo)
// Paso 23: Usuario 2 - Actualización de tarifas: 3 euros ordinario y 6 euros urgente
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ejercicioTelegrama
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public partial class Form1 : Form
    {
        private TextBox txtTelegrama;
        private RadioButton rbOrdinario;
        private RadioButton rbUrgente;
        private TextBox txtPrecio;
        private Button button1;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtTelegrama = new TextBox();
            this.rbOrdinario = new RadioButton();
            this.rbUrgente = new RadioButton();
            this.txtPrecio = new TextBox();
            this.button1 = new Button();
            this.SuspendLayout();

            // txtTelegrama
            this.txtTelegrama.Location = new Point(12, 12);
            this.txtTelegrama.Size = new Size(260, 20);

            // rbOrdinario
            this.rbOrdinario.Location = new Point(12, 40);
            this.rbOrdinario.Text = "Ordinario";
            this.rbOrdinario.AutoSize = true;
            this.rbOrdinario.Checked = true;

            // rbUrgente
            this.rbUrgente.Location = new Point(110, 40);
            this.rbUrgente.Text = "Urgente";
            this.rbUrgente.AutoSize = true;

            // button1
            this.button1.Location = new Point(12, 70);
            this.button1.Text = "Calcular";
            this.button1.Click += new EventHandler(this.button1_Click);

            // txtPrecio
            this.txtPrecio.Location = new Point(12, 100);
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new Size(260, 20);

            // Form1
            this.ClientSize = new Size(300, 150);
            this.Controls.Add(this.txtTelegrama);
            this.Controls.Add(this.rbOrdinario);
            this.Controls.Add(this.rbUrgente);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPrecio);
            this.Text = "Telegrama - MMR2627";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textoTelegrama;
            char tipoTelegrama = ' ';
            int numPalabras = 0;
            double coste;

            // Leo el telegrama 
            textoTelegrama = txtTelegrama.Text;

            // Selección por RadioButtons
            tipoTelegrama = rbUrgente.Checked ? 'u' : 'o';

            // Obtengo el número de palabras que forman el telegrama
            if (!string.IsNullOrWhiteSpace(textoTelegrama))
            {
                char[] separadores = new char[] { ' ', '\t', '\n', '\r' };
                string[] palabras = textoTelegrama.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
                numPalabras = palabras.Length;
            }

            // Si el telegrama es ordinario
            if (tipoTelegrama == 'o')
            {
                if (numPalabras <= 10)
                    coste = 3;
                else
                    coste = 3 + 0.5 * (numPalabras - 10);
            }
            else if (tipoTelegrama == 'u')
            {
                // Si el telegrama es urgente
                if (numPalabras <= 10)
                    coste = 6;
                else
                    coste = 6 + 0.75 * (numPalabras - 10);
            }
            else
            {
                coste = 0;
            }

            txtPrecio.Text = coste.ToString() + " euros";
        }
    }
}
