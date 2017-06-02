using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Layer.Model.Common;
using System.Configuration;

namespace HelpYourSelf
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            #region DataBase ConnectionString Setting
            AppSetting.DatabaseProvider = "System.Data.SqlClient";
            var serverName = ConfigurationManager.AppSettings["ServerName"].ToString();
            var dataBaseName = ConfigurationManager.AppSettings["DataBaseName"].ToString();
            var username = ConfigurationManager.AppSettings["UserName"].ToString();
            var password = ConfigurationManager.AppSettings["Password"].ToString();

            //AppSetting.ServerName = DataEncryptionUtilities.GenerateDecryptedString(serverName);
            //AppSetting.DataBaseName = DataEncryptionUtilities.GenerateDecryptedString(dataBaseName);
            //AppSetting.UserName = DataEncryptionUtilities.GenerateDecryptedString(username);
            //AppSetting.Password = DataEncryptionUtilities.GenerateDecryptedString(password);

            AppSetting.ServerName = serverName;
            AppSetting.DataBaseName = dataBaseName;
            AppSetting.UserName = username;
            AppSetting.Password = password;


            AppSetting.ConnectionString = string.Format("server={0} ; database={1} ; uid={2} ; pwd={3} ;", AppSetting.ServerName, AppSetting.DataBaseName, AppSetting.UserName, AppSetting.Password);
            #endregion
        }
    }
}
