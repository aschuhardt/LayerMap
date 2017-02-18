using LayerMap.Tiles;
using LayerMap.Utility;
using System.Collections.Generic;

namespace LayerMap.Layers {
    internal class Surface : Layer {
                
        public Surface(int width, int height, Configuration config)
            : base(width, height, config) {
        }

        public override float AmbientTemperature {
            get {
                return 60.0f;
            }
        }

        protected override Tile[,] GenerateFeatures(int width, int height, Configuration config) {
            Tile[,] output = new Tile[width, height];
            
            List<Tile[,]> featureLayers = new List<Tile[,]>();

            featureLayers.Add(LandscapeGenerator.CreateTileDistribution<DirtFloor>(width, height, 1, 1));
            featureLayers.Add(LandscapeGenerator.CreateTileDistribution<Grass>(width, height, config.Surface.GrassScale, config.Surface.GrassCoverage));

            return output;
        }
    }
}
