using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ReuseSchemeTool.model
{
    public class IncludePrivateResolver: DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            //Include private fields
            FieldInfo[] privateFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo field in privateFields) 
            {
                JsonProperty jsonProperty = base.CreateProperty(field, memberSerialization);
                jsonProperty.Writable = true;
                jsonProperty.Readable = true;
                props.Add(jsonProperty);
            }
            return props;
        }
    }
}
