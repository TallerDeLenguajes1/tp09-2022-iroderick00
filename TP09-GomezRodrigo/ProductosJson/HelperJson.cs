using System;
using System.Text.Json;

public class HelperJson
{
	public HelperJson()
	{
	}
    public static void generarJson(string pathJson, List<ProductosJson.Producto> lista)
    {
        string archivoGenerado;
        foreach (var producto in lista)
        {
            var archivoAuxiliar = new ProductosJson.Producto();
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
    public static List<ProductosJson.Producto> cargarArchivo(string pathJson)
    {
        var lista = new List<ProductosJson.Producto>();
        string archivoCargado;
        using (var fs = new FileStream(pathJson, FileMode.Open))
        {
            using (var sr = new StreamReader(fs))
            {
                archivoCargado = sr.ReadLine();
            }
        }
        lista = JsonSerializer.Deserialize<List<ProductosJson.Producto>>(archivoCargado);
        return lista;
    }
}
