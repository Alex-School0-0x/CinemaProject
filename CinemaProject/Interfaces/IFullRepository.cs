namespace CinemaProject.Interfaces
{
    public interface IFullRepository<T> : IGetRepository<T> where T : class, IModel
    {
        Task<T> PostAsync(T entity);
        Task<T> PutAsync(T entity);
        Task<T> DeleteAsync(int id);

    }
}
