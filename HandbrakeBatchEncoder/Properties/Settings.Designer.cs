﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HandbrakeBatchEncoder.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Program Files\\HandBrake\\HandBrakeCLI.exe")]
        public string HandbrakeCliPath {
            get {
                return ((string)(this["HandbrakeCliPath"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(" -f avi -w 320 --deinterlace=\"slow\" -e xvid -b 500 -2  -a 1 -E lame -B 160 -R 0 -" +
            "6 dpl2 -D 1 -v ")]
        public string EncodeSettings {
            get {
                return ((string)(this["EncodeSettings"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\Temp\\Drop")]
        public string WatchFolder {
            get {
                return ((string)(this["WatchFolder"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\Temp\\Complete")]
        public string OutputFolder {
            get {
                return ((string)(this["OutputFolder"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(" -f avi -w 720 --deinterlace=\"slow\" -e xvid -b 1200 -2  -a 1 -E lame -B 160 -R 0 " +
            "-6 dpl2 -D 1 -v ")]
        public string zEncodeSettings {
            get {
                return ((string)(this["zEncodeSettings"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Completed")]
        public string CompletedInputFolder {
            get {
                return ((string)(this["CompletedInputFolder"]));
            }
        }
    }
}