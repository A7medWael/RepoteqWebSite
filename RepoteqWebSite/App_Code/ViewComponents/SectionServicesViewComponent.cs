using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Cms.Web.Common;
using RepoteqWebSite.App_Code.Models.ViewComponentModels;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace RepoteqWebSite.App_Code.ViewComponents
{
    [ViewComponent]
    public class SectionServicesViewComponent:ViewComponent
    {
        private readonly ILogger<SectionServicesViewComponent> _logger;
        private readonly IUmbracoContextAccessor _contextAccessor;
        public SectionServicesViewComponent(ILogger<SectionServicesViewComponent> logger, IUmbracoContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
        }
        public IViewComponentResult Invoke()
        {

           SectionServicesView sectionServicesView = new SectionServicesView();
            try
            {
                var Homepage = _contextAccessor.GetRequiredUmbracoContext()?.PublishedRequest?.PublishedContent;
                if (Homepage == null) return View();
                sectionServicesView.MainTitle1 = Homepage?.Value<string>("mainTitle1");
                sectionServicesView.Description1 = Homepage?.Value<string>("descreption1");
                sectionServicesView.IconUrl1 = Homepage?.Value<IPublishedContent>("iconUrl1").Url();
                sectionServicesView.ContentSection1 = Homepage?.Value<string>("contentSection1");
                sectionServicesView.IconUrl2 = Homepage?.Value<IPublishedContent>("iconUrl2")?.Url();
                sectionServicesView.ContentSection2 = Homepage?.Value<string>("contentSection2");
                sectionServicesView.IconUrl3 = Homepage?.Value<IPublishedContent>("iconUrl3")?.Url();
                sectionServicesView.ContentSection3 = Homepage?.Value<string>("contentSection3");
                sectionServicesView.IconUrl4 = Homepage?.Value<IPublishedContent>("iconUrl4")?.Url();
                sectionServicesView.ContentSection4 = Homepage?.Value<string>("contentSection4");





            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"error while proccessing {nameof(SectionServicesViewComponent)}");
            }
            return View(sectionServicesView);
        }
    }
}
