using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Marca
    {
        public override string ToString()
        {
            return Descripcion.ToString();
        }

        public int Id { get; set; }

        [DisplayName("Marca")]
        public string Descripcion { get; set; }


    }
}
