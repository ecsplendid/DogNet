﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImageWorld.Core {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.1.0.0")]
    public sealed partial class Config : global::System.Configuration.ApplicationSettingsBase {
        
        private static Config defaultInstance = ((Config)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Config())));
        
        public static Config Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://hsbc-image-database.documents.azure.com:443/")]
        public string DocDbEndpointUrl {
            get {
                return ((string)(this["DocDbEndpointUrl"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ImagesDatabase")]
        public string DocDbName {
            get {
                return ((string)(this["DocDbName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Images")]
        public string DocDbCollectionName {
            get {
                return ((string)(this["DocDbCollectionName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Endpoint=sb://hsbc-china-queue.servicebus.windows.net/;SharedAccessKeyName=basicP" +
            "olicy;SharedAccessKey=lFj2DETk0R6jrN2r3aL3nXMGIGgvJ1pYLHmOMERMSb8=;EntityPath=Im" +
            "ages")]
        public string ServiceBusConnectionString {
            get {
                return ((string)(this["ServiceBusConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Jvx9ScleKSWy0hQrBp3kGsqKryNoAXmBhfMQIYFzBHzpcHgUNTGGjpEmAhqheizy2v0c2SxIpWmrLYFdl" +
            "zhb2g==")]
        public string DocDbKey {
            get {
                return ((string)(this["DocDbKey"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("94b9defab2d447f8ab6c95cbca04b075")]
        public string VisionApiKey {
            get {
                return ((string)(this["VisionApiKey"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://southeastasia.api.cognitive.microsoft.com/vision/v1.0")]
        public string VisionBaseAddress {
            get {
                return ((string)(this["VisionBaseAddress"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5e869f76b47943a2a7406eb55b3057dd")]
        public string CustomVisionPredictionKey {
            get {
                return ((string)(this["CustomVisionPredictionKey"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10358a1a-a599-4c4e-a598-41fa7ccfb076")]
        public string CustomVisionIterationId {
            get {
                return ((string)(this["CustomVisionIterationId"]));
            }
        }
    }
}
