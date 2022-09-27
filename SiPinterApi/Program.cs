using SiPinterApi.Services.PPh;
using SiPinterApi.Repositories.PPh;
using SiPinterApi.Infrastructure.Dapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddTransient<IMasterDataServices, MasterDataServices>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IDbContext, DbContext>();

#region Repository
builder.Services.AddTransient<IMasterDataRepository, MasterDataRepository>();
builder.Services.AddTransient<IDashboardRepository, DashboardRepository>();
builder.Services.AddTransient<ISPTListRepository, SPTListRepository>();
builder.Services.AddTransient<IDJP_Repository, DJP_Repository>();
builder.Services.AddTransient<IInitSptRepository, InitSptRepository>();
builder.Services.AddTransient<ILaporRepository, LaporRepository>();
#endregion

#region Services
builder.Services.AddTransient<IMasterDataServices, MasterDataServices>();
builder.Services.AddTransient<IDashboardServices, DashboardServices>();
builder.Services.AddTransient<ISPTServices, SPTServices>();
#endregion
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
