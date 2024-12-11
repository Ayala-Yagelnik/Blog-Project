using Microsoft.EntityFrameworkCore;
using Blog.Core.Repositories;
using Blog.Core.Entities;
using Blog.Core.Services;
using Blog.Data;
using Blog.Data.Repositories;
using Blog.Service;
using static Blog.Data.DataContext;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Comment>, CommentRepository>();
builder.Services.AddScoped<IRepository<Post>, PostRepository>();
builder.Services.AddScoped<IRepository<Tag>, TagRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<DataContext>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
