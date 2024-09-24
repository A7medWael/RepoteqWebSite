using Microsoft.AspNetCore.Mvc;
using RepoteqWebSite.App_Code.Models.ViewComponentModels;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace RepoteqWebSite.App_Code.ViewComponents
{
    [ViewComponent]
    public class ContainerViewComponent:ViewComponent
    {

        private readonly ILogger<ContainerViewComponent> _logger;
        private readonly UmbracoHelper _umbracoHelper;
        public ContainerViewComponent(ILogger<ContainerViewComponent> logger, UmbracoHelper umbracoHelper)
        {
            _logger = logger;
           _umbracoHelper = umbracoHelper;
        }

        public IViewComponentResult Invoke()
        {
           ContainerView containerView = new ContainerView();

            try
            {
                var Homepage = _umbracoHelper.ContentAtRoot().FirstOrDefault(x => x.IsDocumentType("home") && x.IsVisible()) as Home;
                if (Homepage == null) return View(containerView);

                foreach(var item in Homepage.ContainerLinks)
                {
                    containerView.containerLinks.Add(
                        new containerLink
                        {
                            Name=item.Name,
                            Url=item.Url
                        }
                        );
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"error while proccessing {nameof(ContainerViewComponent)}");
            }
            return View(containerView);
        }
    }
}
