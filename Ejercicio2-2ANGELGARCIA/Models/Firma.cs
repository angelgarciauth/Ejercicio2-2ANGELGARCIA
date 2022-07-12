using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejercicio2_2ANGELGARCIA.Models
{
    public class Firma
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String nombre { get; set; }

        public String descripcion { get; set; }

        public Byte[] firm { get; set; }
    }
}
