using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera
{
    public class Bomba
    {
        private static int variableID = 0;
        public int ID { get; private set; }
        public string TipoGasolina {get; set; }
        public double PrecioGasolina { get; set; }
        public int ContadorPrepago { get; set; }
        public int ContadorBombaLlena { get; set; }

        public Bomba(string tipoGasolina, double precioGasolina) {
            variableID = ++variableID;
            ID = variableID;
            this.TipoGasolina = tipoGasolina;
            this.PrecioGasolina = precioGasolina;
            ContadorPrepago = 0;
            ContadorBombaLlena = 0;
        }
    }
}
