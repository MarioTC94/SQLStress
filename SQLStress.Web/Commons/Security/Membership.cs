using WebMatrix.WebData;

namespace SQLStress.Web.Commons.Security
{
    public class Membership
    {
        public static void Initialize()
        {
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("DataBaseName", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        }

    }
}