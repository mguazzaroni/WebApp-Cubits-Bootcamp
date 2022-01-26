using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Contract;
using WebApp_Cubits.Data.Models;
using WebApp_Cubits.Models.Dto;

namespace WebApp_Cubits.Logic
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _productRepository;

        public ProductLogic(IProductRepository productRepository)
        {
            productRepository = _productRepository;
        }

        public List<ProductDto> GetList()
        {
            var productList = _productRepository.GetList();

            return productList
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    ProviderId = p.ProviderId,
                    CategoryId = p.CategoryId
                }).ToList();
        }
        public ProductDto GetById(Guid id)
        {
            var product = _productRepository.GetById(id);

            return new ProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                ProviderId = product.ProviderId,
                CategoryId = product.CategoryId
            };
        }

        public Guid Add(ProductDto prod)
        {
            var product = new Product
            {
                Id = prod.Id,
                Name = prod.Name,
                Description = prod.Description,
                Price = prod.Price,
                Stock = prod.Stock,
                ProviderId = prod.ProviderId,
                CategoryId = prod.CategoryId
            };

            var id = _productRepository.Add(product);

            return id;
        }
        public void Update(Guid id, ProductDto prod)
        {
            var product = _productRepository.GetById(id);

            product.Name = prod.Name;
            product.Description = prod.Description;
            product.Price = prod.Price;
            product.Stock = prod.Stock;
            product.ProviderId = prod.ProviderId;
            product.CategoryId = prod.CategoryId;

            _productRepository.Update(product);

        }
        public void Remove(Guid id)
        {
            var product = _productRepository.GetById(id);

            _productRepository.Remove(product);
        }

        
    }
}
