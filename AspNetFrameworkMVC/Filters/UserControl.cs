using System.Web.Mvc; // Filter kullanım kütüphanesi

namespace AspNetFrameworkMVC.Filters
{
    public class UserControl : ActionFilterAttribute // UserControl sınıfına tıpkı httppost gibi action metotlarının üzerinde attribute olarak kullanabilmemizi sağlar
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext) // OnActionExecuting metodu uygulamadaki action ların çalışması sırasında devreye girer
        {
            var UserGuidSession = filterContext.HttpContext.Session["deger"]; // uygulama içerisinde userguid isminde bir session yoksa
            if (UserGuidSession == null)
                filterContext.Result = new RedirectResult("/MVC11Session?msg=AccessDenied"); // Action a gelen isteği yakala ve kullanıcıyı /MVC11Session?msg=AccessDenied sayfasına yönlendir
            if (filterContext.HttpContext.Request.Cookies["username"] == null)
                filterContext.Result = new RedirectResult("/MVC10Cookie/CookieOlustur?msg=AccessDenied");

            base.OnActionExecuting(filterContext);
        }
    }
}