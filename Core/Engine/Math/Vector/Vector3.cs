namespace Engine {
    public struct Vector3 {
        
        public readonly float[] values = new float[3];
        
        public Vector3(float x, float y, float z){
            values[0] = x;
            values[1] = y;
            values[2] = z;
        }

        public Vector3(){
            values[0] = 0;
            values[1] = 0;
            values[2] = 0;
        }

        public float x {get {return values[0];} set {values[0] = value;}}
        public float y {get {return values[1];} set {values[1] = value;}}
        public float z {get {return values[2];} set {values[2] = value;}}

        public float length { get { return MathF.Sqrt(x * x + y * y + z * z); } }

        public Vector3 normalized { get {float len = 1.0f / length; return new Vector3(x * len, y * len, z * len); }}

        public float[] glVal { get { return values; } }

        public void Normalize() {
            values[0] = normalized.values[0];
            values[1] = normalized.values[1];
            values[2] = normalized.values[2];
        }

        public static Vector3 crossProduct(Vector3 left, Vector3 right){
            Vector3 temp = new Vector3();
            temp.x = left.y * right.z - left.z * right.y;
            temp.y = -(left.x * right.z - left.z * right.x);
            temp.z = left.x * right.y - left.y * right.x;
            return temp;
        }
        public static float dotProduct(Vector3 left, Vector3 right){
            return left.x * right.x + left.y * right.y + left.z * right.z;
        }

        public static Vector3 operator * (Vector3 left, float right){
            return new Vector3(left.x * right, left.y * right, left.z * right);
        }

        public static Vector3 operator * (float left, Vector3 right){
            return new Vector3(right.x * left, right.y * left, right.z * left);
        }

        public static Vector3 operator + (Vector3 left, Vector3 right){
            return new Vector3(left.x + right.x, left.y + right.y, left.z + right.z);
        }

        public static implicit operator Vector4(Vector3 vec) => new Vector4(vec.x, vec.y, vec.z, 0.0f);

        public static implicit operator Vector2(Vector3 vec) => new Vector2(vec.x, vec.y);
    }
}