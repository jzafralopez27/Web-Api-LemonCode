using AlmacenAPI.Models;

namespace AlmacenAPI.Contracts
{
    public interface IArticuloRepository
    {
        public Articulo GetArticuloById(int id);
        public List <Articulo> AddArticulo(Articulo articulo);
        public List<Articulo> ArticuloIn(int id, int cantidad);
        public List<Articulo> ArticuloOut(int id, int cantidad);
    }
}
