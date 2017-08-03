using System.Text;
using System.Linq;
using System.Collections.Generic;
using GenericController.Entities;

namespace GenericController.Framework
{
    public class HtmlParser
    {
        public string GenerateForm(View view)
        {
            if (view == null || view.Inputs == null)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();

            builder.AppendLine(GenerateHtml(view.Inputs));

            //builder.AppendLine(form.Script);
            return builder.ToString();
        }

        private string GenerateHtml(List<FormInputList> inputs, long? parentContainerId = null)
        {
            StringBuilder builder = new StringBuilder();
            
            var groupedModels = inputs.Where(m => m.ParentId == parentContainerId).GroupBy(m => m.Id).Select(m => m.First()).ToList();

            foreach (var groupedModel in groupedModels)
            {
                var input = inputs.Where(m => m.Id == groupedModel.Id).ToList();

                string type = input[0].Type;

                if (type == "label" || type == "option" || type=="a" || type == "span")
                {
                    var propertyList = input.First().InputProperties;

                    var propListWoutText = propertyList.Where(m=>m.PropertyName!="text" && m.PropertyName!=string.Empty).ToList();

                    if (propertyList.Any(m => m.PropertyName == "text"))
                    {
                        builder.AppendLine($"<{type}{GenerateProperties(propListWoutText)}>{propertyList.Where(m => m.PropertyName == "text").First().PropertyValue}</{type}>");
                    }
                    else
                    {
                        builder.AppendLine($"<{type}{GenerateProperties(propListWoutText)}>{GenerateHtml(inputs, input[0].Id)}</{type}>");
                    }
                }
                else
                {
                    builder.AppendLine($"<{type}{GenerateProperties(input.First().InputProperties)}>{GenerateHtml(inputs, input[0].Id)}</{type}>");
                }
            }

            return builder.ToString();
        }

        private string GenerateProperties(List<InputProperty> inputs)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var input in inputs)
            {
                builder.Append($" {input.PropertyName}=\"{input.PropertyValue}\"");
            }

            return builder.ToString();
        }
    }
}
