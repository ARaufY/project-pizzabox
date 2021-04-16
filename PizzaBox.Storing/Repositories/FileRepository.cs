using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Repositories
{
  public class FileRepository
  {

    public List<AStore> ReadFromFile(string path)
    {
      try
      {
        var reader = new StreamReader(path);
        var xml = new XmlSerializer(typeof(List<AStore>));

        return xml.Deserialize(reader) as List<AStore>;
      }
      catch
      {

        return null;
      }
    }

    public bool WriteToFile(string path, List<AStore> stores)
    {
      try
      {
        var writer = new StreamWriter(path);
        var xml = new XmlSerializer(typeof(List<AStore>));

        xml.Serialize(writer, stores);
        return true;
      }
      catch
      {

        return false;
      }
    }
  }
}