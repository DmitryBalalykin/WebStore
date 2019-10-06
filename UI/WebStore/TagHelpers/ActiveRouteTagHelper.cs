using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebStore.TagHelpers
{
    [HtmlTargetElement(Attributes = AttributeName)]
    public class ActiveRouteTagHelper:TagHelper
    {
        public const string AttributeName = "is-active-route";

        public const string IgnoreActionName = "ignore-action";

        [HtmlAttributeName("asp-action")]
        public string action { get; set; }

        [HtmlAttributeName("asp-controller")]
        public string controller { get; set; }

        private IDictionary<string, string> _roteValues;

        [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix = "asp-route-")]
        public IDictionary<string, string> roleValue
        {
            get => _roteValues ?? (_roteValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
            set => _roteValues = value;
        }

        [HtmlAttributeNotBound, ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var ignore_action = context.AllAttributes.TryGetAttribute(IgnoreActionName, out _);

            if (IsActive(ignore_action))
            {
                MakeActive(output);
            }

            output.Attributes.RemoveAll(AttributeName);
        }

        /// <summary>
        /// Проверка на активность элемента
        /// </summary>
        /// <returns></returns>
        private bool IsActive(bool IgnoreAction)
        {
            var route_value = ViewContext.RouteData.Values;

            var current_controller = route_value["controller"].ToString();
            var current_action = route_value["action"].ToString();

            const StringComparison ignore_case = StringComparison.OrdinalIgnoreCase;
            if (!string.IsNullOrWhiteSpace(controller) && !string.Equals(controller, current_controller, ignore_case))
            {
                return false;
            }

            if (!IgnoreAction && !string.IsNullOrWhiteSpace(action) && !string.Equals(action, current_action, ignore_case))
            {
                return false;
            }

            foreach (var (key,value) in roleValue)
            {
                if (!route_value.ContainsKey(key) || route_value[key].ToString() != value)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Делает элемент активным
        /// </summary>
        private static void MakeActive(TagHelperOutput output)
        {
            var class_attribute = output.Attributes.FirstOrDefault(a => a.Name == "class");

            if (class_attribute is null)
            {
                class_attribute = new TagHelperAttribute("class", "active");

                output.Attributes.Add(class_attribute);
            }
            else
            {
                output.Attributes.SetAttribute(
                    "class",
                    class_attribute.Value is null
                    ? "activ"
                    : class_attribute.Value + "active");
            }
        }
    }
}
