using api_javascript_connection.Interfaces;
using api_javascript_connection.Models;

namespace api_javascript_connection.Controllers
{
    public class Repository : IRepository
    {
        private Dictionary<int, Supplier> suppliers;
        public Repository() { 
            suppliers = new Dictionary<int, Supplier>();
            new List<Supplier>
            {
                new Supplier { SupplierId = 1, CompanyName = "Alpha Co", City = "London", Address = "ON" },
                new Supplier { SupplierId = 2, CompanyName = "Beta Inc", City = "New York", Address = "NY" },
                new Supplier { SupplierId = 3, CompanyName = "Gamma Ltd", City = "Tokyo", Address = "TK" }
            }.ForEach(s => Add(s));
        }
        public Supplier this[int id] => throw new NotImplementedException();

        public IEnumerable<Supplier> Suppliers
        {
            get { return suppliers.Values; }
        }

        public Supplier Add(Supplier supplier)
        {
            if (supplier.SupplierId == 0)
            {
                int key = suppliers.Count;
                while (suppliers.ContainsKey(key)) { key++; }
                supplier.SupplierId = key;
            }
            suppliers[supplier.SupplierId] = supplier;
            return supplier;
        }

        public void Delete(int id)
        => suppliers.Remove(id);
        

        public Supplier Update(Supplier supplier)
        {
            return Add(supplier);
        }
    }
}
