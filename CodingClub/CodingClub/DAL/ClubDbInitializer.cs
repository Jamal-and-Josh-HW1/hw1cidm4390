using CodingClub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodingClub.DAL
{
    //public class ClubDbInitializer : DropCreateDatabaseIfModelChanges<ClubContext>
    public class ClubDbInitializer : DropCreateDatabaseAlways<ClubContext>
    {

        protected override void Seed(ClubContext context)
        {
            var clients = new List<Client>
            {
                new Client() {FirstName = "", LastName = "", Organization ="", ContactNumber = "" },
                new Client() {FirstName = "", LastName = "", Organization ="", ContactNumber = "" },
                new Client() {FirstName = "", LastName = "", Organization ="", ContactNumber = "" },
                new Client() {FirstName = "", LastName="", Organization ="", ContactNumber = "" },
                new Client() {FirstName = "", LastName="", Organization ="", ContactNumber = "" },
                new Client() {FirstName = "", LastName="", Organization ="", ContactNumber = "" },
                new Client() {FirstName = "", LastName="", Organization ="", ContactNumber = "" },
                new Client() {FirstName = "", LastName="", Organization ="", ContactNumber = "" },
                new Client() {FirstName = "", LastName="", Organization ="", ContactNumber = "" },
                new Client() {FirstName = "", LastName="", Organization ="", ContactNumber = "" }
            };

            //ForEach is a LINQ function
            clients.ForEach(s => context.Clients.Add(s));

            try
            {
                //_context.SaveChanges();
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            var members = new List<Member>
            {
                new Member() { FirstName = "", LastName = "", Classification="", PhoneNumber = "", Skills = ""},
                new Member() { FirstName = "", LastName = "", Classification="", PhoneNumber = "", Skills = ""},
                new Member() { FirstName = "", LastName = "", Classification="", PhoneNumber = "", Skills = ""},
                new Member() { FirstName = "", LastName = "", Classification="", PhoneNumber = "", Skills = ""},
                new Member() { FirstName = "", LastName = "", Classification="", PhoneNumber = "", Skills = ""},
                new Member() { FirstName = "", LastName = "", Classification="", PhoneNumber = "", Skills = ""},
                new Member() { FirstName = "", LastName = "", Classification="", PhoneNumber = "", Skills = ""},
                new Member() { FirstName = "", LastName = "", Classification="", PhoneNumber = "", Skills = ""}
            };

            members.ForEach(q => context.Members.Add(q));
            try
            {
                //_context.SaveChanges();
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            var projects = new List<Project>
            {
                new Project() {ProjectName = "", ProjectOwner = "", Details = ""},
                new Project() {ProjectName = "", ProjectOwner = "", Details = ""},
                new Project() {ProjectName = "", ProjectOwner = "", Details = ""},
                new Project() {ProjectName = "", ProjectOwner = "", Details = ""},
                new Project() {ProjectName = "", ProjectOwner = "", Details = ""},
                new Project() {ProjectName = "", ProjectOwner = "", Details = ""},
                new Project() {ProjectName = "", ProjectOwner = "", Details = ""},
                new Project() {ProjectName = "", ProjectOwner = "", Details = ""},
                new Project() {ProjectName = "", ProjectOwner = "", Details = ""},
                new Project() {ProjectName = "", ProjectOwner = "", Details = ""}
            };

            //ForEach is a LINQ function
            projects.ForEach(s => context.Projects.Add(s));

            try
            {
                //_context.SaveChanges();
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            var teams = new List<Team>
            {
                new Team() { ProjectName = "", Members = ""},
                new Team() { ProjectName = "", Members = ""},
                new Team() { ProjectName = "", Members = ""},
                new Team() { ProjectName = "", Members = ""},
                new Team() { ProjectName = "", Members = ""},
                new Team() { ProjectName = "", Members = ""},
                new Team() { ProjectName = "", Members = ""},
                new Team() { ProjectName = "", Members = ""}
            };

            teams.ForEach(q => context.Teams.Add(q));
            try
            {
                //_context.SaveChanges();
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }
    }
}
