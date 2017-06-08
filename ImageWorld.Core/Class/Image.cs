using System;
using Newtonsoft.Json;

namespace ImageWorld.Core.Class
{
    /// <summary>
    /// this is the main image object which will live inside DocumentDb
    /// </summary>
    public class Image
    {
        public bool ProcessedCustomVision { get; set; }
        public bool ProcessedCognitiveServices { get; set; }
        public bool ProcessedAzureMachineLearning { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
        public string PredictedCaption { get; set; }
        public bool WaldoDetected { get; set; }
        public bool IllegalWatermark { get; set; }
        public byte[] Bytes { get; set; }
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
