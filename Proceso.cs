using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planificador_FcFs_Caballos
{
    internal class Proceso
    {
        private int id;
        private int tiempo_llegada;
        private int tiempo_ejecucion;

        public Proceso(int id, int tiempo_llegada, int tiempo_ejecucion)
        {
            this.id = id;
            this.tiempo_llegada = tiempo_llegada;
            this.tiempo_ejecucion = tiempo_ejecucion;
        }

        public int Id { get => id; set => id = value; }
        public int Tiempo_llegada { get => tiempo_llegada; set => tiempo_llegada = value; }
        public int Tiempo_ejecucion { get => tiempo_ejecucion; set => tiempo_ejecucion = value; }
    }
}
