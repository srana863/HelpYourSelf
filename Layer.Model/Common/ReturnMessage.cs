using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Model.Common
{
    public enum MessageTypes
    {
        Error = -1,
        None = 0,
        Success = 1,
        Info = 2,
        Warning = 3
    }
    public class ReturnMessage
    {
        public string Message { get; set; }
        public MessageTypes MessageType { get; set; }

        public ReturnMessage()
        {
            Message = string.Empty;
            MessageType = MessageTypes.None;
        }

        public static ReturnMessage SetSuccessMessage(string message = "Data has been saved")
        {
            var msg = new ReturnMessage();
            msg.MessageType = MessageTypes.Success;
            msg.Message = message;

            return msg;
        }
        public static ReturnMessage SetErrorMessage(string message = "Failed to save data")
        {
            var msg = new ReturnMessage();
            msg.MessageType = MessageTypes.Error;
            msg.Message = message;
            return msg;
        }
        public static ReturnMessage SetInfoMessage(string message = "Information")
        {
            var msg = new ReturnMessage();
            msg.MessageType = MessageTypes.Info;
            msg.Message = message;
            return msg;
        }
        public static ReturnMessage SetWarningMessage(string message = "Warning")
        {
            var msg = new ReturnMessage();
            msg.MessageType = MessageTypes.Warning;
            msg.Message = message;
            return msg;
        }
    }
}