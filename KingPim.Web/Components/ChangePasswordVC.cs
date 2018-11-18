using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Components
{
    public class ChangePasswordVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}