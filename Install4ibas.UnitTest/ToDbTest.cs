using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Install4ibas.Tools.Common.InstallInformation;

namespace Install4ibas.UnitTest
{
    [TestClass]
    public class ToDbTest
    {
        [TestMethod]
        public void ToDbTestMethod()
        {
            AppSetting app = new AppSetting();
            //app.B1Password = this.txtB1Password.Text;
            //app.B1Server = this.txtB1Server.Text;
            //app.B1User = this.txtB1User.Text;
            //app.B1Type = this.cmbB1Type.Text;
            //app.cmbLanguage = this.cmbLanguage.Text;
            app.DatabaseType = "SSQL";
            app.DBName = "StallTest";
            app.DBPassword = "avatech";
            app.DBServer ="localhost";
            app.DBUser = "sa";
            app.IISAddress = "";
            app.IISPort = "8011";
            app.InstallDiraddress = @"F:\IbasTest\StallTest";
            Install4ibas.Tools.Services.Basis.Step.InstallStep_DbCreate dbstep=new Tools.Services.Basis.Step.InstallStep_DbCreate();
            dbstep.AppSetting = app;
            dbstep.Excute();
         
        }
    }
}
