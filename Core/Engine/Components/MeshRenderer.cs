using Engine;

namespace CoreEngine {
    class MeshRenderer : RenderComponent{
        public Transform parentTransform = new Transform();
        public RenderMesh mesh = new RenderMesh();
        public Material material = new Material();

        public void AttachComponent(GameObject parent){
            parentTransform = parent.transform;
        }

        public void RenderUpdate(){

        }
    }
}