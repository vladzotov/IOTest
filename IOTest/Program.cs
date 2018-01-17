using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Cellphones;

namespace IOTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Cellphone obj = new Cellphone();
            obj.Id = 1;
            obj.Manufacturer = "Apple";
            obj.Model = "X";
            obj.Price = 1400;

            IFormatter binaryFormatter = new BinaryFormatter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Cellphone));

            Stream stream = new FileStream(
                @"D:\IOTest\MyFile.bin", 
                FileMode.Create, 
                FileAccess.Write, 
                FileShare.None);
            FileStream fileStream = new FileStream(
                @"D:\IOTest\MyXMLFile.xml", 
                FileMode.Create, 
                FileAccess.Write, 
                FileShare.None);

            binaryFormatter.Serialize(stream, obj);
            xmlSerializer.Serialize(fileStream, obj);
            stream.Close();
            fileStream.Close();
        }
    }
}
