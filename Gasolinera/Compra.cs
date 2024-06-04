using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera
{
    public class Compra 
    {
        private static int variableID = 0;
        public int ID { get; private set; }
        public string Nombre { get; set; }
        public string TipoGasolina { get; set; }
        public double PrecioGasolina { get; set; }
        public string TipoCompra {  get; set; }
        public double TotalCompra { get; set; }
        public string Hora { get; set; }
        public string Fecha { get; set; }

        public Compra()
        {
            variableID = 0;
        }

        public Compra(string nombre, string tipoGasolina, double precioGasolina, string tipoCompra, double total) 
        {
            variableID = ++variableID;
            this.ID = variableID;
            this.Nombre = nombre;
            this.TipoGasolina = tipoGasolina;
            this.PrecioGasolina = precioGasolina;
            this.TipoCompra = tipoCompra;
            this.TotalCompra = total;
            
        }
        public void setID(int nuevoID)
        {
            this.ID = nuevoID;
        }
    }
}
