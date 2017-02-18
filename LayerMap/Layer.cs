using System;

namespace LayerMap {
    public abstract class Layer {

        #region Object
        public sealed override int GetHashCode() {
            return ID.GetHashCode();
        }

        public sealed override bool Equals(object obj) {
            if (obj.GetType() == typeof(Guid)) {
                return ((Layer)obj).ID.Equals(ID);
            } else {
                return false;
            }
        }
        #endregion

        private Tile[,] _tiles;

        public Guid ID { get; private set; }

        public abstract float AmbientTemperature { get; }

        public Tile this[int x, int y] {
            get {
                return _tiles[x, y];
            }
        }

        protected Layer(int width, int height) {
            ID = Guid.NewGuid();
            _tiles = GenerateFeatures(width, height);
        }

        protected abstract Tile[,] GenerateFeatures(int width, int height);

    }
}
