using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDocWriter.Application.Settings
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;

    using MDocWriter.Application.Workspaces;

    public sealed class SettingReader
    {
        public const string SettingFileExtension = "setting";
        public const string SettingDirectory = @"settings";

        private readonly string settingPath;

        public SettingReader()
        {
            this.settingPath = Path.Combine(Application.StartupPath, SettingDirectory);
        }

        public T ReadSetting<T>() where T : Setting
        {
            var settingsFile = Path.Combine(this.settingPath, typeof(T).FullName + "." + SettingFileExtension);
            using (var fileStream = new FileStream(settingsFile, FileMode.Open, FileAccess.Read))
            {
                var serializer = new BinaryFormatter();
                return (T)serializer.Deserialize(fileStream);
            }
        }

        public void SaveSetting<T>(T setting) where T : Setting
        {
            var settingsFile = Path.Combine(this.settingPath, typeof(T).FullName + "." + SettingFileExtension);
            using (var fileStream = new FileStream(settingsFile, FileMode.Create, FileAccess.Write))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(fileStream, setting);
            }
        }
    }
}
