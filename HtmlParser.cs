using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace GenericVC
{
    public class HtmlParser
    {
        public string GenerateForm(dynamic form)
        {
            if (form == null || form.Inputs == null || form.Inputs.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();

            builder.AppendLine(GenerateHtml(new List<dynamic>(form.Inputs)));

            //builder.AppendLine(form.Script);
            return builder.ToString();
        }

        private string GenerateHtml(List<dynamic> inputs, long parentContainerId = 0)
        {
            StringBuilder builder = new StringBuilder();

            //gruplama yapılıyor. Örneğin selectoption'un birden fazla property ve valuesu olabilir. bunu düzgün oluşturabilmek için
            var groupedModels = inputs.Where(m => m.ParentId == parentContainerId).GroupBy(m => m.Id).Select(m => m.First()).ToList();

            foreach (var groupedModel in groupedModels)
            {
                var input = inputs.Where(m => m.Id == groupedModel.Id).ToList();

                string type = input[0].Type;

                if (type == "label" || type == "option" || type=="a")
                {
                    builder.AppendLine($"<{type} {GenerateProperties(inputs.Where(m => m.Id == input[0].Id && m.PropertyName != "text" && m.PropertyName != string.Empty).ToList())}>{input.Where(m => m.PropertyName == "text").First().PropertyValue}</{type}>");
                }
                else if (type == "button")
                {
                    if (inputs.Any(m => m.Id == input[0].Id && m.PropertyName == "text"))
                    {
                        builder.AppendLine($"<{type} {GenerateProperties(inputs.Where(m => m.Id == input[0].Id && m.PropertyName != "text" && m.PropertyName != string.Empty).ToList())}>{input.Where(m => m.PropertyName == "text").First().PropertyValue}</{type}>");
                    }
                    else
                    {
                        builder.AppendLine($"<{type} {GenerateProperties(inputs.Where(m => m.Id == input[0].Id && m.PropertyName != string.Empty).ToList())}>{GenerateHtml(inputs, input[0].Id)}</{type}>");
                    }
                }
                else
                {
                    builder.AppendLine($"<{type} {GenerateProperties(inputs.Where(m => m.Id == input[0].Id && m.PropertyName != string.Empty).ToList())}>{GenerateHtml(inputs, input[0].Id)}</{type}>");
                }
            }

            return builder.ToString();
        }

        private string GenerateProperties(List<dynamic> inputs)
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