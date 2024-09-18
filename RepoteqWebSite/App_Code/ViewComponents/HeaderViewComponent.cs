using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepoteqWebSite.App_Code.Models.ViewComponentModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace RepoteqWebSite.App_Code.ViewComponents
{
    [ViewComponent]
    public class HeaderViewComponent:ViewComponent
    {
        private readonly ILogger<HeaderViewComponent> _logger;
        private readonly IUmbracoContextAccessor _contextAccessor;
        public HeaderViewComponent(ILogger<HeaderViewComponent> logger, IUmbracoContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
        }
        public IViewComponentResult Invoke()
        {
            
            HeaderView headers = new HeaderView();
            try
            {


                var content = _contextAccessor.GetRequiredUmbracoContext()?.PublishedRequest?.PublishedContent;
                if (content == null) return View();


                headers.Title = content?.Value<string>("title");
                headers.SubTitle = content?.Value<string>("subTitle");
                headers.ImageUrl = content?.Value<IPublishedContent>("pageBanner")?.Url();
                headers.ButtonName= content?.Value<string>("buttonName");
                headers.IconUrl = content?.Value<IPublishedContent>("icon")?.Url();





            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"error while proccessing {nameof(HeaderViewComponent)}");
            }
            return View(headers);
        }
    }
}
