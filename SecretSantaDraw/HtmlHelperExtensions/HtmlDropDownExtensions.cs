using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SecretSantaDraw.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace SecretSantaDraw.HtmlHelperExtensions
{
    public static class HtmlDropDownExtensions
    {
        public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper htmlHelper, string name, TEnum selectedValue)
        {
            IEnumerable<SelectListItem> values = Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>().Select(v => new SelectListItem
                {

                    Text = GetDisplayAttributeFrom(v, typeof(TEnum)),
                    Value = v.ToString(),
                    Selected = (v.Equals(selectedValue))
                });

            return htmlHelper.DropDownList(
                name,
                values
                );
        }

        public static MvcHtmlString EnumDisplayName<TEnum>(this HtmlHelper htmlHelper, string name, TEnum value)
        {
            return new MvcHtmlString(GetDisplayAttributeFrom(value, typeof(TEnum)));
        }

        public static string GetDisplayAttributeFrom<TEnum>(this TEnum value, Type type)
        {
            string displayName = null;
            var attributes = new object[] { };
            var memberInfo = type.GetMember(value.ToString());
            if (memberInfo.Any())
                attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes.Any())
                displayName = ((DisplayAttribute)attributes[0]).Name;

            return displayName != null ? displayName : value.ToString();
        }

    }
}