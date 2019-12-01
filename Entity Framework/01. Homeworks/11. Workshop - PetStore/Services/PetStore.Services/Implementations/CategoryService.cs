namespace PetStore.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using PetStore.Data.Models;
    using PetStore.Services.Models.Category;

    public class CategoryService : ICategoryService
    {
        private readonly PetStoreDbContext data;

        public CategoryService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public DetailsCategoryServiceModel GetById(int id)
        {
            var category = this.data
                .Categories
                .Find(id);

            var dcsm = new DetailsCategoryServiceModel()
            {
                Id = category?.Id,
                Name = category?.Name,
                Description = category?.Description
            };

            return dcsm;
        }

        public void Create(CreateCategoryServiceModel model)
        {
            var category = new Category()
            {
                Name = model.Name,
                Description = model.Description
            };

            this.data.Categories.Add(category);
            this.data.SaveChanges();
        }

        public void Edit(EditCategoryServiceModel model)
        {
            var category = this.data
                .Categories
                .Find(model.Id);

            category.Name = model.Name;
            category.Description = model.Description;

            this.data.SaveChanges();
        }

        public bool Remove(int id)
        {
            var category = this.data
                .Categories
                .Find(id);

            if (category == null)
            {
                return false;
            }

            this.data.Categories.Remove(category);
            int deletedEntitiesCount = this.data.SaveChanges();

            if (deletedEntitiesCount == 0)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<AllCategoriesServiceModel> All()
        {
            return this.data
                .Categories
                .Select(c => new AllCategoriesServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToArray();
        }

        public bool Exists(int categoryId)
        {
            return this.data
                .Categories
                .Any(c => c.Id == categoryId);
        }
    }
}
