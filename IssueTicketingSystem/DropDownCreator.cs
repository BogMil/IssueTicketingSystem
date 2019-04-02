using System.Collections.Generic;
using System.Text;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem
{
    public static class DropDownCreator
    {
        public static string Create(List<SelectListItem> items)
        {
            StringBuilder sb = new StringBuilder("<select>");
            foreach (var item in items)
            {
                sb.Append("<option value=\"" + item.Value + "\" >" + item.Text + "</option>");
            }
            sb.Append("</select>");

            return sb.ToString();
        }

        public static string CreateNullable(List<SelectListItem> items,string textForNullOption="нема")
        {
            StringBuilder sb = new StringBuilder("<select><option value=\"\">"+ textForNullOption+"</option>");
            foreach (var item in items)
            {
                sb.Append("<option value=\"" + item.Value + "\" >" + item.Text + "</option>");
            }
            sb.Append("</select>");

            return sb.ToString();
        }
    }
}