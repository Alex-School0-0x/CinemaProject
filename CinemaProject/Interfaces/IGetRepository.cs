namespace CinemaProject.Interfaces
{
    public interface IGetRepository<T> where T : IModel
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<bool> EntityExistsAsync(int id);

    }
}
