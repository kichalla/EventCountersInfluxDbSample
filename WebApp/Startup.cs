using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Internal;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            var eventSourceArgs = new Dictionary<string, string>();
            eventSourceArgs.Add("EventCounterIntervalSec", "1");
            var listener = new SampleEventListener();
            listener.EnableEvents(SampleEventSource.Log, EventLevel.LogAlways, EventKeywords.None, eventSourceArgs);
        }
    }
}
