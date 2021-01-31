using System;
using System.Collections.Generic;
using System.Text;
using DLL.DBContext;
using DLL.Model;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLL
{
    public static class DLLDependency
    {
        public static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            
            // Repository dependency

            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        }
    }
}
