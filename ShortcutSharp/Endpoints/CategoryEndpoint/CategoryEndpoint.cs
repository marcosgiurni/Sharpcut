using Sharpcut.Endpoints.Interfaces;
using Sharpcut.Helpers;
using Sharpcut.Resources.CategoryResources;

namespace Sharpcut.Endpoints.CategoryEndpoint
{
    public class CategoryEndpoint : EndpointBase, ICategoryEndpoint
    {
        private const string CategoriesPath = "/api/v3/categories";

        public CategoryEndpoint(HttpClient httpClient)
            :base(httpClient)
        {
        }

        public async Task<IList<Category>?> GetAllAsync()
        {
            return await GetAsync<List<Category>>(CategoriesPath);
        }

        public async Task<Category> CreateAsync(CreateCategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ArgumentNullException(nameof(category.Name));
            }

            if (!string.IsNullOrWhiteSpace(category.Color) 
                && !ColorHelper.IsValidHexColor(category.Color))
            {
                throw new ArgumentException("Invalid hex color.");
            }

            var createdCategory = await PostAsync<CreateCategory, Category>(CategoriesPath, category);

            if (createdCategory == null)
            {
                throw new Exception();
            }

            return createdCategory;
        }
    }
}
