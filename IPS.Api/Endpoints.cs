using ITS.Core.Data;
using ITS.Domain.Models;
using ITS.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace ITS.Api
{ 
    public static class Endpoints
    {
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            var departments = app.MapGroup("/department").WithOpenApi();
            var equipment = app.MapGroup("/equipment").WithOpenApi();
            var issues = app.MapGroup("/issue").WithOpenApi();
            var inspectors = app.MapGroup("/inspector").WithOpenApi();
            departments.MapPost("", async (IDepartmentService service, Department entity) =>
            {
                return await service.Add(entity);
            });
            departments.MapGet("", async (IDepartmentService service) =>
            {
                return  await service.GetAll();
            });
            departments.MapGet("/{id}", async (IDepartmentService service, int id) =>
            {
                return await service.Get(id) ;
            });
            departments.MapDelete("/{id}", async (IDepartmentService service, int id) =>
            {
                return await service.Delete(id) ;
            });
            departments.MapPut("", async (IDepartmentService service, Department entity) =>
            {
               return  await service.Update(entity);
            });

            equipment.MapPost("", (DatabaseContext db, Equipment entity) =>
            {
                db.Equipments.Add(entity);
                var saved = db.SaveChanges();
                return saved;
            });
            equipment.MapGet("", (DatabaseContext db) =>
            {
                return db.Equipments.Include(e => e.Department).ToList();
            });
            equipment.MapGet("/{id}", (DatabaseContext db, int id) =>
            {
                return db.Equipments.Include(e => e.Department).FirstOrDefault(d => d.Id == id);
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
                return db.Issues.Include(i => i.Inspector).Include(i => i.Equipment).ToList();
            });
            issues.MapGet("/{id}", (DatabaseContext db, int id) =>
            {
                return db.Issues.FirstOrDefault(d => d.Id == id);
            });
            issues.MapGet("/close/{id}", async (DatabaseContext db, int id) =>
            {
                var issue = await db.Issues.FirstOrDefaultAsync(d => d.Id == id);
                if (issue is not null)
                {
                    issue.Status = ITS.Domain.IssueStatus.Closed;
                    issue.ClosedDate = DateTime.Now;
                    db.Issues.Update(issue);
                    await db.SaveChangesAsync();
                }
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
            return app;
        }
    }
}
