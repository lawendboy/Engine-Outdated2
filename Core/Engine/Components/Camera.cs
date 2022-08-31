using CoreEngine;

namespace Engine {
    class Camera : Component {
        public override void Update(){
            Vector3 rot = Quaternion.ToEulerAngles(transform.rotation);
            CoreEngine.MainProcess.viewMatrix = ( ( Matrix4f.rotationMatrixAroundX(rot.x) * Matrix4f.rotationMatrixAroundY(rot.y)) * Matrix4f.rotationMatrixAroundZ(rot.y) ) * Matrix4f.translationMatrix(transform.position);
        }
    }
}