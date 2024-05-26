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

        public Compra(string nombre, string tipoGasolina, double precioGasolina, string tipoCompra) 
        {
            variableID = ++variableID;
            this.ID = variableID;
            this.Nombre = nombre;
            this.TipoGasolina = tipoGasolina;
            this.PrecioGasolina = precioGasolina;
            this.TipoCompra = tipoCompra;
            Hora = DateTime.Now.ToString("h:mm tt");
            Fecha = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
