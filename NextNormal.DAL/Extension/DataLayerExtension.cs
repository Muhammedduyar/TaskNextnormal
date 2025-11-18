using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NextNormal.DAL.Context;
using NextNormal.DAL.Repositories.Abstract;
using NextNormal.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NextNormal.DAL.Extension
{
    public static class DataLayerExtension
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config) 
        {
            services.AddScoped<IRepository, Repository>();

            services.AddDbContextPool<ApplicationDbContext>(opt => opt.UseSqlServer(
                config.GetConnectionString("SqlServer"),
                b=>b.MigrationsAssembly("NextNormal.DAL")
                ));
            return services;
        }
    }
}
