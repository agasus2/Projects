using System;

namespace EmailAndHyperlinkSearch
{
   public class EmailAndHyperlinkEventArgs: EventArgs
    {
        public readonly string msg;
        public readonly string Value;
        public EmailAndHyperlinkEventArgs(string message, string value)
        {
            msg = message;
            Value = value;
        }
    }
}
