using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayerMap {
    public abstract class Tile {
        public enum TileTypes {
            Grass,
            Dirt,
            Stone,
            Ore,
            Crystal
        }

        public enum StructureTypes {
            Floor,
            Wall,
            Hole
        }

        public abstract TileTypes TileType { get; }
        public abstract bool ProvidesResources { get; }
        public StructureTypes StructureType { get; private set; }

        /// <summary>
        /// Call this to instantly break the tile.
        /// </summary>
        public void InstaBreak() {
            Damage(_currentDurability);
        }

        public void Damage(float damageAmount) {
            if (StructureType == StructureTypes.Wall) {         //if the damage is being done to a wall...
                if (damageAmount >= _currentDurability) {
                    StructureType = StructureTypes.Floor;       //either it breaks and it becomes a floor,
                    _currentDurability = BaseDurability;
                } else {
                    _currentDurability -= damageAmount;         //or it takes damage.
                }
            } else if (StructureType == StructureTypes.Floor) { //otherwise, if we're damaging a floor tile...
                if (damageAmount >= _currentDurability) {
                    StructureType = StructureTypes.Hole;        //either it breaks and becomes a hole,
                } else {
                    _currentDurability -= damageAmount;         //or it takes damage and comes closer to becoming a hole.
                }
            }
        }

        internal Tile() {
            _currentDurability = BaseDurability;
            StructureType = BaseStructureType;
        }

        protected abstract float BaseDurability { get; }
        protected abstract StructureTypes BaseStructureType { get; }
        protected float _currentDurability;

    }
}
