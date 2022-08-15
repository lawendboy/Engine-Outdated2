namespace Engine {
    public struct Vector3 {
        
        private float[] values = new float[3];
        
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

        public Vector3 normalized { get {float len = length; return new Vector3(x / len, y / len, z / len); }}

        public float[] glVal { get { return values; } }

        public void Normalize() {
            values = normalized.values;
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
    }
}