using PetStore.Services.Models.Category;
using System.Collections.Generic;

namespace PetStore.Services
{
    public interface ICategoryService
    {
        DetailsCategoryServiceModel GetById(int id);

        void Create(CreateCategoryServiceModel model);

        void Edit(EditCategoryServiceModel model);

        bool Remove(int id);

        bool Exists(int categoryId);

        IEnumerable<AllCategoriesServiceModel> All();
    }
}
