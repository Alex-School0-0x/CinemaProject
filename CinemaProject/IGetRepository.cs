
namespace CinemaProject
{
    public interface IGetRepository<T> where T : IModel
    {
        public List<T> GetAll();
        public T? GetById(int id);
        public bool EntityExists(int id);
    }
}
