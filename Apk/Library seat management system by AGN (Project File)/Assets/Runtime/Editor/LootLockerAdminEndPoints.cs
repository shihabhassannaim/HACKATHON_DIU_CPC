using UnityEngine;

#if UNITY_EDITOR && UNITY_2021_3_OR_NEWER
namespace LootLocker
{
    public class LootLockerAdminEndPoints
    {
        [Header("API Keys")]
        public static EndPointClass adminExtensionGetAllKeys = new EndPointClass("game/{0}/api_keys", LootLockerHTTPMethod.GET);
        public static EndPointClass adminExtensionCreateKey = new EndPointClass("game/{0}/api_keys", LootLockerHTTPMethod.POST);

        [Header("Admin Authentication")]
        public static EndPointClass adminExtensionLogin = new EndPointClass("v1/session", LootLockerHTTPMethod.POST);
        public static EndPointClass adminExtensionMFA = new EndPointClass("v1/2fa", LootLockerHTTPMethod.POST);

        [Header("User Information")]
        public static EndPointClass adminExtensionUserInformation = new EndPointClass("v1/user/all", LootLockerHTTPMethod.GET);
        public static EndPointClass adminExtensionGetUserRole = new EndPointClass("roles/{0}", LootLockerHTTPMethod.GET);
        public static EndPointClass adminExtensionGetGameInformation = new EndPointClass("v1/game/{0}", LootLockerHTTPMethod.GET);
    }
}
#endif