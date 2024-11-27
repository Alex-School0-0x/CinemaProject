
namespace CinemaProject
{
    public interface IGetRepository<T> where T : IModel
    {
        public T GetAll();
        public T GetById(int id);
        public bool EntityExists(int id);
    }
}
