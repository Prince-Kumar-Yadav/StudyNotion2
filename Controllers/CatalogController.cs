using Microsoft.AspNetCore.Mvc;

namespace Study_Notion.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Catalog()
        {
            return View();
        }
    }
}
