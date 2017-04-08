namespace StudentSystem.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "StudentSystem.StudentContext";
        }

        protected override void Seed(StudentSystem.StudentContext context)
        {
            context.Courses.AddOrUpdate(c => c.Name,
                new Course()
                {
                    Name = "EF DB",
                    Description = "DB Fundamentals",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1),
                    Price = 100m,
                    Homeworks = new List<Homework>()
                    {
                        new Homework()
                        {
                            Content="EF relation",
                            ContentType=contentType.application,
                            SubmissionDate=DateTime.Today,
                            Student=new Student()
                            {
                                Name="Ivan",
                                RegistrationDate=DateTime.Now,
                                PhoneNumber="112",
                                BirthDay=new DateTime(2005,05,05)
                            }
                        },
                        new Homework()
                        {
                            Content="SQL",
                            ContentType=contentType.pdf,
                            SubmissionDate=DateTime.Today,
                            Student=new Student()
                            {
                                Name="Pesho",
                                RegistrationDate=DateTime.Now,
                                PhoneNumber="155",
                                BirthDay=new DateTime(2005,01,01)
                            }
                        }
                    },
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Name="Mima",
                                RegistrationDate=DateTime.Now,
                                PhoneNumber="166",
                                BirthDay=new DateTime(2005,07,10)
                        },
                        new Student()
                        {
                             Name="Geri",
                                RegistrationDate=DateTime.Now,
                                PhoneNumber="6123",
                                BirthDay=new DateTime(2005,03,05)
                        }
                    },
                    Recources = new List<Resource>()
                    {
                        new Resource()
                        {
                            Name="src",
                            TypeOfResources=RecourceType.Document,
                            URL="url.com",
                            Licenses=new List<License>()
                            {
                                new License()
                                {
                                    Name="A",
                                },
                                new License()
                                {
                                    Name="B",
                                }
                            }

                        },
                        new Resource()
                        {
                            Name="hvdi",
                            TypeOfResources=RecourceType.Video,
                            URL="video.bg",
                            Licenses=new List<License>()
                            {
                                new License()
                                {
                                    Name="C"
                                },
                                new License()
                                {
                                    Name="C + D"
                                }
                            }
                        }
                    }
                });
        }
    }
}
