using ApiCreadocs.Repository;
using ApiCreadocs.Services;
using Microsoft.AspNetCore.Connections;

namespace ApiCreadocs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Configuration des services pour les couches
            builder.Services.AddSingleton<InterfaceConnexion>(sp =>
                new GenerateurConnexion(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<InterfaceInterlocuteurRepository, InterlocuteurRepository>();
            builder.Services.AddScoped<InterfaceInterlocuteurService, InterlocuteurService>();

            builder.Services.AddScoped<InterfaceAgenceRepository, AgenceRepository>();
            builder.Services.AddScoped<InterfaceAgenceService, AgenceService>();

            builder.Services.AddScoped<InterfaceTitreRepository, TitreRepository>();
            builder.Services.AddScoped<InterfaceTitreService, TitreService>();

            builder.Services.AddScoped<InterfaceSexeRepository, SexeRepository>();
            builder.Services.AddScoped<InterfaceSexeService, SexeService>();

            builder.Services.AddScoped<InterfaceSecuRepository, SecuRepository>();
            builder.Services.AddScoped<InterfaceSecuService, SecuService>();

            builder.Services.AddScoped<InterfacePaysRepository, PaysRepository>();
            builder.Services.AddScoped<InterfaceVilleRepository, VilleRepository>();

            builder.Services.AddScoped<InterfaceClientRepository, ClientRepository>();
            builder.Services.AddScoped<InterfaceClientService, ClientService>();

            builder.Services.AddScoped<InterfaceAssuranceRepository, AssuranceRepository>();
            builder.Services.AddScoped<InterfaceAssuranceService, AssuranceService>();

            builder.Services.AddScoped<InterfaceContratRepository, ContratRepository>();
            builder.Services.AddScoped<InterfaceContratService, ContratService>();

            builder.Services.AddScoped<InterfaceIdentificationRepository, IdentificationRepository>();
            builder.Services.AddScoped<InterfaceIdentificationService, IdentificationService>();

            builder.Services.AddScoped<InterfaceStatistiquesRepository, StatistiquesRepository>();
            builder.Services.AddScoped<InterfaceStatistiquesService, StatistiquesService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Utiliser les services CORS
            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
