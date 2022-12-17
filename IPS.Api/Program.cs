using ITS.Core.Data;
using ITS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlite("Data Source=IPS.db");
});   
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});
var departments = app.MapGroup("/department").WithOpenApi();
var equipment = app.MapGroup("/equipment").WithOpenApi();
var issues = app.MapGroup("/issue").WithOpenApi();
var inspectors = app.MapGroup("/inspector").WithOpenApi();
departments.MapPost("", (DatabaseContext db, Department entity) =>
{
    db.Departments.Add(entity);
    var saved = db.SaveChanges();
    return saved;
});
departments.MapGet("", (DatabaseContext db) =>
{
    return db.Departments.ToList();
});
departments.MapGet("/{id}", (DatabaseContext db,int id) =>
{
    return db.Departments.FirstOrDefault(d=>d.Id==id);
});
departments.MapDelete("/{id}", (DatabaseContext db,int id) =>
{
    var record = db.Departments.AsNoTracking().FirstOrDefault(d=>d.Id==id);
    if(record==null)
    {
        return "Not Found";
    }
    db.Departments.Remove(record);
    var deleted= db.SaveChanges();
    return $"{deleted} department(s) deleted.";
});
departments.MapPut("/{id}", (DatabaseContext db,int id, Department entity) =>
{
    var record = db.Departments.AsNoTracking().FirstOrDefault(d=>d.Id==id);
    if(record==null)
    {
        return "Not Found";
    }
    db.Departments.Update(entity);
    var deleted= db.SaveChanges();
    return $"{deleted} department(s) updated.";
});

equipment.MapPost("", (DatabaseContext db, Equipment entity) =>
{
    db.Equipments.Add(entity);
    var saved = db.SaveChanges();
    return saved;
});
equipment.MapGet("", (DatabaseContext db) =>
{
    return db.Equipments.ToList();
});
equipment.MapGet("/{id}", (DatabaseContext db, int id) =>
{
    return db.Equipments.FirstOrDefault(d => d.Id == id);
});
equipment.MapDelete("/{id}", (DatabaseContext db, int id) =>
{
    var record = db.Equipments.FirstOrDefault(d => d.Id == id);
    if (record == null)
    {
        return "Not Found";
    }
    db.Equipments.Remove(record);
    var deleted = db.SaveChanges();
    return $"{deleted} equipment(s) deleted.";
});
equipment.MapPut("/{id}", (DatabaseContext db, int id, Equipment entity) =>
{
    var record = db.Equipments.FirstOrDefault(d => d.Id == id);
    if (record == null)
    {
        return "Not Found";
    }
    db.Equipments.Update(entity);
    var deleted = db.SaveChanges();
    return $"{deleted} equipment(s) updated.";
});
issues.MapPost("", (DatabaseContext db, Issue entity) =>
{
    db.Issues.Add(entity);
    var saved = db.SaveChanges();
    return saved;
});
issues.MapGet("", (DatabaseContext db) =>
{
    return db.Issues.ToList();
});
issues.MapGet("/{id}", (DatabaseContext db, int id) =>
{
    return db.Issues.FirstOrDefault(d => d.Id == id);
});
issues.MapDelete("/{id}", (DatabaseContext db, int id) =>
{
    var record = db.Issues.FirstOrDefault(d => d.Id == id);
    if (record == null)
    {
        return "Not Found";
    }
    db.Issues.Remove(record);
    var deleted = db.SaveChanges();
    return $"{deleted} issue(s) deleted.";
});
issues.MapPut("/{id}", (DatabaseContext db, int id, Issue entity) =>
{
    var record = db.Issues.FirstOrDefault(d => d.Id == id);
    if (record == null)
    {
        return "Not Found";
    }
    db.Issues.Update(entity);
    var deleted = db.SaveChanges();
    return $"{deleted} issue(s) updated.";
});



inspectors.MapPost("", (DatabaseContext db, Inspector entity) =>
{
    db.Inspectors.Add(entity);
    var saved = db.SaveChanges();
    return saved;
});
inspectors.MapGet("", (DatabaseContext db) =>
{
    return db.Inspectors.ToList();
});
inspectors.MapGet("/{id}", (DatabaseContext db, int id) =>
{
    return db.Inspectors.FirstOrDefault(d => d.Id == id);
});
inspectors.MapDelete("/{id}", (DatabaseContext db, int id) =>
{
    var record = db.Inspectors.FirstOrDefault(d => d.Id == id);
    if (record == null)
    {
        return "Not Found";
    }
    db.Inspectors.Remove(record);
    var deleted = db.SaveChanges();
    return $"{deleted} inspector(s) deleted.";
});
inspectors.MapPut("/{id}", (DatabaseContext db, int id, Inspector entity) =>
{
    var record = db.Inspectors.FirstOrDefault(d => d.Id == id);
    if (record == null)
    {
        return "Not Found";
    }
    db.Inspectors.Update(entity);
    var deleted = db.SaveChanges();
    return $"{deleted} inspector(s) updated.";
});
app.Run();


