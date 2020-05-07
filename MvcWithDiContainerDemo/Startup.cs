using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using MvcWithDiContainerDemo.Providers;

[assembly: OwinStartup(typeof(MvcWithDiContainerDemo.Startup))]

namespace MvcWithDiContainerDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //InitInject.iocInit();

            ////-----------------------------------------//
            //var config = new HttpConfiguration();
            //WebApiConfig.Register(config);
            //app.UseWebApi(config);
        }
    }
}
