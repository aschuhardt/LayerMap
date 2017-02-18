namespace LayerMap.Tiles {
    class CrystalWall : Tile {
        public override bool ProvidesResources {
            get {
                return false;
            }
        }

        public override TileTypes TileType {
            get {
                return TileTypes.Crystal;
            }
        }

        protected override float BaseDurability {
            get {
                return 85.0f;
            }
        }

        protected override StructureTypes BaseStructureType {
            get {
                return StructureTypes.Wall;
            }
        }
    }
}
