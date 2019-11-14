namespace FastFood.Web.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Models;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public ItemsController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var categories = this.context.Categories
                .ProjectTo<CreateItemViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.View(categories);
        }

        [HttpPost]
        public IActionResult Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var category = this.context.Categories
                .FirstOrDefault(c => c.Name == model.CategoryName);

            var item = this.mapper.Map<Item>(model);

            item.CategoryId = category.Id;

            this.context.Items.Add(item);

            this.context.SaveChanges();

            return this.RedirectToAction("All", "Items");
        }

        public IActionResult All()
        {
            var items = this.context.Items
                .ProjectTo<ItemsAllViewModels>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.View(items);
        }
    }
}
