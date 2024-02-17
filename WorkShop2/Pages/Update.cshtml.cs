using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkShop2.Entities;
using WorkShop2.Ripository;

namespace WorkShop2.Pages
{
    public class UpdateModel : PageModel
    {
        static CRUD curd = new CRUD();
        public Product Product { get; set; }=new Product();
        public List<Category> Category { get; set; } = curd.GetAllCategory();
        public void OnGet(int id)
        {
           Product=curd.GetProduct(id);
        }

        public IActionResult OnPost(Product product)
        {
            curd.UpdateProduct(product);
            return RedirectToPage("Delete");
        }

    }
}
