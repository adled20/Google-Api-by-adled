using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Google_Api_by_adled.Model
{
    public class Ubicacion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Ciudad { get; set; }
        public string Temperatura { get; set; }
        public string Sensacion { get; set; }
        public string Clima { get; set; }
        public string Humedad { get; set; }
    }
}
