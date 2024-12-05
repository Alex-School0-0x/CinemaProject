namespace CinemaProject.Interfaces
{
    public interface IFullRepository<T> : IGetRepository<T> where T : IModel
    {
        Task<bool> PostAsync(T entity);
        Task<bool> PutAsync(T entity);
        Task<bool> DeleteAsync(T entity);

    }
}
