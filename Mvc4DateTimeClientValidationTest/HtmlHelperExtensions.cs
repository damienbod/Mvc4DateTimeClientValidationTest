using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Routing;
using System.Web.Mvc;

namespace Mvc4DateTimeClientValidationTest
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString HiddenForWithoutValidation<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return HiddenForWithoutValidation(htmlHelper, expression, null);
        }

        public static MvcHtmlString HiddenForWithoutValidation<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var name = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
            var id = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression));

            var value = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model;
            var routeValueDict = htmlAttributes != null ? new RouteValueDictionary(htmlAttributes) : new RouteValueDictionary();

            return HiddenForWithoutValidation(name, id, value, routeValueDict);
        }

        private static MvcHtmlString HiddenForWithoutValidation(string name, string id, object value, IEnumerable<KeyValuePair<string, object>> routeValueDict)
        {
            var input = new TagBuilder("input");
            if (!string.IsNullOrEmpty(id))
            {
                input.Attributes.Add("id", id);
            }
            input.Attributes.Add("name", name);
            input.Attributes.Add("type", "hidden");
            foreach (var routeValue in routeValueDict)
            {
                input.MergeAttribute(routeValue.Key, routeValue.Value.ToString(), true);
            }

            if (value != null)
            {
                input.Attributes.Add("value", value.ToString());
            }

            return new MvcHtmlString(input.ToString(TagRenderMode.SelfClosing));
        }
    }
}