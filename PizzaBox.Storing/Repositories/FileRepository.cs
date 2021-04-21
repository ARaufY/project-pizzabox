using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Repositories
{
  public class FileRepository
  {

    public T ReadFromFile<T>(string path) where T : class
    {
      try
      {
        var reader = new StreamReader(path);
        var xml = new XmlSerializer(typeof(T));

        var results = xml.Deserialize(reader) as T;
        return results;
      }
      catch (NullReferenceException e)
      {
        Console.WriteLine(e.StackTrace);
        return null;
      }
    }

    public bool WriteToFile<T>(string path, List<AStore> stores) where T : class
    {
      try
      {
        var writer = new StreamWriter(path);
        var xml = new XmlSerializer(typeof(T));

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