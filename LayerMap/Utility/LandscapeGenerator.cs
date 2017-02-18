using System;
using LibNoise.Primitive;
using LibNoise.Filter;
using LibNoise.Transformer;

namespace LayerMap.Utility {
    internal static class LandscapeGenerator {
        public static T[,] CreateTileDistribution<T>(int width, int height, float scale, float coverage) {
            T[,] output = new T[width, height];

            //generate noise
            ImprovedPerlin perlin = new ImprovedPerlin();
            MultiFractal fractal = new MultiFractal();
            fractal.Primitive2D = perlin;
            fractal.Primitive3D = perlin;

            //scale the noise
            ScalePoint scaledNoise = new ScalePoint(fractal, scale, scale, scale);

            //create output distribution map from scaled noise + coverage
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    float val = scaledNoise.GetValue(x, y, 0.1f);
                    if (val < coverage) {
                        output[x, y] = (T)Activator.CreateInstance(typeof(T));
                    }
                }
            }

            return output;
        }

        public static void ApplyDistributionToTileArray(Tile[,] targetMap, Tile[,] sourceDistribution) {
            int targetWidth = targetMap.GetLength(0);
            int targetHeight = targetMap.GetLength(1);
            for (int x = 0; x < targetWidth; x++) {
                for (int y = 0; y < targetHeight; y++) {
                    if (sourceDistribution[x,y] != null) {
                        targetMap[x, y] = sourceDistribution[x, y];
                    }
                }
            }
        }
    }
}
