using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSR_Client
{
    public class SocketMessage
    {
        public string SenderId { get; set; }
        public string SenderUsername { get; set; }
        public string Type { get; set; }
        public object Payload { get; set; }
        public string ReceiverId { get; set; }

        public SocketMessage(string senderId, string senderUsername, string type, object payload)
        {
            SenderId = senderId;
            SenderUsername = senderUsername;
            Type = type;
            Payload = payload;
        }

        public SocketMessage()
        {
        }


        public class Builder
        {
            private SocketMessage _message = new SocketMessage();

            public Builder SetSenderId(string senderId)
            {
                _message.SenderId = senderId;
                return this;
            }

            public Builder SetSenderUsername(string senderUsername)
            {
                _message.SenderUsername = senderUsername;
                return this;
            }

            public Builder SetType(string type)
            {
                _message.Type = type;
                return this;
            }

            public Builder SetPayload(object payload)
            {
                _message.Payload = payload;
                return this;
            }

            public Builder SetReceiverId(string receiverId)
            {
                _message.ReceiverId = receiverId;
                return this;
            }

            public SocketMessage Build()
            {
                return _message;
            }
        }
    }
}
