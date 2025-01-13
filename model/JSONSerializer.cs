using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class JSONSerializer<T>
    {
        //ATTRIBUTES
        private string filePath;
        private JsonSerializerSettings jsonSettings;

        //CONSTRUCTORS
        public JSONSerializer() 
        {
            this.jsonSettings = new JsonSerializerSettings() { 
                ContractResolver = new IncludePrivateResolver() };
        }


        //METHODS

        //Serialize
        public void serialize(T obj, string jsonFilePath)
        {
            string jsonText = JsonConvert.SerializeObject(obj,Formatting.Indented,jsonSettings);
            File.WriteAllText(jsonFilePath, jsonText);
        }

        //Deserialize
        public T deserialize(String jsonFilePath)
        {
            string jsonText = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<T>(jsonText,jsonSettings);
        }

    }
}
