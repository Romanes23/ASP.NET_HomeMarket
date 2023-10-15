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
        IDataProvider _homeDataProvider;

        [BindProperty]
        public Home NewHome { get; set; } = new();

        [BindProperty]
        public IFormFile? file { get; set; }
        public CreateHomeModel(IDataProvider provider)
        {
            this._homeDataProvider = provider;
        }
        public void OnGet()
        {
        }


        async public Task<IActionResult> OnPost([FromServices] IGetHomeImagePath imagePath)
        {
            Home createdHome = this._homeDataProvider.createHome(NewHome);
            FileStream stream = new FileStream("wwwroot/"+imagePath.GetImagePath(NewHome), FileMode.Create);
            await file.CopyToAsync(stream);
            return RedirectToPage("Index");
        }
    }
}
