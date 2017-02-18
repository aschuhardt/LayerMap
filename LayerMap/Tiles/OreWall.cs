namespace LayerMap.Tiles {
    class OreWall : Tile {
        public override bool ProvidesResources {
            get {
                return false;
            }
        }

        public override TileTypes TileType {
            get {
                return TileTypes.Ore;
            }
        }

        protected override float BaseDurability {
            get {
                return 65.0f;
            }
        }

        protected override StructureTypes BaseStructureType {
            get {
                return StructureTypes.Wall;
            }
        }
    }
}
