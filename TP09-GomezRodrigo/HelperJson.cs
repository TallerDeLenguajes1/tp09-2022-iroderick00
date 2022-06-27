using System;

public class HelperJson
{
	public HelperJson()
	{
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
