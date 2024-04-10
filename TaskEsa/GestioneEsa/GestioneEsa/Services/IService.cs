namespace GestioneEsa.Services
{
    public interface IService<T>
    {
        IEnumerable<T> PrendiliTutti();
        T? PrendiById(int id);

    }
}
