namespace LayerMap.Tiles {
    class StoneWall : Tile {
        public override bool ProvidesResources {
            get {
                return false;
            }
        }

        public override TileTypes TileType {
            get {
                return TileTypes.Stone;
            }
        }

        protected override float BaseDurability {
            get {
                return 50.0f;
            }
        }

        protected override StructureTypes BaseStructureType {
            get {
                return StructureTypes.Wall;
            }
        }
    }
}
