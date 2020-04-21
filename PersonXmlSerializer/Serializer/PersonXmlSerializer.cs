using PersonXmlSerializer.Models;
using System;
using System.IO;
using System.Xml.Serialization;

namespace PersonXmlSerializer.Serializer
{
    public class PersonXmlSerializer<T> where T : Person
    {
        private string AppPath = AppDomain.CurrentDomain.BaseDirectory; // change if needed
        private const string FileName = "TempFileName.xml"; // change if needed

        public void SerializePersonObjectToXml(T personObject)
        {
            var filePath = Path.Combine(AppPath, FileName);
            StreamWriter streamWriter = null;

            try
            {
                streamWriter = new StreamWriter(filePath, true);
                var xmlSerializer = new XmlSerializer(typeof(T));

                xmlSerializer.Serialize(streamWriter, personObject);

                Console.WriteLine($"Successfully serialized the {nameof(T)} object");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not serialize the {nameof(T)} object due to : {e.Message}");
            }
            finally
            {
                streamWriter?.Close();
            }
        }
    }
}
