using DTI_Test.Domain.Models;
using DTI_Test.Repository.Interfaces;
using DTI_Test.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTI_Test.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<Product>> GetAll()
        {
            try
            {
                var result = await _repository.GetAll();
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                var result = await _repository.GetById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Insert(Product product)
        {
            try
            {
                var result = await _repository.Insert(product);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(Product product)
        {
            try
            {
                var result = await _repository.Update(product);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            try
            {
                var result = await _repository.Delete(id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
