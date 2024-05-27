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
            this.BackgroundImage = Properties.Resources.fondo_informe;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            dgv_Compras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Bombas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Bombas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (Index.listaCompras.Count > 0)
            {
                dgv_Compras.DataSource = Index.listaCompras;
                dgv_Compras.Columns["ID"].HeaderText = "#";
                dgv_Compras.Columns["TipoGasolina"].HeaderText = "Tipo de gasolina";
                dgv_Compras.Columns["PrecioGasolina"].HeaderText = "Precio de gasolina";
                dgv_Compras.Columns["TipoCompra"].HeaderText = "Tipo de Compra";
                dgv_Compras.Columns["TotalCompra"].HeaderText = "Total de compra";
            }

            if (Index.listaBombas.Count > 0)
            {
                dgv_Bombas.DataSource = Index.listaBombas;
                dgv_Bombas.Columns["ID"].HeaderText = "#";
                dgv_Bombas.Columns["TipoGasolina"].HeaderText = "Tipo de Gasolina";
                dgv_Bombas.Columns["PrecioGasolina"].HeaderText = "Precio de gasolina";
                dgv_Bombas.Columns["ContadorPrepago"].HeaderText = "Abastecimiento Prepago";
                dgv_Bombas.Columns["ContadorBombaLlena"].HeaderText = "Abastecimiento Tanque lleno";
            }
        }
    }
}
