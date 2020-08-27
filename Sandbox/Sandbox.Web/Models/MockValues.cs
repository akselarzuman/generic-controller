using System;
using System.Linq;
using GenericController.Repository;
using GenericController.Repository.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Sandbox.Web.Models
{
    public class MockValues
    {
        public static readonly MockValues Instance = new MockValues();

        public void Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<GenericControllerContext>();

                // DB has been seeded
                if (context.Forms.Any() && context.FormInputs.Any() && context.Inputs.Any() && context.InputProperties.Any())
                {
                    return;
                }

                if (!context.Forms.Any())
                {
                    context.Forms.Add(
                        new FormEntity
                        {
                            ID = 1,
                            Name = "Main Page",
                            Script = ""
                        }
                    );
                }
                if (!context.Inputs.Any())
                {
                    AddInputs(context);
                }

                if (!context.InputProperties.Any())
                {
                    AddInputProperties(context);
                }

                if (!context.FormInputs.Any())
                {
                    AddFormInputs(context);
                }

                context.SaveChanges();
            }
        }

        private void AddFormInputs(GenericControllerContext context)
        {
            context.FormInputs.AddRange(
                        new FormInputEntity
                        {
                            ID = 1,
                            FormID = 1,
                            InputID = 1,
                            Order = 100,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 2,
                            FormID = 1,
                            InputID = 2,
                            ParentID = 1,
                            Order = 200,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 3,
                            FormID = 1,
                            InputID = 3,
                            ParentID = 2,
                            Order = 300,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 4,
                            FormID = 1,
                            InputID = 4,
                            ParentID = 2,
                            Order = 400,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 5,
                            FormID = 1,
                            InputID = 5,
                            ParentID = 1,
                            Order = 500,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 6,
                            FormID = 1,
                            InputID = 6,
                            ParentID = 5,
                            Order = 600,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 7,
                            FormID = 1,
                            InputID = 7,
                            ParentID = 6,
                            Order = 700,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 8,
                            FormID = 1,
                            InputID = 8,
                            ParentID = 6,
                            Order = 800,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 9,
                            FormID = 1,
                            InputID = 9,
                            ParentID = 8,
                            Order = 900,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 10,
                            FormID = 1,
                            InputID = 10,
                            ParentID = 9,
                            Order = 1000,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 11,
                            FormID = 1,
                            InputID = 11,
                            ParentID = 5,
                            Order = 1100,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 12,
                            FormID = 1,
                            InputID = 12,
                            ParentID = 11,
                            Order = 1200,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 13,
                            FormID = 1,
                            InputID = 8,
                            ParentID = 11,
                            Order = 1300,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 14,
                            FormID = 1,
                            InputID = 9,
                            ParentID = 13,
                            Order = 1400,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 15,
                            FormID = 1,
                            InputID = 13,
                            ParentID = 14,
                            Order = 1500,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 16,
                            FormID = 1,
                            InputID = 14,
                            ParentID = 1,
                            Order = 1600,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 17,
                            FormID = 1,
                            InputID = 15,
                            ParentID = 16,
                            Order = 1700,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 18,
                            FormID = 1,
                            InputID = 16,
                            ParentID = 16,
                            Order = 1800,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 19,
                            FormID = 1,
                            InputID = 17,
                            ParentID = 1,
                            Order = 1900,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 20,
                            FormID = 1,
                            InputID = 18,
                            ParentID = 19,
                            Order = 2000,
                            IsActive = true
                        },
                        new FormInputEntity
                        {
                            ID = 21,
                            FormID = 1,
                            InputID = 19,
                            ParentID = 19,
                            Order = 2100,
                            IsActive = true
                        }
                    );
        }

        private void AddInputProperties(GenericControllerContext context)
        {
            context.InputProperties.AddRange(
                        //div properties
                        new InputPropertyEntity
                        {
                            ID = 1,
                            InputID = 1,
                            PropertyName = "class",
                            PropertyValue = "carousel slide"
                        },
                        new InputPropertyEntity
                        {
                            ID = 2,
                            InputID = 1,
                            PropertyName = "id",
                            PropertyValue = "myCarousel"
                        },
                        new InputPropertyEntity
                        {
                            ID = 3,
                            InputID = 1,
                            PropertyName = "data-ride",
                            PropertyValue = "carousel"
                        },
                        new InputPropertyEntity
                        {
                            ID = 4,
                            InputID = 1,
                            PropertyName = "data-interval",
                            PropertyValue = "6000"
                        },
                        //ol properties
                        new InputPropertyEntity
                        {
                            ID = 5,
                            InputID = 2,
                            PropertyName = "class",
                            PropertyValue = "carousel-indicators"
                        },
                        //first li
                        new InputPropertyEntity
                        {
                            ID = 6,
                            InputID = 3,
                            PropertyName = "data-target",
                            PropertyValue = "#myCarousel"
                        },
                        new InputPropertyEntity
                        {
                            ID = 7,
                            InputID = 3,
                            PropertyName = "data-slide-to",
                            PropertyValue = "0"
                        },
                        new InputPropertyEntity
                        {
                            ID = 8,
                            InputID = 3,
                            PropertyName = "class",
                            PropertyValue = "active"
                        },
                        //second li
                        new InputPropertyEntity
                        {
                            ID = 9,
                            InputID = 4,
                            PropertyName = "data-target",
                            PropertyValue = "#myCarousel"
                        },
                        new InputPropertyEntity
                        {
                            ID = 10,
                            InputID = 4,
                            PropertyName = "data-slide-to",
                            PropertyValue = "1"
                        },
                        //carousel inner div
                        new InputPropertyEntity
                        {
                            ID = 11,
                            InputID = 5,
                            PropertyName = "class",
                            PropertyValue = "carousel-inner"
                        },
                        new InputPropertyEntity
                        {
                            ID = 12,
                            InputID = 5,
                            PropertyName = "role",
                            PropertyValue = "listbox"
                        },
                        //item active div
                        new InputPropertyEntity
                        {
                            ID = 13,
                            InputID = 6,
                            PropertyName = "class",
                            PropertyValue = "item active"
                        },
                        //banner 1 img
                        new InputPropertyEntity
                        {
                            ID = 14,
                            InputID = 7,
                            PropertyName = "src",
                            PropertyValue = "images/banner1.svg"
                        },
                        new InputPropertyEntity
                        {
                            ID = 15,
                            InputID = 7,
                            PropertyName = "alt",
                            PropertyValue = "ASP.NET"
                        },
                        new InputPropertyEntity
                        {
                            ID = 16,
                            InputID = 7,
                            PropertyName = "class",
                            PropertyValue = "img-responsive"
                        },
                        //div carousel option
                        new InputPropertyEntity
                        {
                            ID = 17,
                            InputID = 8,
                            PropertyName = "class",
                            PropertyValue = "carousel-caption"
                        },
                        new InputPropertyEntity
                        {
                            ID = 18,
                            InputID = 8,
                            PropertyName = "role",
                            PropertyValue = "option"
                        },
                        //ASP.NET link
                        new InputPropertyEntity
                        {
                            ID = 19,
                            InputID = 10,
                            PropertyName = "class",
                            PropertyValue = "btn btn-default"
                        },
                        new InputPropertyEntity
                        {
                            ID = 20,
                            InputID = 10,
                            PropertyName = "href",
                            PropertyValue = "https://go.microsoft.com/fwlink/?LinkID=525028&clcid=0x409"
                        },
                        new InputPropertyEntity
                        {
                            ID = 21,
                            InputID = 10,
                            PropertyName = "text",
                            PropertyValue = "Learn More"
                        },
                        //item div
                        new InputPropertyEntity
                        {
                            ID = 22,
                            InputID = 11,
                            PropertyName = "class",
                            PropertyValue = "item"
                        },
                        //banner 2 img
                        new InputPropertyEntity
                        {
                            ID = 23,
                            InputID = 12,
                            PropertyName = "src",
                            PropertyValue = "images/banner2.svg"
                        },
                        new InputPropertyEntity
                        {
                            ID = 24,
                            InputID = 12,
                            PropertyName = "alt",
                            PropertyValue = "Visual Studio"
                        },
                        new InputPropertyEntity
                        {
                            ID = 25,
                            InputID = 12,
                            PropertyName = "class",
                            PropertyValue = "img-responsive"
                        },
                        //ASP.NET link
                        new InputPropertyEntity
                        {
                            ID = 26,
                            InputID = 13,
                            PropertyName = "class",
                            PropertyValue = "btn btn-default"
                        },
                        new InputPropertyEntity
                        {
                            ID = 27,
                            InputID = 13,
                            PropertyName = "href",
                            PropertyValue = "https://go.microsoft.com/fwlink/?LinkID=525030&clcid=0x409"
                        },
                        new InputPropertyEntity
                        {
                            ID = 28,
                            InputID = 13,
                            PropertyName = "text",
                            PropertyValue = "Learn More"
                        },
                        new InputPropertyEntity
                        {
                            ID = 29,
                            InputID = 14,
                            PropertyName = "class",
                            PropertyValue = "left carousel-control"
                        },
                        new InputPropertyEntity
                        {
                            ID = 30,
                            InputID = 14,
                            PropertyName = "href",
                            PropertyValue = "#myCarousel"
                        },
                        new InputPropertyEntity
                        {
                            ID = 31,
                            InputID = 14,
                            PropertyName = "role",
                            PropertyValue = "button"
                        },
                        new InputPropertyEntity
                        {
                            ID = 32,
                            InputID = 14,
                            PropertyName = "data-slide",
                            PropertyValue = "prev"
                        },
                        new InputPropertyEntity
                        {
                            ID = 33,
                            InputID = 15,
                            PropertyName = "class",
                            PropertyValue = "glyphicon glyphicon-chevron-left"
                        },
                        new InputPropertyEntity
                        {
                            ID = 34,
                            InputID = 15,
                            PropertyName = "aria-hidden",
                            PropertyValue = "true"
                        },
                        new InputPropertyEntity
                        {
                            ID = 35,
                            InputID = 16,
                            PropertyName = "class",
                            PropertyValue = "sr-only"
                        },
                        new InputPropertyEntity
                        {
                            ID = 36,
                            InputID = 16,
                            PropertyName = "text",
                            PropertyValue = "Previous"
                        },
                        new InputPropertyEntity
                        {
                            ID = 37,
                            InputID = 17,
                            PropertyName = "class",
                            PropertyValue = "right carousel-control"
                        },
                        new InputPropertyEntity
                        {
                            ID = 38,
                            InputID = 17,
                            PropertyName = "href",
                            PropertyValue = "#myCarousel"
                        },
                        new InputPropertyEntity
                        {
                            ID = 39,
                            InputID = 17,
                            PropertyName = "role",
                            PropertyValue = "button"
                        },
                        new InputPropertyEntity
                        {
                            ID = 40,
                            InputID = 17,
                            PropertyName = "data-slide",
                            PropertyValue = "next"
                        },
                        new InputPropertyEntity
                        {
                            ID = 41,
                            InputID = 18,
                            PropertyName = "class",
                            PropertyValue = "glyphicon glyphicon-chevron-right"
                        },
                        new InputPropertyEntity
                        {
                            ID = 42,
                            InputID = 18,
                            PropertyName = "aria-hidden",
                            PropertyValue = "true"
                        },
                        new InputPropertyEntity
                        {
                            ID = 43,
                            InputID = 19,
                            PropertyName = "class",
                            PropertyValue = "sr-only"
                        },
                        new InputPropertyEntity
                        {
                            ID = 44,
                            InputID = 19,
                            PropertyName = "text",
                            PropertyValue = "Next"
                        }
                );
        }

        private void AddInputs(GenericControllerContext context)
        {
            context.Inputs.AddRange(
                        new InputEntity
                        {
                            ID = 1,
                            Type = "div",
                            Description = "carousel div"
                        },
                        new InputEntity
                        {
                            ID = 2,
                            Type = "ol",
                            Description = "ol for carousel"
                        },
                        new InputEntity
                        {
                            ID = 3,
                            Type = "li",
                            Description = "li for carousel ol"
                        },
                        new InputEntity
                        {
                            ID = 4,
                            Type = "li",
                            Description = "li for carousel ol"
                        },
                        new InputEntity
                        {
                            ID = 5,
                            Type = "div",
                            Description = "carousel inner div"
                        },
                        new InputEntity
                        {
                            ID = 6,
                            Type = "div",
                            Description = "item active div"
                        },
                        new InputEntity
                        {
                            ID = 7,
                            Type = "img",
                            Description = "banner 1 img"
                        },
                        new InputEntity
                        {
                            ID = 8,
                            Type = "div",
                            Description = "carousel option"
                        },
                        new InputEntity
                        {
                            ID = 9,
                            Type = "p",
                            Description = string.Empty
                        },
                        new InputEntity
                        {
                            ID = 10,
                            Type = "a",
                            Description = "ASP.NET link"
                        },
                        new InputEntity
                        {
                            ID = 11,
                            Type = "div",
                            Description = "item div"
                        },
                        new InputEntity
                        {
                            ID = 12,
                            Type = "img",
                            Description = "banner 2 img"
                        },
                        new InputEntity
                        {
                            ID = 13,
                            Type = "a",
                            Description = "Visual Studio link"
                        },
                        new InputEntity
                        {
                            ID = 14,
                            Type = "a",
                            Description = "Previous"
                        },
                        new InputEntity
                        {
                            ID = 15,
                            Type = "span",
                            Description = "Left span"
                        },
                        new InputEntity
                        {
                            ID = 16,
                            Type = "span",
                            Description = "Previous text"
                        },
                        new InputEntity
                        {
                            ID = 17,
                            Type = "a",
                            Description = "Next"
                        },
                        new InputEntity
                        {
                            ID = 18,
                            Type = "span",
                            Description = "Next span"
                        },
                        new InputEntity
                        {
                            ID = 19,
                            Type = "span",
                            Description = "Next text"
                        }
                    );
        }
    }
}