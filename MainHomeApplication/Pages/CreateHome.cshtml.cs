using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MainHomeApplication;
using Microsoft.AspNetCore.Authorization;
using MainHomeApplication.Models;

namespace MainHomeApplication.Pages
{
    //[Authorize]
    public class CreateHomeModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Home NewHome { get; set; } = new();

        [BindProperty]
        public IFormFile? file { get; set; }
        public CreateHomeModel(ApplicationContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
        }
        async public Task<IActionResult> OnPost([FromServices] IGetHomeIndex idService,[FromServices] IGetHomeImagePath imagePath) {
            await this.context.Homes.AddAsync(NewHome);
            FileStream stream = new FileStream("wwwroot/"+imagePath.GetImagePath(NewHome), FileMode.Create);
            await file.CopyToAsync(stream);
            await this.context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
