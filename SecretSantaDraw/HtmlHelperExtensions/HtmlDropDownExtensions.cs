using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SecretSantaDraw.Models;

namespace SecretSantaDraw.HtmlHelperExtensions
{
    public static class HtmlDropDownExtensions
    {
        public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper htmlHelper, string name, TEnum selectedValue)
        {
            IEnumerable<SelectListItem> values = Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = v.ToString(),
                    Selected = (v.Equals(selectedValue))
                });

            return htmlHelper.DropDownList(
                name,
                values
                );
        }

    }
}