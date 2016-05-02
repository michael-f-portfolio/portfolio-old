using System;
using System.Web.Mvc;

namespace SimpleBlogB.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method)]
    public class SelectedTabAttribute : ActionFilterAttribute
    {
        private readonly string _selectedtab;

        public SelectedTabAttribute(string selectedTab)
        {
            _selectedtab = selectedTab;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.SelectedTab = _selectedtab;
        }
    }
}