namespace LayerMap.Tiles {
    class Grass : Tile {
        public override bool ProvidesResources {
            get {
                return false;
            }
        }

        public override TileTypes TileType {
            get {
                return TileTypes.Grass;
            }
        }

        protected override float BaseDurability {
            get {
                return 10.0f;
            }
        }

        protected override StructureTypes BaseStructureType {
            get {
                return StructureTypes.Floor;
            }
        }
    }
}
