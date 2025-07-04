using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos.Respuestas;
using CONTROL_TICKET_TAREA.Helpers;
using CONTROL_TICKET_TAREA.Helpers.Reportes.Excel;
using CONTROL_TICKET_TAREA.Helpers.Reportes.Pdf;
using CONTROL_TICKET_TAREA.Repository.Impl;
using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IControlTicketTareaRepository, ControlTicketTareaRepository>();
builder.Services.AddScoped<IGrupoEconomicoRepository,  GrupoEconomicoRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IGeneralRepository, GeneralRepository>();
builder.Services.AddScoped<ICenterTicketRepository, CenterTicketRepository>();
builder.Services.AddScoped<IItemCenterRepository, ItemCenterRepository>();
builder.Services.AddScoped<IProyectoRepository, ProyectoRepository>();
builder.Services.AddScoped<ISubProyectoRepository,  SubProyectoRepository>();
builder.Services.AddScoped<IExcelService<TbControlTicketTareaResponse>, ExcelTarea>();
builder.Services.AddScoped<IPdfService<TbControlTicketTareaResponse>, PdfTareaService>();

builder.Services.AddScoped<ICacheHelper, CacheHelper>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5500") // o "*", pero solo en desarrollo
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/TicketTarea/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("PermitirFrontend");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TicketTarea}/{action=Index}/{id?}");

app.Run();
