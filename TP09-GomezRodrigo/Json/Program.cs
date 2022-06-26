namespace Json
{
    internal class Program
    {
        const string ubicacionJson = "archivos.json";

        static void Main(string[] args)
        {
            string path;
            Console.WriteLine("Ingrese una ruta para indexar los archivos: ");
            path = Console.ReadLine();
            Archivo.generarJson(ubicacionJson, path);
        }
    }
}