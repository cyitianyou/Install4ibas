using Install4ibas.Tools.Services.Basis;

namespace Install4ibas.Tools.Services.AppendInstall
{
    public class AppendInstallService : BasisInstalllService
    {
        public const string SERVICECODE = "Append";
        public override string ServiceCode
        {
            get { return SERVICECODE; }
        }
    }
}
