using LibNoise.Primitive;
using LibNoise.Filter;

namespace LayerMap.Layers {
    internal class SimpleUnderground : Layer {
        private const float DIRT_FLOOR_COVERAGE = 0.2f;
        private const float STONE_COVERAGE = 0.35f;

        public SimpleUnderground(int width, int height)
            : base(width, height) {
        }

        public override float AmbientTemperature {
            get {
                return 40.0f;
            }
        }

        protected override Tile[,] GenerateFeatures(int width, int height) {
            Tile[,] output = new Tile[width, height];

            //generate dirt
            ImprovedPerlin perlinDirt = new ImprovedPerlin();
            MultiFractal mfDirt = new MultiFractal();

            mfDirt.Primitive2D = perlinDirt;
            mfDirt.Primitive3D = perlinDirt;

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    float val = mfDirt.GetValue(x, y);
                    if (val > DIRT_FLOOR_COVERAGE) {
                        output[x, y] = new Tiles.DirtFloor();
                    } else {
                        output[x, y] = new Tiles.DirtWall();
                    }
                }
            }

            //generate stone
            ImprovedPerlin perlinStone = new ImprovedPerlin();
            MultiFractal mfStone = new MultiFractal();

            mfStone.Primitive2D = perlinStone;
            mfStone.Primitive3D = perlinStone;

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    float val = mfStone.GetValue(x, y);
                    if (val > DIRT_FLOOR_COVERAGE) {
                        output[x, y] = new Tiles.DirtFloor();
                    } else {
                        output[x, y] = new Tiles.DirtWall();
                    }
                }
            }

            return output;
        }
    }
}
