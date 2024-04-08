using AlmacenAPI.Contracts;
using AlmacenAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;

namespace AlmacenAPI.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        const string JSON_PATH = @"C:\Users\jzafr\source\repos\WEBAPILEMONCODE\AlmacenAPI\Resources\Articulos.json";

        public Articulo GetArticuloById(int id)
        {
            try
            {
                var articulos = GetArticulosFromFile();
                List<Articulo> listArticulos = JsonConvert.DeserializeObject<List<Articulo>>(articulos);
                var articuloById = listArticulos.FirstOrDefault(a => a.Id == id);
                return articuloById;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Articulo> AddArticulo(Articulo articulo)
        {
            try
            {
                var articulos = GetArticulosFromFile();
                List<Articulo> listaArticulos = JsonConvert.DeserializeObject<List<Articulo>>(articulos);
                listaArticulos.Add(articulo);
                var listaArticulosJson = JsonConvert.SerializeObject(listaArticulos);
                SaveArticulosToFile(listaArticulosJson);
                return listaArticulos;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Articulo> ArticuloIn(int id, int cantidad)
        {


            var articulos = GetArticulosFromFile();
            List<Articulo> listArticulos = JsonConvert.DeserializeObject<List<Articulo>>(articulos);
            var articuloById = listArticulos.FirstOrDefault(a => a.Id == id);
            if (articuloById == null)
                throw new KeyNotFoundException("No se ha encontrado el articulo");
            articuloById.Cantidad += cantidad;
            var listaArticulosJson = JsonConvert.SerializeObject(listArticulos);
            SaveArticulosToFile(listaArticulosJson);
            return listArticulos;



        }

        public List<Articulo> ArticuloOut(int id, int cantidad)
        {

            var articulos = GetArticulosFromFile();
            List<Articulo> listArticulos = JsonConvert.DeserializeObject<List<Articulo>>(articulos);
            var articuloById = listArticulos.FirstOrDefault(a => a.Id == id);
            if (articuloById == null)
                throw new KeyNotFoundException("No se ha encontrado el articulo");
            articuloById.Cantidad -= cantidad;
            if (articuloById.Cantidad < 0)
                throw new ArgumentException("La cantidad a restar sobrepasa el numero de articulos que hay en stock");
            var listaArticulosJson = JsonConvert.SerializeObject(listArticulos);
            SaveArticulosToFile(listaArticulosJson);
            return listArticulos;


        }
        private string GetArticulosFromFile()
        {
            return File.ReadAllText(JSON_PATH);
        }
        private void SaveArticulosToFile(string articuloJson)
        {
            File.WriteAllText(JSON_PATH, articuloJson);
        }
    }
}
