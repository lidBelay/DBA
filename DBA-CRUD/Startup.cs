﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBA_CRUD.Startup))]
namespace DBA_CRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
