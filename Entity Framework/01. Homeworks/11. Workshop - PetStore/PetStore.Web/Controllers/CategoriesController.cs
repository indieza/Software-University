using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using PetStore.Services.Models.Category;
using PetStore.Web.ViewModels.Category;

namespace PetStore.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var categoryServiceModel = new CreateCategoryServiceModel()
            {
                Name = model.Name,
                Description = model.Description
            };

            this.categoryService.Create(categoryServiceModel);

            return this.RedirectToAction("All", "Categories");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = this.categoryService.GetById(id);

            if (category.Name == null)
            {
                return BadRequest();
            }

            CategoryDetailsViewModel viewModel = new CategoryDetailsViewModel()
            {
                Id = category.Id.Value,
                Name = category.Name,
                Description = category.Description
            };

            if (viewModel.Description == null)
            {
                viewModel.Description = "No description.";
            }

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = this.categoryService.GetById(id);

            if (category.Name == null)
            {
                return this.BadRequest();
            }

            var viewModel = new CategoryDetailsViewModel()
            {
                Id = category.Id.Value,
                Name = category.Name,
                Description = category.Description
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditInputModel model)
        {
            if (!this.categoryService.Exists(model.Id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var ecsm = new EditCategoryServiceModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            this.categoryService.Edit(ecsm);

            return this.RedirectToAction("Details", "Categories", new { id = ecsm.Id });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = this.categoryService.GetById(id);

            if (category.Name == null)
            {
                return this.BadRequest();
            }

            if (category.Description == null)
            {
                category.Description = "No description.";
            }

            var cdvm = new CategoryDetailsViewModel()
            {
                Id = category.Id.Value,
                Name = category.Name,
                Description = category.Description
            };

            return this.View(cdvm);
        }

        [HttpPost]
        public IActionResult Delete(CategoryDetailsViewModel model)
        {
            bool success = this.categoryService.Remove(model.Id);

            if (!success)
            {
                return this.RedirectToAction("Error", "Home");
            }

            return this.RedirectToAction("All", "Categories");
        }

        public IActionResult All()
        {
            var categories = categoryService.All()
                .Select(csm => new CategoryListingViewModel()
                {
                    Id = csm.Id,
                    Name = csm.Name
                })
                .ToArray();

            return this.View(categories);
        }
    }
}