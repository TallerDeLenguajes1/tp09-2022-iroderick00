using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Json
{
    public class Archivo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public Archivo()
        {

        }
        public Archivo(int id, string name, string path)
        {
            this.id = id;
            this.name = name;
            this.path = path;
        }
    }
}
