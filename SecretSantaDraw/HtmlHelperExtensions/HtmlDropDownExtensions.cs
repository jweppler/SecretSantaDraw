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
/*        public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper htmlHelper, string name, TEnum selectedValue)
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
*/

        public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper htmlHelper, string name, TEnum selectedValue)
        {
            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>();

            List<SelectListItem> items = new List<SelectListItem> {};
            Type type = typeof(TEnum);
            object[] attributes = new object[] { };
            string displayName;
            foreach (var v in values)
            {
                var memberInfo = type.GetMember(v.ToString());
                attributes = new object[] {};
                displayName = null;
                if (memberInfo.Length > 0)
                    attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                if(attributes.Length > 0)
                    displayName = ((DisplayAttribute)attributes[0]).Name;
                items.Add(new SelectListItem()
                {
                    Text = displayName != null ? displayName : v.ToString(),
                    Value = v.ToString(),
                    Selected = (v.Equals(selectedValue))
                });
            }

            return htmlHelper.DropDownList(
                name,
                items
                );
        }

        public static MvcHtmlString EnumDisplayName<TEnum>(this HtmlHelper htmlHelper, string name, TEnum value)
        {
            Type type = typeof(TEnum);
            string displayName = null;
            var attributes = new object[] { };
            var memberInfo = type.GetMember(value.ToString());
            if (memberInfo.Length > 0)
                attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes.Length > 0)
                displayName = ((DisplayAttribute)attributes[0]).Name;

            return new MvcHtmlString(displayName != null ? displayName : value.ToString());
        }

        public static string GetDisplayAttributeFrom(this Enum enumValue, Type type)
        {
            var memberInfo = type.GetMember(enumValue.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            var description = ((DisplayAttribute)attributes[0]).Name;

            return description != null ? description : enumValue.ToString();
        }

    }
}