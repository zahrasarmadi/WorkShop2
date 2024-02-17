using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkShop2.Entities;
using WorkShop2.Ripository;

namespace WorkShop2.Pages
{
    public class AllProductsModel : PageModel
    {
        static CRUD crud=new CRUD();
        [BindProperty]
        public List<Product> ProductModel { get; set; }=crud.GetAllProducts();
        public void OnGet()
        {
        }

        public void OnPost()
        {
           
        }
        
        public IActionResult OnGetDelete(int id)
        {
            crud.DeleteProduct(id);
            TempData["delete"] = "1";
            return Page();
        }

    }
}
