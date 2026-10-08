using System.IO;
using System.Xml.Serialization;

namespace MinesweeperCore
{
    /// Generička pomoćna klasa za serijalizaciju i deserijalizaciju objekata u/iz XML fajla.
    /// Koristi se i za podešavanja, i za raspored mina, i za stanje partije.

    public static class XmlFileHelper
    {
        public static void Save<T>(T data, string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, data);
            }
        }

        public static T Load<T>(string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(filePath))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
