using System;

namespace SalesWeb.Services.Exceptions
{
    public class IntegrityExceeption : ApplicationException
    {

        public IntegrityExceeption(string message) : base(message)
        {

        }
    }
}
