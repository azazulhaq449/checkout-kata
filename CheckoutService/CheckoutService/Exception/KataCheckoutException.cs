using System;
using System.Collections.Generic;

namespace KataCheckout.Exception
{
    public class KataCheckoutException : ApplicationException
    {
        public KataCheckoutException(string messageId, string messageText, params object[] parameters) : base(string.Format(messageText, parameters))
        {
            MessageID = messageId;
            Parameters = new List<object>(parameters);
        }

        public string MessageID { get; }
        public List<object> Parameters { get; }
    }
}
