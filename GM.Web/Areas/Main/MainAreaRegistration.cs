using System.Web.Mvc;
public class MainAreaRegistration : AreaRegistration {
    public override string AreaName {
        get {
            return "Main";
        }
    }

    public override void RegisterArea(AreaRegistrationContext context) {
        context.MapRoute(
            "Main_default",
            "Main/{controller}/{action}/{id}",
            new { action = "BlogIndex", controller = "Blog", id = UrlParameter.Optional }
        );
    }
}