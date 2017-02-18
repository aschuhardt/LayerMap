using LayerMap.Tiles;
using LayerMap.Utility;
using System.Collections.Generic;

namespace LayerMap.Layers {
    internal class SimpleUnderground : Layer {

        public SimpleUnderground(int width, int height, Configuration config)
            : base(width, height, config) {
        }

        public override float AmbientTemperature {
            get {
                return 40.0f;
            }
        }

        protected override Tile[,] GenerateFeatures(int width, int height, Configuration config) {
            Tile[,] output = new Tile[width, height];

            List<Tile[,]> featureLayers = new List<Tile[,]>();
            featureLayers.Add(LandscapeGenerator.CreateTileDistribution<DirtWall>(width, height, 1, 1));
            featureLayers.Add(LandscapeGenerator.CreateTileDistribution<DirtFloor>(width, height, config.Underground.TunnelScale, config.Underground.TunnelCoverage));
            featureLayers.Add(LandscapeGenerator.CreateTileDistribution<StoneWall>(width, height, config.Underground.StoneScale, config.Underground.StoneCoverage));
            featureLayers.Add(LandscapeGenerator.CreateTileDistribution<StoneWall>(width, height, config.Underground.StoneScale, config.Underground.StoneCoverage));
            featureLayers.Add(LandscapeGenerator.CreateTileDistribution<OreWall>(width, height, config.Underground.OreScale, config.Underground.OreCoverage));

            featureLayers.ForEach((f) => LandscapeGenerator.ApplyDistributionToTileArray(output, f));

            return output;
        }
    }
}
