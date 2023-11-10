using StripsBL.Interfaces;
using StripsBL.Managers;
using StripsDL.Repositories;

namespace StripsREST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=\"DATABANK WEB4 strips\";Integrated Security=True"; ;
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddSingleton<IStripsRepository>(repo => new StripsRepository(connectionString));
            builder.Services.AddSingleton<StripsManager>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}