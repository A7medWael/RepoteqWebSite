namespace RepoteqWebSite.App_Code.Models.ViewComponentModels
{
    public class ProjectsView
    {
        public List<ProjectsContent> ProjContains { get; set; } = new List<ProjectsContent>();
    }
    public class ProjectsContent
    {
        public string ImgProjUrl { get; set; }
        public string LogoProjUrl { get; set; }
        public string ProjectName { get; set; }
        public string DescriptionProj { get; set; }
    }
}
