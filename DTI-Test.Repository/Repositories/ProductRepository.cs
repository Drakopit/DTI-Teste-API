using DTI_Test.Domain.Models;
using DTI_Test.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTI_Test.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DTIContext _context;
        
        public ProductRepository(DTIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                var result = await _context.Product.ToListAsync();
                return result;
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
                var result = await _context.Product.FirstOrDefaultAsync(p => p.Id == id);
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
                await _context.AddAsync(product);
                await _context.SaveChangesAsync();
                return true;
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
                var result = await _context.Product.Where(p => p.Id == product.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.Entry(result).State = EntityState.Detached;
                    _context.Entry(product).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _context.Product.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
