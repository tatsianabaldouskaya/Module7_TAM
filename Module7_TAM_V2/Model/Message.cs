using System;
using System.Collections.Generic;

namespace Module7_TAM_V2.Model
{
    public class Message
    {
        public readonly string addresseeValue;
        public readonly string subjectValue;
        public readonly string bodyValue;

        public Message(string addresseeValue, string subjectValue, string bodyValue)
        {
            this.addresseeValue = addresseeValue;
            this.subjectValue = subjectValue;
            this.bodyValue = bodyValue;
        }
    }
}
