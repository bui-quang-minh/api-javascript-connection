using api_javascript_connection.Models;

namespace api_javascript_connection.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Supplier> Suppliers { get; }
        Supplier this[int id] { get; }
        Supplier Update(Supplier supplier);
        Supplier Add(Supplier supplier);
        void Delete(int id);

    }
}
