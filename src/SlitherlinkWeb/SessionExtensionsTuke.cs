using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Microsoft.AspNetCore.Http
{
    public static class SessionExtensionsTuke
    {
        public static object GetObjects(this ISession session, string key)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream(session.Get(key));
            return bf.Deserialize(memoryStream);
        }
        public static void SetObject(this ISession session, string key, object value)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            bf.Serialize(memoryStream, value);
            long len = memoryStream.Length;
            byte[] serialized = new byte[len];
            Array.Copy(memoryStream.GetBuffer(), serialized, len);
            session.Set(key, serialized);
        }
    }
}
