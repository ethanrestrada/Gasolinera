using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gasolinera
{
    public partial class CambiarPrecios : Form
    {
        public CambiarPrecios()
        {
            InitializeComponent();
        }

        private void CambiarPrecios_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.fondo_bomba;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            txt_diesel.Text = Index.listaBombas[3].PrecioGasolina.ToString();
            txt_regular.Text = Index.listaBombas[2].PrecioGasolina.ToString();
            txt_super.Text = Index.listaBombas[1].PrecioGasolina.ToString();
            txt_vpower.Text = Index.listaBombas[0].PrecioGasolina.ToString();
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
                MessageBox.Show("Precio Actualizado");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar la compra en el archivo JSON: {ex.Message}");

            }
        }
        private void btn_LlenarBomba_Click(object sender, EventArgs e)
        {

            if (txt_vpower.Text.Trim() != "" &&
                 txt_super.Text.Trim() != "" &&
                txt_regular.Text.Trim() != "" &&
                 txt_diesel.Text.Trim() != "")
            {
                Index.listaBombas[0].PrecioGasolina = Double.Parse(txt_vpower.Text);
                Index.listaBombas[1].PrecioGasolina = Double.Parse(txt_super.Text);
                Index.listaBombas[2].PrecioGasolina = Double.Parse(txt_regular.Text);
                Index.listaBombas[3].PrecioGasolina = Double.Parse(txt_diesel.Text);
                GuardarBombaJson();
            }
            else
            {
                MessageBox.Show("No pueden estar vacios los campos");
            }


        }
    }
}
