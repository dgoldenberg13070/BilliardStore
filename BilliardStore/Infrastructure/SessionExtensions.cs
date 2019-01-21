//The infrastructure folder holds cs files that are not related to the application's domain
//called by SessionCart.cs
//this class defines extension methods so that the methods appear to part of the Session class as that class doesn't have these methods
using Microsoft.AspNetCore.Http;

namespace BilliardStore.Infrastructure
{
    //static class so no constructor...at the class level, no instance created   
    public static class SessionExtensions
    {

        public static void SetJson(this Microsoft.AspNetCore.Http.ISession session, string key, object value)
        {
            session.SetString(key, Newtonsoft.Json.JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this Microsoft.AspNetCore.Http.ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : Newtonsoft.Json.JsonConvert.DeserializeObject<T>(sessionData);
        }

    }

}