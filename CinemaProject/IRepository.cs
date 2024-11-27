
namespace CinemaProject
{
    public interface IFullRepository<T> : IGetRepository<T> where T : IModel
    {
        void Post(T entity);
        void Put(T entity);
        void Delete(T entity);

    }
}
