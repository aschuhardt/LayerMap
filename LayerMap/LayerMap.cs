using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LayerMap.Layers;

namespace LayerMap {
    /// <summary>
    /// A collection of Layer objects accessible by an index.
    /// </summary>
    public class LayerMap {
        private Configuration _mapConfig;

        public const int SURFACE_LEVEL = 0;

        public int Width { get; private set; }
        public int Height { get; private set; }

        private IDictionary<uint, Layer> _layers;

        public LayerMap(int width, int height, Configuration config)
            : this(width, height, false) {
            _mapConfig = config ?? Configuration.Load(Configuration.DEFAULT_SERIALIZATION_FILENAME);
        }

        public LayerMap(int width, int height, string configFilePath)
            : this(width, height, false) {
            _mapConfig = Configuration.Load(configFilePath);
        }

        public LayerMap(int width, int height, bool loadDefault = true) {
            Width = width;
            Height = height;
            if (loadDefault) _mapConfig = Configuration.Load(Configuration.DEFAULT_SERIALIZATION_FILENAME);
            _layers = new Dictionary<uint, Layer>();
        }

        /// <summary>
        /// Returns the Layer at the specified level.
        /// </summary>
        public Layer this[uint i] {
            get {
                if (!_layers.ContainsKey(i)) _layers[i] = MapLevelToLayerType(i);
                return _layers[i];
            }
        }

        private Layer MapLevelToLayerType(uint level) {
            //eventually this might be used to create different types of layers based on their level
            //for now though we will just return a basic dummy layer
            if (level == SURFACE_LEVEL) {
                return new Surface(Width, Height, _mapConfig);
            } else {
                return new SimpleUnderground(Width, Height, _mapConfig);
            }
        }
    }
}
