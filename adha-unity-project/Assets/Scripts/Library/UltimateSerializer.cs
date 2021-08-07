
// ultimate serializer!

// usage:
// ClassName className = (ClassName)USerialization.Deserialize<ClassName>(data);
// byte[] data = USerialization.Serialize(className);

using System;

using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

namespace UltimateSerializer {

    public static class USerialization {

        public static byte[] Serialize (object obj) {

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();

            binaryFormatter.Serialize(memoryStream, obj);

            return memoryStream.ToArray();
        }
        public static object Deserialize<T> (byte[] data) {

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();

            memoryStream.Write(data, 0, data.Length);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return (T)binaryFormatter.Deserialize(memoryStream);
        }
    }
}
