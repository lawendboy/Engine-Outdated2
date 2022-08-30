using CoreEngine;

namespace Engine {
    class Camera : Component {
        public Matrix4f GetViewMatrix(){
            Vector3 rot = Quaternion.ToEulerAngles(transform.rotation);
            return ( ( Matrix4f.rotationMatrixAroundX(rot.x) * Matrix4f.rotationMatrixAroundY(rot.y)) * Matrix4f.rotationMatrixAroundZ(rot.y) ) * Matrix4f.translationMatrix(transform.position);
        }
    }
}