
using Microsoft.EntityFrameworkCore;
using tallermecanico.infretruture.DBContex;


namespace CRUD_API

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<CrudAPIContex>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazor",
                    policy => policy
                        .WithOrigins("https://localhost:7015") // Aquí debe ir la URL de tu Blazor
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowBlazor");

            app.MapControllers();

            app.Run();
        }
    }
}
