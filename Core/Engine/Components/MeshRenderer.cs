using Engine;

namespace CoreEngine {
    class MeshRenderer : Component{
        public Transform transform = new Transform();
        public RenderMesh mesh = new RenderMesh();
        public Material material = new Material();

        public void Attach(in GameObject parent){
            transform = parent.transform;
        }

        public void RenderUpdate(){

        }
    }
}