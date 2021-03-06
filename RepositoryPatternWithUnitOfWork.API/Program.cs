var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration
                                 .GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options =>
                                           options.UseSqlServer(connectionString));

builder.Services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
