
using Bookworm_cs.Models;
using Bookworm_cs.Repositories;
using BookWorm_cs.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_cs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddHttpClient();

            builder.Services.AddTransient<IBeneficiaryRepository, SqlBeneficiaryRepository>();
            builder.Services.AddTransient<ICustomerRepository, SqlCustomerRepository>();
            builder.Services.AddTransient<IGenreRepository, SqlGenreRepository>();
            builder.Services.AddTransient<IInvoiceDetailsRepository, SqlInvoiceDetailsRepository>();
            builder.Services.AddTransient<IInvoiceRepository, SqlInvoiceRepository>();
            builder.Services.AddTransient<ILanguageRepository, SqlLanguageRepository>();
            builder.Services.AddTransient<ILibraryRepository, SqlLibraryRepository>();
            builder.Services.AddTransient<IProductRepository, SqlProductRepository>();
            builder.Services.AddTransient<IProductTypeRepository, SqlProductTypeRepository>();
            builder.Services.AddTransient<IShelfRepository, SqlShelfRepository>();
            builder.Services.AddTransient<ElasticEmailRepository>();

            builder.Services.AddDbContext<AppDbContext>(
                option => option.UseSqlServer(builder.Configuration.GetConnectionString("BookwormDB"))
            );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(
            (p) => p.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
