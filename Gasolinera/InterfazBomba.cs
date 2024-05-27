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
        private List<Button> buttonList;

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
            this.Text = "Bomba de " + Index.listaBombas[idBomba].TipoGasolina;

            buttonList = new List<Button>
            {
                btn_Num0,
                btn_Num1,
                btn_Num2,
                btn_Num3,
                btn_Num4,
                btn_Num5,
                btn_Num6,
                btn_Num7,
                btn_Num8,
                btn_Num9,
            };

            foreach(Button boton in buttonList)
            {
                boton.Click += Boton_Click;
            }

            panel2.BackColor = Color.FromArgb(100, Color.Black);
            //panel1.BackColor = Color.FromArgb(75, Color.Black);
            this.BackgroundImage = Properties.Resources.fondo_bomba;
            this.BackgroundImageLayout = ImageLayout.Stretch;


            lbl_Bomba.Text = "Bomba de " + Index.listaBombas[idBomba].TipoGasolina;

            string precioGasolina = Index.listaBombas[idBomba].PrecioGasolina.ToString();
            precioGasolina = (precioGasolina.Contains(".")) ? precioGasolina : precioGasolina + ".00";

            lbl_Precio.Text = "Q" + precioGasolina;

            //port = new SerialPort("COM3", 9600); 
            //port.Open();
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
            if (cbx_TanqueLleno.Checked || !tbx_CantidadLitros.Text.Equals(""))
            {
                if(!tbx_NombreCliente.Text.Equals(""))
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

                    Index.listaCompras.Add(
                        new Compra(
                            tbx_NombreCliente.Text,
                            Index.listaBombas[idBomba].TipoGasolina,
                            Index.listaBombas[idBomba].PrecioGasolina,
                            tipoCompra
                            ));

                }
                else
                {
                    MessageBox.Show("El nombre no puede estar vacio");
                }
            }
            else
            {
                if (tbx_NombreCliente.Text.Equals(""))
                {
                    MessageBox.Show("Escoja un tipo de llenado: Tanque lleno o prepago");
                }
            }
        }

        int command;

        private void on_Click(object sender, EventArgs e)
        {

            command = 1;

            //var jsonCommand = JsonConvert.SerializeObject(new { led = command });
            //port.WriteLine(jsonCommand);
        }

        private void off_Click(object sender, EventArgs e)
        {
            command = 0;

            //var jsonCommand = JsonConvert.SerializeObject(new { led = command });
            //port.WriteLine(jsonCommand);
        }

        private void cbx_TanqueLleno_Click(object sender, EventArgs e)
        {
            if (cbx_TanqueLleno.Checked)
            {
                tbx_CantidadLitros.Enabled = false;
                btn_Clear.Enabled = false;
                btn_DEL.Enabled = false;

                foreach(Button boton in buttonList)
                {
                    boton.Enabled = false;
                }
            }
            else
            {
                tbx_CantidadLitros.Enabled = true;
                btn_Clear.Enabled = true;
                btn_DEL.Enabled = true;

                foreach (Button boton in buttonList)
                {
                    boton.Enabled = true;
                }
            }
        }
    }
}
