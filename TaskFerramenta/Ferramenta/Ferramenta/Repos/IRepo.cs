namespace Ferramenta.Repos
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        T? Get(string codice);
        bool Insert(T t);
        bool Update(T t);
        bool Delete(string codice);
    }
}
