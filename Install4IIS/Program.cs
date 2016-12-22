using Install4ibas.Tools.Plugin.IISManager;

namespace Install4IIS
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in args)
            {
                System.Console.WriteLine(item);
            }
            IIISManager manager = IISManagerFactory.New().CreateIISManager();
            if (args.Length >= 1 && args[0]=="-u") //卸载
            {
                if (!manager.IsFullyInstalled())
                    manager.UninstallIIS();
            }
            else
            {
                if (!manager.IsFullyInstalled())
                    manager.InstallIIS();
            }
        }
    }
}
