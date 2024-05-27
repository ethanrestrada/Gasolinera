using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace Gasolinera
{
    public partial class InformeDatos : Form
    {
        public InformeDatos()
        {
            InitializeComponent();
        }

        private void InformeDatos_Load(object sender, EventArgs e)
        {
            // Se le pone una imagen al fondo del form
            this.BackgroundImage = Properties.Resources.fondo_informe;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Para que las columnas ocupen todo el ancho posible
            dgv_Compras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Bombas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Bombas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Si la lista de compras no esta vacia
            if (Index.listaCompras.Count > 0)
            {
                dgv_Compras.DataSource = Index.listaCompras;
                // Se cambia el texto de los header
                dgv_Compras.Columns["ID"].HeaderText = "#";
                dgv_Compras.Columns["TipoGasolina"].HeaderText = "Tipo de gasolina";
                dgv_Compras.Columns["PrecioGasolina"].HeaderText = "Precio de gasolina";
                dgv_Compras.Columns["TipoCompra"].HeaderText = "Tipo de Compra";
                dgv_Compras.Columns["TotalCompra"].HeaderText = "Total de compra";
            }

            // Si la lista de bombas no esta vacia
            if (Index.listaBombas.Count > 0)
            {
                dgv_Bombas.DataSource = Index.listaBombas;
                // Se cambia el texto de los header
                dgv_Bombas.Columns["ID"].HeaderText = "#";
                dgv_Bombas.Columns["TipoGasolina"].HeaderText = "Tipo de Gasolina";
                dgv_Bombas.Columns["PrecioGasolina"].HeaderText = "Precio de gasolina";
                dgv_Bombas.Columns["ContadorPrepago"].HeaderText = "Abastecimiento Prepago";
                dgv_Bombas.Columns["ContadorBombaLlena"].HeaderText = "Abastecimiento Tanque lleno";
            }
        }
    }
}
