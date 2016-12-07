using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Install4ibas.Tools.Plugin.Messages
{
    public class FileMessageRecorder
    {
        #region 初始化及基本属性
        public FileMessageRecorder(string folder, string fileName)
        {
            this.WorkFolder = folder;
            this.WorkFileName = fileName;
        }

        public FileMessageRecorder(string fileName)
            : this("", fileName)
        {

        }

        string _WorkFolder;
        /// <summary>
        /// 工作目录，日志文件目录
        /// </summary>
        public string WorkFolder
        {
            set { _WorkFolder = value; }
            get
            {
                if (string.IsNullOrEmpty(_WorkFolder))
                    _WorkFolder = System.AppDomain.CurrentDomain.BaseDirectory;

                if (!System.IO.Directory.Exists(_WorkFolder))
                    System.IO.Directory.CreateDirectory(_WorkFolder);
                if (!_WorkFolder.EndsWith(@"\"))
                    _WorkFolder += @"\";//补全路径
                return _WorkFolder;
            }
        }
        string _WorkFileName;
        /// <summary>
        /// 工作的文件名称
        /// </summary>
        public string WorkFileName
        {
            get
            {
                if (string.IsNullOrEmpty(_WorkFileName))
                    _WorkFileName = string.Format("log_{0}.txt", Guid.NewGuid().ToString());
                return string.Format("{0}{1}", this.WorkFolder, _WorkFileName);
            }
            set
            {
                if (value.IndexOf(@":\") > 0)//如果是带路径的名称，仅取名称
                {
                    _WorkFileName = System.IO.Path.GetFileName(value);
                    _WorkFolder = System.IO.Path.GetDirectoryName(value);
                }
                else
                    _WorkFileName = value;
            }
        }
        #endregion

        #region 记录消息的方法
        /// <summary>
        /// 记录消息
        /// </summary>
        /// <param name="message">消息字符串</param>
        public void Recording(string message)
        {
            lock (this)
            {
                System.IO.StreamWriter fileWriter;
                if (System.IO.File.Exists(this.WorkFileName))
                    fileWriter = System.IO.File.AppendText(this.WorkFileName);
                else
                {
                    if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(this.WorkFileName)))
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(this.WorkFileName));
                    fileWriter = System.IO.File.CreateText(this.WorkFileName);
                }
                fileWriter.WriteLine(message);
                fileWriter.Close();
            }
        }

        /// <summary>
        /// 记录消息
        /// </summary>
        /// <param name="error">错误</param>
        public void Recording(System.Exception error)
        {
            var msg = new Message(emMessageType.error, error.ToString());
            this.Recording(msg);
            
        }
        /// <summary>
        /// 记录消息
        /// </summary>
        /// <param name="message">消息模板</param>
        /// <param name="args">参数集合</param>
        public void Recording(string message, params object[] args)
        {
            var tmpMsg = string.Format(message, args);
            this.Recording(tmpMsg);
        }

        /// <summary>
        /// 记录消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="msgType">消息类型</param>
        public void Recording(emMessageType msgType, string message)
        {
            var msg = new Message(msgType, message);
            this.Recording(msg);
        }
        /// <summary>
        /// 记录消息
        /// </summary>
        /// <param name="msgType">消息类型</param>
        /// <param name="message">消息模板</param>
        /// <param name="args">参数集合</param>
        public void Recording(emMessageType msgType, string message, params object[] args)
        {
            var msg = new Message(msgType, string.Format(message, args));
            this.Recording(msg);
        }

        /// <summary>
        /// 记录消息
        /// </summary>
        /// <param name="message">消息</param>
        public void Recording(Message message)
        {
            this.Recording(message.ToString());
        }
        #endregion
    }
}
