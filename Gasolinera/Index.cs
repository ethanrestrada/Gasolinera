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
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            int indice = listaBombas.FindIndex(p => p.TipoGasolina == boton.Text);

            InterfazBomba interfazBomba = new InterfazBomba();
            interfazBomba.IndiceBomba(indice);
            interfazBomba.Show();
        }

        private void btn_Informe_Click(object sender, EventArgs e)
        {
            InformeDatos informe = new InformeDatos();
            informe.Show();
        }
    }
}
