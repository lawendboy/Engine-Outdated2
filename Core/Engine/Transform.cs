using CoreEngine;

namespace Engine {
    class Transform {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        public Transform(){
            
        }

        public Vector3 forward => new Vector3(2 * (rotation.x * rotation.z + rotation.w * rotation.y), 2 * (rotation.y * rotation.z - rotation.w * rotation.x), -1 + 2 * (rotation.x * rotation.x + rotation.y * rotation.y));
        public Vector3 left => new Vector3(-1 + 2 * (rotation.y * rotation.y + rotation.z * rotation.z), -2 * (rotation.x * rotation.y + rotation.w * rotation.z), 2 * (rotation.x * rotation.z - rotation.w * rotation.y));
        public Vector3 up => new Vector3(-2 * (rotation.x * rotation.y - rotation.w * rotation.z), -1 + 2 * (rotation.x * rotation.x + rotation.z * rotation.z), 2 * (rotation.y * rotation.z + rotation.w * rotation.x));

        public Matrix4f GetModelMatrix(){
            return ( Matrix4f.scalarMatrix(scale) * Matrix4f.translationMatrix(position) ) * Matrix4f.rotationMatrix(rotation);
        }
    }
}