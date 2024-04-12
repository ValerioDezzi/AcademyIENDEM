namespace GestionaleMarioKart.Services
{
    public interface IService<T>
    {
        IEnumerable<T> PrendiliTutti();
        T? PrendiByID(int id);
       
        bool Aggiorna(T entity);
 
    }
}
