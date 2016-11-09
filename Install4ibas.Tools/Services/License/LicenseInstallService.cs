using Install4ibas.Tools.Services.Basis;

namespace Install4ibas.Tools.Services.License
{
    class LicenseInstallService : BasisInstalllService
    {
        public const string SERVICECODE = "License";
        public override string ServiceCode
        {
            get { return SERVICECODE; }
        }
    }
}
