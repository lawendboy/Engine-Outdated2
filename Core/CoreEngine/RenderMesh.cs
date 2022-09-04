namespace CoreEngine {
    struct RenderMesh {
        public uint id;
        public uint vertices;
        public uint vbo;
        public RenderMesh(uint id, uint vertices, uint vbo){
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