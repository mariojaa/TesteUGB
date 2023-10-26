using Microsoft.EntityFrameworkCore;
using TesteUGB.Data;
using TesteUGB.Repositorio;

namespace TesteUGB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<TesteUGBDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
            });
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<ProdutoRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<UsuarioRepository>();
            builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            builder.Services.AddScoped<FornecedorRepository>();
            builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
            builder.Services.AddScoped<ServicoRepository>();
            builder.Services.AddHealthChecks();
            builder.Services.AddMvc();
            builder.Services.AddControllersWithViews();


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