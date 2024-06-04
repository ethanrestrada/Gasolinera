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
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gasolinera
{
    public partial class InterfazBomba : Form
    {
        // Indice de bomba dentro de la lista
        int idBomba = 0;
        
        // Lista de botones del teclado
        private List<Button> buttonList;

        public InterfazBomba()
        {
            InitializeComponent();
           
            Index.port.DataReceived += SerialPortDataReceived;
        }

        // Funcion para obtener el ID traido
        // desde el index
        public void IndiceBomba(int ID)
        {
            idBomba = ID;
        }
        private void GuardarCompraEnJson()
        {
            try
            {
                // Ruta común para guardar el archivo CSV en la carpeta de documentos del usuario
                string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
                string carpetaDocumentos = rutaBase.Substring(0, rutaBase.LastIndexOf("\\bin\\Debug"));

                // Quitamos la barra invertida al principio de la segunda parte de la ruta
                string rutaArchivo = Path.Combine(carpetaDocumentos, @"CarpetaCompras\compras.json");

                string contenidoJson = File.ReadAllText(rutaArchivo);

                string listaJson = JsonConvert.SerializeObject(Index.listaCompras, Formatting.Indented);

                File.WriteAllText(rutaArchivo, listaJson);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar la compra en el archivo JSON: {ex.Message}");
            }
        }
        private void GuardarBombaJson()
        {
            try
            {
                // Ruta común para guardar el archivo CSV en la carpeta de documentos del usuario
                string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
                string carpetaDocumentos = rutaBase.Substring(0, rutaBase.LastIndexOf("\\bin\\Debug"));

                // Quitamos la barra invertida al principio de la segunda parte de la ruta
                string rutaArchivo = Path.Combine(carpetaDocumentos, @"CarpetaCompras\Bombas.json");

                string contenidoJson = File.ReadAllText(rutaArchivo);

                string listaJson = JsonConvert.SerializeObject(Index.listaBombas, Formatting.Indented);

                File.WriteAllText(rutaArchivo, listaJson);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar la compra en el archivo JSON: {ex.Message}");
            }
        }
        private void InterfazBomba_Load(object sender, EventArgs e)
        {
            // Se cambia el texto del form
            
            
            
            this.Text = "Bomba de " + Index.listaBombas[idBomba].TipoGasolina;
            tbx_Despachado.Text = "";
            tb_Total.Text = "";
            tbx_Litros.Text = "";

            // Se llena la lista con los botones del teclado
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

            // A cada boton de la lista se le asigna un evento click
            foreach(Button boton in buttonList)
            {
                boton.Click += Boton_Click;
            }

            // Color con transparencia
            panel2.BackColor = Color.FromArgb(100, Color.Black);
            // Se le pone una imagen al fondo del form
            this.BackgroundImage = Properties.Resources.fondo_bomba;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Se le pone el tipo de gasolina al label
            lbl_Bomba.Text = "Bomba de " + Index.listaBombas[idBomba].TipoGasolina;

            // Se obtiene el precio de la gasolina
            string precioGasolina = Index.listaBombas[idBomba].PrecioGasolina.ToString();
            // Si la gasolina no tiene parte decimal
            // se le agrega .00
            precioGasolina = (precioGasolina.Contains(".")) ? precioGasolina : precioGasolina + ".00";

            // Se le pone el precio de la gasolian al label
            lbl_Precio.Text = "Q" + precioGasolina;
        }

        

        private void Boton_Click(object sender, EventArgs e)
        {
            // Se guarda el boton clicado
            Button boton = sender as Button;

            // Mientras el textox tengo menos de 17 chars
            if(tbx_CantidadLitros.Text.Length < 17)
            {
                // Se le suma al texto actual el
                // numero que tiene el boton
                tbx_CantidadLitros.Text += boton.Text;
            }
        }

        // Se limpia el textbox que acumula los numeros
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tbx_CantidadLitros.Text = "";
        }

        private void btn_DEL_Click(object sender, EventArgs e)
        {     
            // Si el textbox no esta vacio
            if(!tbx_CantidadLitros.Text.Equals(""))
            {
                // Se elimina el ultimo caracter
                string cantidad = tbx_CantidadLitros.Text;
                cantidad = cantidad.Substring(0, cantidad.Length - 1);
                tbx_CantidadLitros.Text = cantidad;
            }
        }

        private void btn_LlenarBomba_Click(object sender, EventArgs e)
        {
            // Si hay seleccionada un tipo de abastecimiento
            if (cbx_TanqueLleno.Checked || !tbx_CantidadLitros.Text.Equals(""))
            {
                // Si se ingresa un nombre
                if(!tbx_NombreCliente.Text.Equals(""))
                {
                    string tipoCompra = "";
                    // Si se selecciona el tanque lleno
                    if (cbx_TanqueLleno.Checked)
                    {
                        // Se guarda el registro del tipo de abastecimiento
                        tipoCompra = "Tanque lleno";
                        
                    }
                    else
                    {
                        // Se guarda el registro del tipo de abastecimiento
                        tipoCompra = "Prepago";
                        tbx_Despachado.Text= "Q"+(float.Parse(tbx_CantidadLitros.Text) * Index.listaBombas[idBomba].PrecioGasolina).ToString();
                        tbx_Litros.Text = tbx_CantidadLitros.Text;
                        tb_Total.Text = "Q"+(float.Parse(tbx_CantidadLitros.Text) * Index.listaBombas[idBomba].PrecioGasolina).ToString();
                        button1.Text = "GUARDAR";

                    }

                    // Objeto compra
                   

                   

                    
                    
                    

                    int command;

                    switch (idBomba)
                    {
                        case 0:
                            command = 7;
                            break;
                        case 1:
                            command = 8;
                            break;
                        case 2:
                            command = 7;
                            break;
                        case 4:
                            command = 8;
                            break;

                        default:
                            command = 7; 
                            break;
                    }

                    int tipo = (tipoCompra == "Tanque lleno") ? 1 : 0;
                    float cantidad = (tipoCompra == "Prepago") ? float.Parse(tbx_CantidadLitros.Text) : 0;

                    var jsonCommand = JsonConvert.SerializeObject(
                        new {
                            bomba = command,
                            tipoLlenado = tipo,
                            monto = cantidad
                        }) ;
                    
                    Index.port.WriteLine(jsonCommand);
                }
                else
                {
                    // Se muestra un mensaje en caso de no
                    // cumplir la condicion
                    MessageBox.Show("El nombre no puede estar vacio");
                }
            }
            else
            {
                // Se muestra un mensaje en caso de no
                // cumplir la condicion
                MessageBox.Show("Escoja un tipo de llenado: Tanque lleno o prepago");
            }
        }

        private void cbx_TanqueLleno_Click(object sender, EventArgs e)
        {
            // Si se selecciono el tanque lleno
            if (cbx_TanqueLleno.Checked)
            {
                // Se apagan los botones del teclado
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
                // Si no, se activan los botones
                tbx_CantidadLitros.Enabled = true;
                btn_Clear.Enabled = true;
                btn_DEL.Enabled = true;

                foreach (Button boton in buttonList)
                {
                    boton.Enabled = true;
                }
            }
        }
       
        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                
                SerialPort sp = (SerialPort)sender;
                string data = sp.ReadLine(); // Leer los datos del puerto serie

                if (!string.IsNullOrEmpty(data))
                {
                    // Verificar si la cadena recibida contiene información
                    JObject jsonData = JObject.Parse(data);
                    MessageBox.Show(data);
                    int segundos = (int)jsonData["segundos"];
                    int milisegundos = (int)jsonData["milisegundos"];
                    
                    Index.litrostxt = segundos.ToString() + "." + milisegundos.ToString();
                         Index.despachadoValue = float.Parse(Index.litrostxt) * float.Parse(Index.listaBombas[idBomba].PrecioGasolina.ToString());
                    Index.despachadoText = "Q" + Index.despachadoValue.ToString("F2"); // Formatear a dos lugares decimales

                    // Calcular y formatear el valor total
                    Index.totalValue = Index.despachadoValue;
                    Index.totalText = "Q" + Index.totalValue.ToString("F2");
                    Index.bandera1 = true;
                    // Formatear a dos lugares decimales

                        // Actualizar los cuadros de texto
                       
                }
                    

                
            }
            catch (JsonReaderException ex)
            {
                // Manejar el caso de que la cadena no sea un JSON válido
               
            }
            catch (Exception ex)
            {
                // Manejar cualquier otra excepción
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "GUARDAR")
            {
                if (cbx_TanqueLleno.Checked || !tbx_CantidadLitros.Text.Equals(""))
                {
                    // Si se ingresa un nombre
                    if (!tbx_NombreCliente.Text.Equals(""))
                    {
                        if (!tbx_Litros.Text.Equals(""))
                        {
                            string tipoCompra = "";
                            // Si se selecciona el tanque lleno
                            if (cbx_TanqueLleno.Checked)
                            {
                                // Se guarda el registro del tipo de abastecimiento
                                tipoCompra = "Tanque lleno";
                                Index.listaBombas[idBomba].ContadorBombaLlena += 1;
                            }
                            else
                            {
                                // Se guarda el registro del tipo de abastecimiento
                                tipoCompra = "Prepago";
                                Index.listaBombas[idBomba].ContadorPrepago += 1;
                            }

                            // Objeto compra
                            var compra = new Compra(
                                tbx_NombreCliente.Text,
                                Index.listaBombas[idBomba].TipoGasolina,
                                Index.listaBombas[idBomba].PrecioGasolina,
                                tipoCompra, double.Parse(tbx_Litros.Text) * Index.listaBombas[idBomba].PrecioGasolina);

                            //Actualizar hora y fecha de compra
                            compra.Hora = DateTime.Now.ToString("h:mm tt");
                            compra.Fecha = DateTime.Now.ToString("yyyy-MM-dd");

                            // Se agrega la venta a la lista de compras
                            Index.listaCompras.Add(compra);

                            GuardarCompraEnJson();
                            GuardarBombaJson();
                            MessageBox.Show("VENTA GUARDADA!");
                            button1.Text = "GENERAR";
                            tbx_Despachado.Text = "";
                            tb_Total.Text = "";
                            tbx_Litros.Text = "";
                            Index.litrostxt ="";
                            Index.totalText ="";
                            Index.despachadoValue =0;
                            Index.totalValue =0;
                            Index.despachadoText ="";
                            Index.bandera1 = false;

                        }
                        else
                        {
                            // Se muestra un mensaje en caso de no
                            // cumplir la condicion
                            MessageBox.Show("No se ha completado la orden");
                        }



                    }
                    else
                    {
                        // Se muestra un mensaje en caso de no
                        // cumplir la condicion
                        MessageBox.Show("El nombre no puede estar vacio");
                    }
                }
                else
                {
                    // Se muestra un mensaje en caso de no
                    // cumplir la condicion
                    MessageBox.Show("Escoja un tipo de llenado: Tanque lleno o prepago");
                }
            }
            else if (button1.Text=="GENERAR")
            {
                if (Index.bandera1)
                {
                    tbx_Litros.Text = Index.litrostxt;
                    tb_Total.Text = Index.totalText;
                    tbx_Despachado.Text = Index.despachadoText;
                    button1.Text = "GUARDAR";

                }
                
            }
        }

        private void InterfazBomba_FormClosed(object sender, FormClosedEventArgs e)
        {


           

        }
    }
}
