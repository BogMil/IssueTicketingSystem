using System;

namespace GenericCSR.Controller
{
    public static class ErrorMessageCreator
    {
        public static object GetMessage(Exception e)
        {
            while (e.InnerException != null)
                e = e.InnerException;

            var message = e.Message;

            return new
            {
                error = "Something happened:\n" + message
            };
        }

        public static object GetUnauthorizedMessage()
        {
            return new
            {
                error = "Нисте ауторизовани за ову акцију!"
            };
        }
    }
}