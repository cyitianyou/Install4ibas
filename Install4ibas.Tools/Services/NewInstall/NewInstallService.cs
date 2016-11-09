using Install4ibas.Tools.Services.Basis;

namespace Install4ibas.Tools.Services.NewInstall
{
    public class NewInstallService : BasisInstalllService
    {
        public const string SERVICECODE = "New";
        public override string ServiceCode
        {
            get { return SERVICECODE; }
        }
    }
}
