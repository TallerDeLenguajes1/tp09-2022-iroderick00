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
        public static void mostrarArchivos(string path)
        {
            var files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).ToList();
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
        public static void mostrarDirectorios(string path)
        {
            var dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories).ToList();
            mostrarArchivos(path);
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
                mostrarArchivos((string)dir);
            }
        }
        public static void generarJson(string pathJson, string path)
        {
            var lista = new List<Archivo>();
            int contador = 1;
            string archivoGenerado;
            var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories).ToList();
            foreach (var file in files)
            {
                var archivoAuxiliar = new Archivo();
                archivoAuxiliar.id = contador;
                archivoAuxiliar.name = Path.GetFileName(file);
                archivoAuxiliar.path = file;
                lista.Add(archivoAuxiliar);
                contador++;
            }
            using (var fs = new FileStream(pathJson, FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(fs))
                {
                    archivoGenerado = JsonSerializer.Serialize(lista);
                    sw.WriteLine(archivoGenerado);
                }
            }
        }
        public static List<Archivo> cargarArchivo(string pathJson)
        {
            var lista = new List<Archivo>();
            string archivoCargado;
            using (var fs = new FileStream(pathJson, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    archivoCargado = sr.ReadLine();
                }
            }
            lista = JsonSerializer.Deserialize<List<Archivo>>(archivoCargado);
            return lista;
        }
    }
}
