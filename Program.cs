
using JobOverview.Data;
using JobOverview.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace JobOverview
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);

         // Add services to the container.

         var configuration = builder.Configuration;

         builder.Services.AddDbContext<JobOverviewContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

         // Ajoute le service metier Logicel 
         builder.Services.AddScoped<IServiceLogiciels, ServiceLogiciel>();

         // Ajoute le service metier Module
         builder.Services.AddScoped<IServiceModule, ServiceModule>();

         

         builder.Services.AddControllers();
         // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
         builder.Services.AddEndpointsApiExplorer();
         builder.Services.AddSwaggerGen();

         var app = builder.Build();

         // Configure the HTTP request pipeline.
         if (app.Environment.IsDevelopment())
         {
            app.UseSwagger();
            app.UseSwaggerUI();
         }

         app.UseHttpsRedirection();

         app.UseAuthorization();


         app.MapControllers();

         app.Run();
      }
   }
}
