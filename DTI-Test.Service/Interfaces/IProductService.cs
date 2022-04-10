using DTI_Test.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DTI_Test.Service.Interfaces
{
    public interface IProductService
    {
        Task<IList<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<bool> Insert(Product product);
        Task<bool> Update(Product product);
        Task<bool> DeleteById(int id);
    }
}
