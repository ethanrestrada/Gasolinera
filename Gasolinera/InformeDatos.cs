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
using Newtonsoft.Json;

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
            //Se le pone una imagen al fondo del form
            this.BackgroundImage = Properties.Resources.fondo_informe;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Para que las columnas ocupen todo el ancho posible
            dgv_Compras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Bombas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Bombas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_lleno.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_prepago.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
            //CargarComprasDesdeCSV();
            var comprasTanqueLleno = Index.listaCompras
                .Where(compra => compra.TipoCompra.Equals("Tanque lleno", StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Filtrar las compras para Prepago
            var comprasPrepago = Index.listaCompras
                .Where(compra => compra.TipoCompra.Equals("Prepago", StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Si hay compras de Tanque lleno, asignarlas a dgv_lleno
            if (comprasTanqueLleno.Count > 0)
            {
                dgv_lleno.DataSource = comprasTanqueLleno;
                
                dgv_lleno.Columns["ID"].HeaderText = "#";
                dgv_lleno.Columns["TipoGasolina"].HeaderText = "Tipo de gasolina";
                dgv_lleno.Columns["PrecioGasolina"].HeaderText = "Precio de gasolina";
                dgv_lleno.Columns["TipoCompra"].HeaderText = "Tipo de Compra";
                dgv_lleno.Columns["TotalCompra"].HeaderText = "Total de compra";
            }

            // Si hay compras de Prepago, asignarlas a dgv_prepago
            if (comprasPrepago.Count > 0)
            {
                dgv_prepago.DataSource = comprasPrepago;
                
                dgv_prepago.Columns["ID"].HeaderText = "#";
                dgv_prepago.Columns["TipoGasolina"].HeaderText = "Tipo de gasolina";
                dgv_prepago.Columns["PrecioGasolina"].HeaderText = "Precio de gasolina";
                dgv_prepago.Columns["TipoCompra"].HeaderText = "Tipo de Compra";
                dgv_prepago.Columns["TotalCompra"].HeaderText = "Total de compra";
                CalcularYMostrarUsoDeGasolina();
            }
        }
        private void CalcularYMostrarUsoDeGasolina()
        {
            if (Index.listaBombas.Count > 0)
            {
                var usoGasolina = Index.listaBombas
                    .Select(b => new
                    {
                        b.TipoGasolina,
                        TotalUso = b.ContadorPrepago + b.ContadorBombaLlena
                    })
                    .ToList();

                var maxUso = usoGasolina.OrderByDescending(g => g.TotalUso).First();
                var minUso = usoGasolina.OrderBy(g => g.TotalUso).First();

                lblmas.Text = $"Gasolina más usada: {maxUso.TipoGasolina} con {maxUso.TotalUso} abastecimientos";
                lblmenos.Text = $"Gasolina menos usada: {minUso.TipoGasolina} con {minUso.TotalUso} abastecimientos";
            }
            else
            {
                lblmas.Text = "Gasolina más usada: No hay datos disponibles";
                lblmenos.Text = "Gasolina menos usada: No hay datos disponibles";
            }
        }


    }
}
