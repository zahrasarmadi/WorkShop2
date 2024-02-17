using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkShop2.Entities;
using WorkShop2.Ripository;
using WorkShop2.ViewModel;

namespace WorkShop2.Pages
{
    public class AddModel : PageModel
    {
       static CRUD crud= new CRUD();

        [BindProperty]
        public AddModelView ModelView { get; set; }
        [BindProperty]
        public List<Category> CategoryModel { get; set; } = crud.GetAllCategory();
        public void OnGet()
        {
        }
        public IActionResult OnPost(AddModelView modelView)
        {
            crud.AddProduct(modelView);
            TempData["Success"] = "1";
            return Page();
        }
    }
}
