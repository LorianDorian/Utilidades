using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace Utilidades
{
    public class Objetos
    {
        public static string SerializeObject<T>(T objectToSerialize)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, objectToSerialize);
            return writer.ToString();
        }

        public static string SerializeObject(object obj)
        {
            return Serialize(obj);
        }

        public static byte[] SerializeToBinary(object obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }


    }
}
