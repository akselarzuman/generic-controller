using System;
using System.Linq;
using GenericController.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GenericController.Models
{
    public class MockValues
    {
        public static readonly MockValues Instance = new MockValues();

        public void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GenericControllerContext(serviceProvider.GetRequiredService<DbContextOptions<GenericControllerContext>>()))
            {
                if (context.Form.Any() && context.FormInput.Any() && context.Input.Any() && context.InputProperty.Any())
                {
                    return;   // DB has been seeded
                }
                else
                {
                    if (!context.Form.Any())
                    {
                        context.Form.AddRange(
                            new Form
                            {
                                ID = 1,
                                Name = "Main Page",
                                Script = ""
                            }
                        );
                    }
                    if (!context.Input.Any())
                    {
                        context.Input.AddRange(
                        new Input
                        {
                            ID = 1,
                            Type = "div",
                            Description = "carousel div"
                        },
                        new Input
                        {
                            ID = 2,
                            Type = "ol",
                            Description = "ol for carousel"
                        },
                        new Input
                        {
                            ID = 3,
                            Type = "li",
                            Description = "li for carousel ol"
                        },
                        new Input
                        {
                            ID = 4,
                            Type = "li",
                            Description = "li for carousel ol"
                        },
                        new Input
                        {
                            ID = 5,
                            Type = "div",
                            Description = "carousel inner div"
                        },
                        new Input
                        {
                            ID = 6,
                            Type = "div",
                            Description = "item active div"
                        },
                        new Input
                        {
                            ID = 7,
                            Type = "img",
                            Description = "banner 1 img"
                        },
                        new Input
                        {
                            ID = 8,
                            Type = "div",
                            Description = "carousel option"
                        },
                        new Input
                        {
                            ID = 9,
                            Type = "p",
                            Description = string.Empty
                        },
                        new Input
                        {
                            ID = 10,
                            Type = "a",
                            Description = "ASP.NET link"
                        },
                        new Input
                        {
                            ID = 11,
                            Type = "div",
                            Description = "item div"
                        },
                        new Input
                        {
                            ID = 12,
                            Type = "img",
                            Description = "banner 2 img"
                        },
                        new Input
                        {
                            ID = 13,
                            Type = "a",
                            Description = "Visual Studio link"
                        },
                        new Input
                        {
                            ID = 14,
                            Type = "a",
                            Description = "Previous"
                        },
                        new Input
                        {
                            ID = 15,
                            Type = "span",
                            Description = "Left span"
                        },
                        new Input
                        {
                            ID = 16,
                            Type = "span",
                            Description = "Previous text"
                        },
                        new Input
                        {
                            ID = 17,
                            Type = "a",
                            Description = "Next"
                        },
                        new Input
                        {
                            ID = 18,
                            Type = "span",
                            Description = "Next span"
                        },
                        new Input
                        {
                            ID = 19,
                            Type = "span",
                            Description = "Next text"
                        }
                        );
                    }

                    if (!context.InputProperty.Any())
                    {
                        context.InputProperty.AddRange(
                        //div properties
                        new InputProperty
                        {
                            ID = 1,
                            InputID = 1,
                            PropertyName = "class",
                            PropertyValue = "carousel slide"
                        },
                        new InputProperty
                        {
                            ID = 2,
                            InputID = 1,
                            PropertyName = "id",
                            PropertyValue = "myCarousel"
                        },
                        new InputProperty
                        {
                            ID = 3,
                            InputID = 1,
                            PropertyName = "data-ride",
                            PropertyValue = "carousel"
                        },
                        new InputProperty
                        {
                            ID = 4,
                            InputID = 1,
                            PropertyName = "data-interval",
                            PropertyValue = "6000"
                        },
                        //ol properties
                        new InputProperty
                        {
                            ID = 5,
                            InputID = 2,
                            PropertyName = "class",
                            PropertyValue = "carousel-indicators"
                        },
                        //first li
                        new InputProperty
                        {
                            ID = 6,
                            InputID = 3,
                            PropertyName = "data-target",
                            PropertyValue = "#myCarousel"
                        },
                        new InputProperty
                        {
                            ID = 7,
                            InputID = 3,
                            PropertyName = "data-slide-to",
                            PropertyValue = "0"
                        },
                        new InputProperty
                        {
                            ID = 8,
                            InputID = 3,
                            PropertyName = "class",
                            PropertyValue = "active"
                        },
                        //second li
                        new InputProperty
                        {
                            ID = 9,
                            InputID = 4,
                            PropertyName = "data-target",
                            PropertyValue = "#myCarousel"
                        },
                        new InputProperty
                        {
                            ID = 10,
                            InputID = 4,
                            PropertyName = "data-slide-to",
                            PropertyValue = "1"
                        },
                        //carousel inner div
                        new InputProperty
                        {
                            ID = 11,
                            InputID = 5,
                            PropertyName = "class",
                            PropertyValue = "carousel-inner"
                        },
                        new InputProperty
                        {
                            ID = 12,
                            InputID = 5,
                            PropertyName = "role",
                            PropertyValue = "listbox"
                        },
                        //item active div
                        new InputProperty
                        {
                            ID = 13,
                            InputID = 6,
                            PropertyName = "class",
                            PropertyValue = "item active"
                        },
                        //banner 1 img
                        new InputProperty
                        {
                            ID = 14,
                            InputID = 7,
                            PropertyName = "src",
                            PropertyValue = "images/banner1.svg"
                        },
                        new InputProperty
                        {
                            ID = 15,
                            InputID = 7,
                            PropertyName = "alt",
                            PropertyValue = "ASP.NET"
                        },
                        new InputProperty
                        {
                            ID = 16,
                            InputID = 7,
                            PropertyName = "class",
                            PropertyValue = "img-responsive"
                        },
                        //div carousel option
                        new InputProperty
                        {
                            ID = 17,
                            InputID = 8,
                            PropertyName = "class",
                            PropertyValue = "carousel-caption"
                        },
                        new InputProperty
                        {
                            ID = 18,
                            InputID = 8,
                            PropertyName = "role",
                            PropertyValue = "option"
                        },
                        //ASP.NET link
                        new InputProperty
                        {
                            ID = 19,
                            InputID = 10,
                            PropertyName = "class",
                            PropertyValue = "btn btn-default"
                        },
                        new InputProperty
                        {
                            ID = 20,
                            InputID = 10,
                            PropertyName = "href",
                            PropertyValue = "https://go.microsoft.com/fwlink/?LinkID=525028&clcid=0x409"
                        },
                        new InputProperty
                        {
                            ID = 21,
                            InputID = 10,
                            PropertyName = "text",
                            PropertyValue = "Learn More"
                        },
                        //item div
                        new InputProperty
                        {
                            ID = 22,
                            InputID = 11,
                            PropertyName = "class",
                            PropertyValue = "item"
                        },
                        //banner 2 img
                        new InputProperty
                        {
                            ID = 23,
                            InputID = 12,
                            PropertyName = "src",
                            PropertyValue = "images/banner2.svg"
                        },
                        new InputProperty
                        {
                            ID = 24,
                            InputID = 12,
                            PropertyName = "alt",
                            PropertyValue = "Visual Studio"
                        },
                        new InputProperty
                        {
                            ID = 25,
                            InputID = 12,
                            PropertyName = "class",
                            PropertyValue = "img-responsive"
                        },
                        //ASP.NET link
                        new InputProperty
                        {
                            ID = 26,
                            InputID = 13,
                            PropertyName = "class",
                            PropertyValue = "btn btn-default"
                        },
                        new InputProperty
                        {
                            ID = 27,
                            InputID = 13,
                            PropertyName = "href",
                            PropertyValue = "https://go.microsoft.com/fwlink/?LinkID=525030&clcid=0x409"
                        },
                        new InputProperty
                        {
                            ID = 28,
                            InputID = 13,
                            PropertyName = "text",
                            PropertyValue = "Learn More"
                        },
                        new InputProperty
                        {
                            ID = 29,
                            InputID = 14,
                            PropertyName = "class",
                            PropertyValue = "left carousel-control"
                        },
                        new InputProperty
                        {
                            ID = 30,
                            InputID = 14,
                            PropertyName = "href",
                            PropertyValue = "#myCarousel"
                        },
                        new InputProperty
                        {
                            ID = 31,
                            InputID = 14,
                            PropertyName = "role",
                            PropertyValue = "button"
                        },
                        new InputProperty
                        {
                            ID = 32,
                            InputID = 14,
                            PropertyName = "data-slide",
                            PropertyValue = "prev"
                        },
                        new InputProperty
                        {
                            ID = 33,
                            InputID = 15,
                            PropertyName = "class",
                            PropertyValue = "glyphicon glyphicon-chevron-left"
                        },
                        new InputProperty
                        {
                            ID = 34,
                            InputID = 15,
                            PropertyName = "aria-hidden",
                            PropertyValue = "true"
                        },
                        new InputProperty
                        {
                            ID = 35,
                            InputID = 16,
                            PropertyName = "class",
                            PropertyValue = "sr-only"
                        },
                        new InputProperty
                        {
                            ID = 36,
                            InputID = 16,
                            PropertyName = "text",
                            PropertyValue = "Previous"
                        },
                        new InputProperty
                        {
                            ID = 37,
                            InputID = 17,
                            PropertyName = "class",
                            PropertyValue = "right carousel-control"
                        },
                        new InputProperty
                        {
                            ID = 38,
                            InputID = 17,
                            PropertyName = "href",
                            PropertyValue = "#myCarousel"
                        },
                        new InputProperty
                        {
                            ID = 39,
                            InputID = 17,
                            PropertyName = "role",
                            PropertyValue = "button"
                        },
                        new InputProperty
                        {
                            ID = 40,
                            InputID = 17,
                            PropertyName = "data-slide",
                            PropertyValue = "next"
                        },
                        new InputProperty
                        {
                            ID = 41,
                            InputID = 18,
                            PropertyName = "class",
                            PropertyValue = "glyphicon glyphicon-chevron-right"
                        },
                        new InputProperty
                        {
                            ID = 42,
                            InputID = 18,
                            PropertyName = "aria-hidden",
                            PropertyValue = "true"
                        },
                        new InputProperty
                        {
                            ID = 43,
                            InputID = 19,
                            PropertyName = "class",
                            PropertyValue = "sr-only"
                        },
                        new InputProperty
                        {
                            ID = 44,
                            InputID = 19,
                            PropertyName = "text",
                            PropertyValue = "Next"
                        }
                    );
                    }

                    if (!context.FormInput.Any())
                    {
                        context.FormInput.AddRange(
                            new FormInput
                            {
                                ID = 1,
                                FormID = 1,
                                InputID = 1,
                                Order = 100,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 2,
                                FormID = 1,
                                InputID = 2,
                                ParentID = 1,
                                Order = 200,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 3,
                                FormID = 1,
                                InputID = 3,
                                ParentID = 2,
                                Order = 300,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 4,
                                FormID = 1,
                                InputID = 4,
                                ParentID = 2,
                                Order = 400,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 5,
                                FormID = 1,
                                InputID = 5,
                                ParentID = 1,
                                Order = 500,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 6,
                                FormID = 1,
                                InputID = 6,
                                ParentID = 5,
                                Order = 600,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 7,
                                FormID = 1,
                                InputID = 7,
                                ParentID = 6,
                                Order = 700,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 8,
                                FormID = 1,
                                InputID = 8,
                                ParentID = 6,
                                Order = 800,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 9,
                                FormID = 1,
                                InputID = 9,
                                ParentID = 8,
                                Order = 900,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 10,
                                FormID = 1,
                                InputID = 10,
                                ParentID = 9,
                                Order = 1000,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 11,
                                FormID = 1,
                                InputID = 11,
                                ParentID = 5,
                                Order = 1100,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 12,
                                FormID = 1,
                                InputID = 12,
                                ParentID = 11,
                                Order = 1200,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 13,
                                FormID = 1,
                                InputID = 8,
                                ParentID = 11,
                                Order = 1300,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 14,
                                FormID = 1,
                                InputID = 9,
                                ParentID = 13,
                                Order = 1400,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 15,
                                FormID = 1,
                                InputID = 13,
                                ParentID = 14,
                                Order = 1500,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 16,
                                FormID = 1,
                                InputID = 14,
                                ParentID = 1,
                                Order = 1600,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 17,
                                FormID = 1,
                                InputID = 15,
                                ParentID = 16,
                                Order = 1700,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 18,
                                FormID = 1,
                                InputID = 16,
                                ParentID = 16,
                                Order = 1800,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 19,
                                FormID = 1,
                                InputID = 17,
                                ParentID = 1,
                                Order = 1900,
                                IsActive = true
                            },
                            new FormInput
                            {
                                ID = 20,
                                FormID = 1,
                                InputID = 18,
                                ParentID = 19,
                                Order = 2000,
                                IsActive = true
                            },
                            new FormInput
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

                    context.SaveChanges();
                }
            }
        }
    }
}