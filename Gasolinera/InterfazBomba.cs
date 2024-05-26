using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Gasolinera
{
    public partial class InterfazBomba : Form
    {
        int idBomba = 0;
        SerialPort port;

        public InterfazBomba()
        {
            InitializeComponent();
        }

        public void IndiceBomba(int ID)
        {
            idBomba = ID;
        }

        private void InterfazBomba_Load(object sender, EventArgs e)
        {
            btn_Num0.Click += Boton_Click;
            btn_Num1.Click += Boton_Click;
            btn_Num2.Click += Boton_Click;
            btn_Num3.Click += Boton_Click;
            btn_Num4.Click += Boton_Click;
            btn_Num5.Click += Boton_Click;
            btn_Num6.Click += Boton_Click;
            btn_Num7.Click += Boton_Click;
            btn_Num8.Click += Boton_Click;
            btn_Num9.Click += Boton_Click;

            lbl_Bomba.Text = "Bomba de " + Index.listaBombas[idBomba].TipoGasolina;

            string precioGasolina = Index.listaBombas[idBomba].PrecioGasolina.ToString();
            precioGasolina = (precioGasolina.Contains(".")) ? precioGasolina : precioGasolina + ".00";

            lbl_Precio.Text = "Q" + precioGasolina;

            port = new SerialPort("COM3", 9600); 
            port.Open();
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if(tbx_CantidadLitros.Text.Length < 17)
            {
                tbx_CantidadLitros.Text += boton.Text;
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tbx_CantidadLitros.Text = "";
        }

        private void btn_DEL_Click(object sender, EventArgs e)
        {     if(!tbx_CantidadLitros.Text.Equals(""))
            {
                string cantidad = tbx_CantidadLitros.Text;
                cantidad = cantidad.Substring(0, cantidad.Length - 1);
                tbx_CantidadLitros.Text = cantidad;
            }
        }

        private void btn_LlenarBomba_Click(object sender, EventArgs e)
        {
            if (cbx_TanqueLleno.Checked ||
                (!tbx_NombreCliente.Text.Equals("") &&
                !tbx_CantidadLitros.Text.Equals("")))
            {
                string tipoCompra = "";
                if (cbx_TanqueLleno.Checked)
                {
                    tipoCompra = "Tanque lleno";
                    Index.listaBombas[idBomba].ContadorBombaLlena += 1;
                }
                else
                {
                    tipoCompra = "Prepago";
                    Index.listaBombas[idBomba].ContadorPrepago += 1;
                }

                Index.listaCompras.Add(new Compra(
                                        tbx_NombreCliente.Text,
                                        Index.listaBombas[idBomba].TipoGasolina,
                                        Index.listaBombas[idBomba].PrecioGasolina,
                                        tipoCompra));
            }
            else
            {
                if (tbx_NombreCliente.Text.Equals(""))
                {
                    MessageBox.Show("El nombre no puede estar vacio");
                }
            }
        }
        int command;

        private void on_Click(object sender, EventArgs e)
        {

            command = 1;

            var jsonCommand = JsonConvert.SerializeObject(new { led = command });
            port.WriteLine(jsonCommand);
        }

        private void off_Click(object sender, EventArgs e)
        {
            command = 0;

            var jsonCommand = JsonConvert.SerializeObject(new { led = command });
            port.WriteLine(jsonCommand);
        }
    }
}
