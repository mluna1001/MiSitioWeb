namespace MiSitioWeb.Controllers
{
    using Data.Models.Tables;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            User user = (User)Session["User"];

            if (user == null)
            {
                Response.Redirect("/Home");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}