// using Microsoft.EntityFrameworkCore; 
// using Ser_PracticesProj.Data; 
// using Ser_PracticesProj.Repo; 
// using Ser_PracticesProj.Services; 

// var builder = WebApplication.CreateBuilder(args); 

// // Add services to the container. 

// builder.Services.AddControllers(); 
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle 
// builder.Services.AddEndpointsApiExplorer(); 
// builder.Services.AddSwaggerGen(); 

// var mmm = "_allowAll"; 

// builder.Services.AddCors(options => 
// { 
//     options.AddPolicy(name: mmm, policy => 
//     { 
//         policy.WithOrigins("http://localhost:5500", "*"); 
//     }); 
// }); 


// builder.Services.AddDbContext<DataContext>(options => 
// { 
//     options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")); 
// }); 

// builder.Services.AddTransient<IBookRepository, BookRepository>(); 
// builder.Services.AddTransient<IBookService, BookService>(); 

// var app = builder.Build(); 
// // Configure the HTTP request pipeline. 
// if (app.Environment.IsDevelopment()) 
// { 
//     app.UseSwagger(); 
//     app.UseSwaggerUI(); 
// } 


// app.UseCors(mmm); 

// app.UseHttpsRedirection(); 
// app.UseAuthorization(); 

// app.MapControllers(); 

// app.Run(); 


using Microsoft.EntityFrameworkCore;
using Ser_PracticesProj.Data;
using Ser_PracticesProj.Repo;
using Ser_PracticesProj.Services;


var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});




// Add services to the container.  

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<IAuthorService, AuthorService>();



var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);


app.UseHttpsRedirection();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();