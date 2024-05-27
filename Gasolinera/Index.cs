using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace Gasolinera
{
    public partial class Index : Form
    {


        public static List<Bomba> listaBombas = new List<Bomba>() 
        { 
            new Bomba("V-Power", 11.55),
            new Bomba("Super", 11.40),
            new Bomba("Regular", 11.00),
            new Bomba("Diesel", 10.95)
        };

        public static List<Compra> listaCompras = new List<Compra>();

        public Index()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_Bomba1.Click += Boton_Click;
            btn_Bomba2.Click += Boton_Click;
            btn_Bomba3.Click += Boton_Click;
            btn_Bomba4.Click += Boton_Click;

            pnl_transparente.BackColor = Color.Transparent;

            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            int panelWidth = pnl_transparente.Width;
            int panelHeight = pnl_transparente.Height;

            int newPanelX = (formWidth - panelWidth) / 2;
            int newPanelY = (formHeight - panelHeight) / 2;

            pnl_transparente.Location = new Point(newPanelX, newPanelY);

            this.BackgroundImage = Properties.Resources.fondo_main;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private static bool IsFormOpen(string tituloFormulario)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Text == tituloFormulario)
                {
                    return true;
                }
            }
            return false;
        }

        private static Form GetOpenForm(string tituloFormulario)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Text == tituloFormulario)
                {
                    return form;
                }
            }
            return null;
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            int indice = listaBombas.FindIndex(p => p.TipoGasolina == boton.Text);

            if (IsFormOpen("Bomba de "+ boton.Text))
            {
                Form openForm = GetOpenForm("Bomba de " + boton.Text);
                if (openForm != null)
                {
                    openForm.BringToFront();
                    openForm.Activate();
                    openForm.Focus();
                }
            }
            else
            {
                InterfazBomba interfazBomba = new InterfazBomba();
                interfazBomba.IndiceBomba(indice);
                interfazBomba.Show();
            }
        }

        private static bool IsInformeOpen()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(InformeDatos))
                {
                    return true;
                }
            }
            return false;
        }

        private static Form GetInforme()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(InformeDatos))
                {
                    return form;
                }
            }
            return null;

        }

        private void btn_Informe_Click(object sender, EventArgs e)
        {

            if (IsInformeOpen())
            {
                Form form = GetInforme();
                if (form != null) {
                    form.BringToFront();
                    form.Activate();
                    form.Focus();
                }
            }
            else
            {
                InformeDatos informe = new InformeDatos();
                informe.Show();
            }
        }
    }
}
