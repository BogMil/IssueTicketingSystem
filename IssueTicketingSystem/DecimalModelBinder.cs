using System.Web.Mvc;
using DefaultModelBinder = System.Web.Mvc.DefaultModelBinder;

namespace IssueTicketingSystem
{
    public class DecimalModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult == null)
            {
                return base.BindModel(controllerContext, bindingContext);
            }

            var atemptedValue=valueProviderResult.AttemptedValue;
            if (atemptedValue == string.Empty)
                return 0;

            var strValue = atemptedValue.Replace('.', ',');
            decimal.TryParse(strValue, out var result);
            return result;
        }
    }
}