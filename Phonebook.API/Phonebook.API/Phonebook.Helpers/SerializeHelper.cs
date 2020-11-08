
using Newtonsoft.Json;

namespace Phonebook.Helpers
{
    public static class SerializeHelper
    {
        public static string SerializeObject(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }
        public static T DeserializeObject<T>(string stringToDesialize)
        {
            return JsonConvert.DeserializeObject<T>(stringToDesialize);
        }
    }
}
