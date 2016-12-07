using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Install4ibas.Tools.Plugin.Messages
{
    public class Message
    {

        public Message()
        {
            this.ID = Guid.NewGuid().ToString().ToLower();
            this.Time = DateTime.Now;
        }

        public Message(emMessageType msgType, string msg, string tag)
            : this()
        {
            this.Type = msgType;
            this.Content = msg;
            this.Tag = tag;
        }

        public Message(emMessageType msgType, string msg)
            : this(msgType, msg, "")
        {

        }

        public string ID
        {
            set;
            get;
        }

        public DateTime Time
        {
            set;
            get;
        }

        public emMessageType Type
        {
            set;
            get;
        }

        public string Tag
        {
            set;
            get;
        }

        public string Content
        {
            set;
            get;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("message:");
            sb.AppendLine(string.Format("id:{0}", this.ID));
            sb.AppendLine(string.Format("time:{0}", this.Time.ToString("yyyy-MM-dd hh:mm:ss.fff")));
            sb.AppendLine(string.Format("type:{0}", this.Type));
            sb.AppendLine(string.Format("tag:{0}", this.Tag));
            sb.AppendLine(string.Format("content:{0}", this.Content));
            sb.AppendLine("****************************************");
            return sb.ToString();
        }
    }
    public enum emMessageType
    {
        warning, success, error
    }
}
