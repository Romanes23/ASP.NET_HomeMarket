using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MainHomeApplication.Pages
{
    public class RegistryModel : PageModel
    {
        IDataProvider _DataProvider;

        [BindProperty]
        public ServiceUser NewUser { get; set; } = new();

        public void OnGet()
        {
        }

        public RegistryModel(IDataProvider provider)
        {
            this._DataProvider = provider;
        }


        async public Task<IActionResult> OnPost([FromServices] IGetHomeImagePath imagePath)
            {
                ServiceUser createdHome = this._DataProvider.createUser(NewUser);
         //       FileStream stream = new FileStream("wwwroot/" + imagePath.GetImagePath(NewUser), FileMode.Create);
           //     await file.CopyToAsync(stream);
 
                return RedirectToPage("Index");



            }


     

    }
}
