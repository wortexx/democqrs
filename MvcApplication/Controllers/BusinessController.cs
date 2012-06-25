using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web.Mvc;
using Commands;
using Domain.Commands;
using Infrastructure.Providers.CommandService;
using Primitives.Views;
using Providers.CommandService;

namespace MvcApplication.Controllers
{
    public class BusinessController : Controller
    {
        private static ChannelFactory<ICommandWebServiceClient> _channelFactory;

        static BusinessController()
        {
            _channelFactory = new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient");
        }
        public ActionResult Index()
        {
            var model = new List<BusinessDocument>();
            
            return View(model);
        }

        public ActionResult Add()
        {
            var command = new CreateBusiness
                              {
                                  BusinessId = Guid.NewGuid()
                              };

            return View(command);
        }

        [HttpPost]
        public ActionResult Add(CreateBusiness command)
        {
            ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
                              client.Execute(new ExecuteRequest(command)));

            return RedirectToAction("Index");
        }

        public ActionResult Delete(DeleteBusiness command)
        {
            ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
                              client.Execute(new ExecuteRequest(command)));

            return RedirectToAction("Index");
        }
    }
}