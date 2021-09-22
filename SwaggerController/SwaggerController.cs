using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.OpenApi.Models;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNetCore.Builder;

namespace SwaggerController
{
    public static class SwaggerHelper
    {

        public static void ConfigurarServicoDocumentacao(IServiceCollection services,
            string title, 
            string version,
            string description)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version,
                    new OpenApiInfo
                    {
                        Title = title,
                        Version = version,
                        Description = description,
                        Contact = new OpenApiContact
                        {
                            Name = "Rodolfo Paes de Farias",
                            Url = new Uri("https://github.com/rodolfopaesfarias")
                        }
                    });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }

        public static void AtivarMiddlewares(IApplicationBuilder app, string appDescription)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    appDescription);
            });
        }

    }
}
