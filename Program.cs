// Program.cs (agora contém tudo)
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner (o que estava em ConfigureServices)
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BibliotecaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<LivroService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<AutenticacaoService>();
builder.Services.AddScoped<EmprestimoService>();
// ... outros serviços

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configurar o pipeline de requisições HTTP (o que estava em Configure)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseSession(); // Garanta que o UseSession() venha antes do MapControllerRoute
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();