using LibNoise.Primitive;
using LibNoise.Filter;

namespace LayerMap.Layers {
    internal class Surface : Layer {
        private const float GRASS_COVERAGE = 0.5f;
        
        public Surface(int width, int height)
            : base(width, height) {
        }

        public override float AmbientTemperature {
            get {
                return 60.0f;
            }
        }

        protected override Tile[,] GenerateFeatures(int width, int height) {
            Tile[,] output = new Tile[width, height];
            ImprovedPerlin perlin = new ImprovedPerlin();
            MultiFractal mf = new MultiFractal();

            mf.Primitive2D = perlin;
            mf.Primitive3D = perlin;

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    float val = mf.GetValue(x, y);
                    if (val > GRASS_COVERAGE) {
                        output[x, y] = new Tiles.Grass();
                    } else {
                        output[x, y] = new Tiles.DirtFloor();
                    }
                }
            }

            return output;
        }
    }
}
