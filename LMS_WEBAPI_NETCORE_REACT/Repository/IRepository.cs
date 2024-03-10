using Microsoft.AspNetCore.Mvc;

namespace LMS_WEBAPI_NETCORE_REACT.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<ActionResult<IEnumerable<T>>> GetItems();
        Task<ActionResult<T>> GetItemById(int Id);
        Task<ActionResult<T>> Create(T model);
        Task<ActionResult> Update(int id,T model);

        Task<ActionResult> Delete(int id);
        Task<bool> save();
        bool ItemExists(int id);
        bool ItemExists(string itemName);

    }
}
