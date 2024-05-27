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

        // Crear lista de bombas disponibles
        public static List<Bomba> listaBombas = new List<Bomba>() 
        { 
            new Bomba("V-Power", 11.55),
            new Bomba("Super", 11.40),
            new Bomba("Regular", 11.00),
            new Bomba("Diesel", 10.95)
        };

        // Crear lista de registros de compras
        public static List<Compra> listaCompras = new List<Compra>();

        public Index()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Asignar eventos clic a los botones de bombas
            btn_Bomba1.Click += Boton_Click;
            btn_Bomba2.Click += Boton_Click;
            btn_Bomba3.Click += Boton_Click;
            btn_Bomba4.Click += Boton_Click;

            // Definir color transparente
            pnl_transparente.BackColor = Color.Transparent;

            // Obtener medida de la pantalla del usuario
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            // Obtener medida del panel
            int panelWidth = pnl_transparente.Width;
            int panelHeight = pnl_transparente.Height;

            // Calcula la diferencia de tamaño entre la pantalla y el panel
            // Se divide en dos para colocarlo al centro
            int newPanelX = (formWidth - panelWidth) / 2;
            int newPanelY = (formHeight - panelHeight) / 2;

            //Se asigna las coordenadas del centro
            pnl_transparente.Location = new Point(newPanelX, newPanelY);

            //Asigna una imagen al fondo del form
            this.BackgroundImage = Properties.Resources.fondo_main;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        // Funcion para saber si un formulario ya esta abierto
        private static bool IsFormOpen(string tituloFormulario)
        {
            // Recorre los formularios abiertos
            foreach (Form form in Application.OpenForms)
            {
                // Si el formulario abierto tiene un texto como el que se busca
                if (form.Text == tituloFormulario)
                {
                    return true;
                }
            }
            return false;
        }

        // Funcion para devolver el formulario abierto
        private static Form GetOpenForm(string tituloFormulario)
        {
            // Recorre los formularios abiertos
            foreach (Form form in Application.OpenForms)
            {
                // Devuelve el formulario con un texto que coincida
                // con el buscado
                if (form.Text == tituloFormulario)
                {
                    return form;
                }
            }
            return null;
        }

        // Funcion click para abrir el formulario de bomba
        private void Boton_Click(object sender, EventArgs e)
        {
            // Se guarda el boton presionado
            Button boton = sender as Button;

            // Se busca en la lista el objeto con ID que coincide
            // con el tipo de gasolina
            int indice = listaBombas.FindIndex(p => p.TipoGasolina == boton.Text);

            // Se evalula si hay un formulario abierto
            // con el nombre buscado
            if (IsFormOpen("Bomba de "+ boton.Text))
            {
                // Si ya esta abierto se obtiene ese formulario
                Form openForm = GetOpenForm("Bomba de " + boton.Text);
                // Si el formulario no es nulo
                if (openForm != null)
                {
                    // El formulario obtenido se pasa al
                    // frente de todo
                    openForm.BringToFront();
                    openForm.Activate();
                    openForm.Focus();
                }
            }
            else
            {
                // Si el formulario no estaba abierto, se abre
                InterfazBomba interfazBomba = new InterfazBomba();
                interfazBomba.IndiceBomba(indice);
                interfazBomba.Show();
            }
        }

        // Funcion para buscar si el form de informes
        // esta abierto
        private static bool IsInformeOpen()
        {
            // Recorre los formularios abiertos
            foreach (Form form in Application.OpenForms)
            {
                // Verifica si entre los formularios abiertos
                // hay uno del tipo InformeDatos
                if (form.GetType() == typeof(InformeDatos))
                {
                    return true;
                }
            }
            return false;
        }

        // Devuelve el formulario Informe si esta abierto
        private static Form GetInforme()
        {
            // Recorre los formularios abiertos
            foreach (Form form in Application.OpenForms)
            {
                // Verifica si entre los formularios abiertos
                // hay uno del tipo InformeDatos
                if (form.GetType() == typeof(InformeDatos))
                {
                    return form;
                }
            }
            return null;

        }

        private void btn_Informe_Click(object sender, EventArgs e)
        {
            // Si el formulario esta abierto
            if (IsInformeOpen())
            {
                // Se obtiene el formulario abierto de tipo InformeDatos
                Form form = GetInforme();
                // Si no es nulo
                if (form != null) {
                    // El formulario se sobrepone a todos
                    form.BringToFront();
                    form.Activate();
                    form.Focus();
                }
            }
            else
            {
                // Si el formulario no esta abierto, se abre
                InformeDatos informe = new InformeDatos();
                informe.Show();
            }
        }
    }
}
