using Gambali.InternalTalent.Application.Service;
using Gambali.InternalTalent.Application.Service.Interface;
using Gambali.InternalTalent.Domain.Interfaces;
using Gambali.InternalTalent.Infra.DatabaseContext;
using Gambali.InternalTalent.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Gambali.InternalTalent.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();

            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();

            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IMatriculaService, MatriculaService>();

            return services;
        }
    }
}
