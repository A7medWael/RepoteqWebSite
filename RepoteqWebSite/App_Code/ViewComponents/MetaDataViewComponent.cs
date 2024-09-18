using Microsoft.AspNetCore.Mvc;
using RepoteqWebSite.App_Code.Models.ViewComponentModels;
using Umbraco.Cms.Core.Web;

namespace RepoteqWebSite.App_Code.ViewComponents
{
    [ViewComponent]
    public class MetaDataViewComponent:ViewComponent
    {
        private readonly ILogger<MetaDataViewComponent> _logger;
        private readonly IUmbracoContextAccessor _contextAccessor;
        public MetaDataViewComponent(ILogger<MetaDataViewComponent> logger, IUmbracoContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            MetaDataView metaDataView = new MetaDataView();

            try
            {

                var content = _contextAccessor.GetRequiredUmbracoContext().PublishedRequest.PublishedContent;
                if (content == null) return View();
                metaDataView.Author = content?.Value<string>("author");
                metaDataView.Description = content?.Value<string>("description");
                metaDataView.Title = content?.Value<string>("title");

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"error while proccessing {nameof(MetaDataViewComponent)}");
            }
            return View(metaDataView);
        }
    }
}
