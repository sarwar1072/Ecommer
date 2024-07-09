using Autofac.Core;
using Autofac;
using Framework.Services;

namespace Ecommerce.Web.Models
{
    public class ResponesModelTwo
    {
        private ILifetimeScope _scope;  
        public string Message { set; get; }
        public string Title { set; get; }
        public string IconCssClass { set; get; }
        public string StyleCssClass { set; get; }
        public string ToasterClass { get; set; }
        public ResponesModelTwo() { }
        public ResponesModelTwo(string message, ResponseType type)
        {
            if (type == ResponseType.Success)
            {
                IconCssClass = "fa-check";
                StyleCssClass = "alert-success";
                Title = "success";
                ToasterClass = "success";
            }
            else if (type == ResponseType.Failure)
            {
                IconCssClass = "fa-ban";
                StyleCssClass = "alert-danger";
                Title = "Error !";
                ToasterClass = "Error";
            }
            Message = message;
        }

        public void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _scope = lifetimeScope;
        }
    }
}
