using System;
using Newtonsoft.Json;

namespace ImageWorld.Core.Class
{
    /// <summary>
    /// this is the main image object which will live inside DocumentDb
    /// </summary>
    public class Image
    {
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// base64 encoded binary string
        /// I tried using byte[] and got 
        /// System.FormatException: Invalid length for a Base-64 char array or string.
        /// when uploading to DocDB
        /// </summary>
        public byte[] Bytes { get; set; }
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
