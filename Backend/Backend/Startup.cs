﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DataAccess;
using Backend.DataAccess.Abstruct;
using Backend.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Backend
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
            // for sql server
            /*     // For MSSQLSERVER
                 services.AddDbContext<DataContext>(x =>
                     x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));   */

            services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(opt =>
             opt.UseNpgsql(Configuration.GetConnectionString("DataDBConection")));

            services.AddMvc();
            // DI Scopes
            // In case a controller request for IMusicDal Return EFMusicDal
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IMusicDal, EFMusicDal>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
