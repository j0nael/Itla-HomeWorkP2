namespace tallermecanico.infretruture.Interfaces
{
    public interface IBaserepositorie<T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> Delete(int id);
        Task<List<T>> GetAll();
        Task<T> Getbyid(int id);
        Task<T> Update(T entity);
    }
}