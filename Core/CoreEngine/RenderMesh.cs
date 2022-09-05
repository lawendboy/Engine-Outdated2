namespace CoreEngine {
    struct RenderMesh {
        public uint id;
        public int vertices;
        public uint vbo;
        public RenderMesh(uint id, int vertices, uint vbo){
            this.id = id;
            this.vertices = vertices;
            this.vbo = vbo;
        }
        public RenderMesh(){
            this.id = 0;
            this.vertices = 0;
            this.vbo = 0;
        }
    }
}