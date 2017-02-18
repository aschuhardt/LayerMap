using System;
using System.IO;
using Newtonsoft.Json;

namespace LayerMap {
    public class Configuration {
        public const string DEFAULT_SERIALIZATION_FILENAME = "config/layer_map.json";
        public SurfaceLayerSettings Surface { get; set; }
        public UndergroundLayerSettings Underground { get; set; }

        public static Configuration Load(string filename) {
            Configuration output;

            using (StreamReader sr = new StreamReader(File.OpenRead(filename))) {
                try {
                    string json = sr.ReadToEnd();
                    output = JsonConvert.DeserializeObject<Configuration>(json);
                } catch (IOException) {
                    Console.WriteLine($"{DateTime.Now.ToString()}: Could not read configuration file at {filename}...  Falling back on default configuration options.");
                    Console.WriteLine($"{DateTime.Now.ToString()}: Saving a copy of the default config options to prevent this from happening again...");
                    Configuration config = new Configuration();
                    config.Save(DEFAULT_SERIALIZATION_FILENAME);
                    return config;
                }
            }

            return output;
        }

        public Configuration() {
            Surface = new SurfaceLayerSettings();
            Underground = new UndergroundLayerSettings();

            Surface.GrassCoverage = 0.5f;
            Surface.GrassScale = 1.0f;
            Underground.StoneCoverage = 0.35f;
            Underground.StoneScale = 1.3f;
            Underground.OreCoverage = 0.2f;
            Underground.OreScale = 2.4f;
            Underground.TunnelCoverage = 0.35f;
            Underground.TunnelScale = 0.9f;            
        }

        public void Save(string filename) {
            string directory = Path.GetDirectoryName(filename);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            using (StreamWriter sw = File.CreateText(filename)) {
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                sw.WriteLine(json);
            }
        }

        public class SurfaceLayerSettings {
            public float GrassCoverage { get; set; }
            public float GrassScale { get; set; }
        }

        public class UndergroundLayerSettings {
            public float TunnelCoverage { get; set; }
            public float TunnelScale { get; set; }
            public float StoneCoverage { get; set; }
            public float StoneScale { get; set; }
            public float OreCoverage { get; set; }
            public float OreScale { get; set; }
        }
    }

}
