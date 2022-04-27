using System.Collections.Generic;

namespace ClassTrackerFE.Services
{
    public interface IApiRequest<T>
    {
        List<T> GetAll(string controllerName);

        T GetSingle(string controllerName, int id);

        T Create(string controllerName, T entity);

        T Edit(string controllerName, int id, T entity);

        void Delete(string controllerName, int id);
    }
}
