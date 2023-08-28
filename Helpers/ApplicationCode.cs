namespace SC.VersionManagement.Helpers
{
    public static class ApplicationCode
    {
        //Common
        public const string NOT_FOUND = "Not found";
        public const string ERROR_SYSTEM = "System error";
        public const string INVALID_TEXT = "Invalid text";
        public const string INVALID_DATETIME = "Invalid datetime";
        public const string INVALID_COSTPRICE = "Invalid cost price";
        public const string INVALID_TOTALPRICE = "Invalid total price";
        public const string INVALID_QUANTITY = "Invalid quantity";
        public const string INVALID_TYPE = "Invalid Type";
        public const string INVALID_IDENTITYTENANTID = "Invalid IdentityTenantId";
        public const string INVALID_IDENTITYWORKGROUPID = "Invalid IdentityWorkGroupId";
        public const string INVALID_REQUEST_DATA = "Invalid Request data";
        public const string REQUEST_EVENT_DATA_INVALID = "Request event data invalid";

        //Supplier
        public const string ERROR_EXISTED = "Version Environment is exists";
        public const string ERROR_NOT_ENVIROMENT = "Environment is not exists";
        public const string ERROR_NOT_URLFILE = "Environment Url is not null";

        public const string ERROR_VERSIONLOCKDATE_EXISTED = "Thời gian khoá version đã tồn tại";
        public const string ERROR_VERSIONLOCKDATE_NOT_EXISTED = "Thời gian khoá version không tồn tại";
        public const string ERROR_VERSIONDETAIL_EXISTED = "Thời gian khoá chi tiết version đã tồn tại";
    }

    public class ErrorCode
    {
        public static string GetApplicationCodegByErrorCode(long codeSql, string appCodeDefault = nameof(ApplicationCode.ERROR_SYSTEM))
        {
            switch (codeSql)
            {
                case -99: { appCodeDefault = nameof(ApplicationCode.ERROR_SYSTEM); break; }
                case -100: { appCodeDefault = nameof(ApplicationCode.ERROR_EXISTED); break; }
                case -101: { appCodeDefault = nameof(ApplicationCode.ERROR_NOT_ENVIROMENT); break; }
                case -102: { appCodeDefault = nameof(ApplicationCode.ERROR_NOT_URLFILE); break; }
                case -119: { appCodeDefault = nameof(ApplicationCode.ERROR_SYSTEM); break; }
                case -120: { appCodeDefault = nameof(ApplicationCode.ERROR_VERSIONLOCKDATE_EXISTED); break; }
                case -121: { appCodeDefault = nameof(ApplicationCode.ERROR_VERSIONLOCKDATE_NOT_EXISTED); break; }
                case -122: { appCodeDefault = nameof(ApplicationCode.ERROR_VERSIONDETAIL_EXISTED); break; }
            }
            return appCodeDefault;
        }
        public enum EnumErrorCode
        {
            INVALID_TEXT = -95,
        }
    }
}
