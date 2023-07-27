using HI.Model;
using Newtonsoft.Json;
namespace HI.WebUI.Core
{
    public class HIConvert
    {
        public static string HIJsonSerialize(object data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
            return json;
        }

        public static User HIJsonDeSerializeUser(string data)
        {
            return JsonConvert.DeserializeObject<User>(data);
        }
    }
}
