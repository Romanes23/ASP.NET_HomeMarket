using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MainHomeApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace MainHomeApplication.Pages
{
    public class IndexModel : PageModel
    {
        public List<Home> allHomes;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        async public void OnGet([FromServices] IDataProvider provider)
        {
            allHomes = provider.getAllHomes();
        }
    }
}