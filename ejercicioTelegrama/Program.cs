// MMR2627 - Práctica 1: Visual Studio y GitHub (Entornos de Desarrollo)
// Paso 10: Código inicial con errores de depuración (Práctica 2.3)
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
        private CheckBox cbUrgente;
        private TextBox txtPrecio;
        private Button button1;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtTelegrama = new TextBox();
            this.cbUrgente = new CheckBox();
            this.txtPrecio = new TextBox();
            this.button1 = new Button();
            this.SuspendLayout();

            // txtTelegrama
            this.txtTelegrama.Location = new Point(12, 12);
            this.txtTelegrama.Size = new Size(260, 20);

            // cbUrgente
            this.cbUrgente.Location = new Point(12, 40);
            this.cbUrgente.Text = "Urgente";

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
            this.Controls.Add(this.cbUrgente);
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

            // telegrama urgente?
            if (cbUrgente.Checked)
                tipoTelegrama = 'u';

            // Obtengo el número de palabras que forma el telegrama numPalabras = textoTelegrama.Length;
            // Si el telegrama es ordinario
            if (tipoTelegrama == 'o')
                if (numPalabras <= 10)
                    coste = 25;
                else
                    coste = 0.5 * numPalabras;
            else
            // Si el telegrama es urgente
            if (tipoTelegrama == 'u')
                if (numPalabras <= 10)
                    coste = 5;
                else
                    coste = 5 + 0.75 * (numPalabras - 10);
            else
                coste = 0;

            txtPrecio.Text = coste.ToString() + " euros";
        }
    }
}
