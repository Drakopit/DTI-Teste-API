using DTI_Test.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DTI_Test.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> GetAll();
        Task<bool> Insert(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(int id);
    }
}
