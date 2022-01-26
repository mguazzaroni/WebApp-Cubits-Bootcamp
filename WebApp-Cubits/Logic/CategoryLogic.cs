using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Contract;
using WebApp_Cubits.Data.Models;
using WebApp_Cubits.Models.Dto;

namespace WebApp_Cubits.Logic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
        
        public List<CategoryDto> GetList()
        {
            var categoryList = _categoryRepository.GetList();

            return categoryList.Select(l => new CategoryDto
            {
                Id = l.Id,
                Name = l.Name
            }).ToList();
        }
        public CategoryDto GetById(Guid id)
        {
            var category = _categoryRepository.GetById(id);

            return new CategoryDto
            {
                Name = category.Name
            };
        }

        public Guid Add(CategoryDto category)
        {
            var categ = new Category
            {
                Name = category.Name,
                Id = category.Id
            };

            var id = _categoryRepository.Add(categ);

            return id;
        }
        public void Update(Guid id, CategoryDto category)
        {
            var categ = _categoryRepository.GetById(id);

            categ.Name = categ.Name;

            _categoryRepository.Update(categ);
        }
        public void Remove(Guid id)
        {
            var categ = _categoryRepository.GetById(id);

            _categoryRepository.Remove(categ);
        }

    }
}
