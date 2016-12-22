using Install4ibas.Tools.Plugin.IISManager;
using System;
using System.Runtime.InteropServices;

namespace Install4IIS
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program(args);
        }

        public Program(string[] args)
        {
            Console.Title = "安装IIS";
            IntPtr ParenthWnd = new IntPtr(0);
            IntPtr et = new IntPtr(0);
            ParenthWnd = FindWindow(null, "安装IIS");
            ShowWindow(ParenthWnd, 0);//隐藏本dos窗体, 0: 后台执行；1:正常启动；2:最小化到任务栏；3:最大化

            //作自己的事情
            IIISManager manager = IISManagerFactory.New().CreateIISManager();
            if (args.Length >= 1 && args[0] == "-u") //卸载
            {
                if (!manager.IsFullyInstalled())
                    manager.UninstallIIS();
            }
            else
            {
                System.Console.WriteLine("正在安装IIS,请稍候...");
                if (!manager.IsFullyInstalled())
                    manager.InstallIIS();
            }

            Console.Write("Exit");

        }

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]   //找子窗体   
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]   //用于发送信息给窗体   
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        [DllImport("User32.dll", EntryPoint = "ShowWindow")]   //
        private static extern bool ShowWindow(IntPtr hWnd, int type);


    }
}
