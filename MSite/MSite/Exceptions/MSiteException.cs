using System;
using System.Collections.Generic;

namespace MSite.Exceptions
{
    public class MSiteException : ApplicationException
    {
        public MSiteException(string messageId, string messageText, params object[] parameters) : base(string.Format(messageText, parameters))
        {
            MessageID = messageId;
            Parameters = new List<object>(parameters);
        }

        public string MessageID { get; }
        public List<object> Parameters { get; }
    }
}
