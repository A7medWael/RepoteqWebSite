namespace RepoteqWebSite.App_Code.Models.ViewComponentModels
{
    public class ContainerView
    {
        
        public List<containerLink>  containerLinks { get; set; }=new List<containerLink>();
       
        
            
    }
    public class containerLink
    {
        public string Name { get; set; }
        public string Url { get; set; }
        
    }
}
