using Microsoft.AspNetCore.Mvc;
using RepoteqWebSite.App_Code.Models.ViewComponentModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace RepoteqWebSite.App_Code.ViewComponents
{
    [ViewComponent]
    public class ContainerMainsViewComponent:ViewComponent
    {
        private readonly ILogger<ContainerMainsViewComponent> _logger;
        private readonly IUmbracoContextAccessor _contextAccessor;
        public ContainerMainsViewComponent(ILogger<ContainerMainsViewComponent> logger, IUmbracoContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
        }
        public IViewComponentResult Invoke()
        {

           ContainerMainsView containerMains = new ContainerMainsView();
            try
            {


                var content = _contextAccessor.GetRequiredUmbracoContext()?.PublishedRequest?.PublishedContent;
                if (content == null) return View();


                containerMains.ContainerTitle = content?.Value<string>("containerTitle");
                containerMains.ContainerDescription = content?.Value<string>("containerDescription");
               





            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"error while proccessing {nameof(ContainerMainsViewComponent)}");
            }
            return View(containerMains);
        }
    }
}
