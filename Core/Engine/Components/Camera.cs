using CoreEngine;

namespace Engine {
    class Camera : Component {
        public override void Update(){
            Vector3 rot = Quaternion.ToEulerAngles(transform.rotation);
            CoreEngine.MainProcess.viewMatrix = Matrix4f.rotationMatrix(transform.rotation) * Matrix4f.translationMatrix(transform.position);
        }
    }
}