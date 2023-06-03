using Sharpcut;
using Sharpcut.Resources.CategoryResources;

var shortcutApi = new ShortcutApi("6479175c-7736-4b96-99bd-820c471cd0fb");

var newCategory = await shortcutApi.Categories.CreateAsync(new CreateCategory
{
    Name = "Teste"
});

Console.WriteLine();