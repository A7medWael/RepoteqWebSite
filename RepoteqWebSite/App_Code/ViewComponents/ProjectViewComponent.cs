using Microsoft.AspNetCore.Mvc;
using RepoteqWebSite.App_Code.Models.ViewComponentModels;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace RepoteqWebSite.App_Code.ViewComponents
{
    [ViewComponent]
    public class ProjectViewComponent:ViewComponent
    {
        private readonly ILogger<ProjectViewComponent> _logger;
        private readonly UmbracoHelper _umbracoHelper;
        private readonly IUmbracoContextAccessor _contextAccessor;
        public ProjectViewComponent(ILogger<ProjectViewComponent> logger, UmbracoHelper umbracoHelper, IUmbracoContextAccessor contextAccessor)
        {
            _logger = logger;
            _umbracoHelper = umbracoHelper;
            _contextAccessor = contextAccessor;
        }
        public IViewComponentResult Invoke()
        {
            ProjectsView projectsView = new ProjectsView();

            try
            {
                var Homepage = _umbracoHelper.ContentAtRoot().FirstOrDefault(x => x.IsDocumentType("home") && x.IsVisible()) as Home;
                if (Homepage == null) return View(projectsView);

                //foreach (var item in Homepage)
                //{
                    
                //}

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"error while proccessing {nameof(ProjectViewComponent)}");
            }
            return View(projectsView);
        }
    }
}
