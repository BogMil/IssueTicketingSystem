using System;
using System.Globalization;
using System.Web.Mvc;

namespace IssueTicketingSystem
{
    public class DateTimeModelBinder : DefaultModelBinder
    {
        private readonly string _customFormat;

        public DateTimeModelBinder(string customFormat)
        {
            _customFormat = customFormat;
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            return DateTime.ParseExact(value.AttemptedValue, _customFormat, CultureInfo.InvariantCulture);
            //return base.BindModel(controllerContext, bindingContext);
        }
    }
}