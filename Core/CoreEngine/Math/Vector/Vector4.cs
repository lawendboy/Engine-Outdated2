namespace CoreEngine {
    public struct Vector4 {
        
        private float[] values = new float[4];
        
        public Vector4(float x, float y, float z, float w){
            values[0] = x;
            values[1] = y;
            values[2] = z;
            values[3] = w;
        }

        public Vector4(){
            values[0] = 0;
            values[1] = 0;
            values[2] = 0;
            values[3] = 0;
        }

        public float x { get { return values[0]; } set { values[0] = value; } }
        public float y { get { return values[1]; } set { values[1] = value; } }
        public float z { get { return values[2]; } set { values[2] = value; } }
        public float w { get { return values[3]; } set { values[3] = value; } }

        public float length { get { return MathF.Sqrt(x * x + y * y + z * z + w * w); } }

        public Vector4 normalized { get {float len = length; return new Vector4(x / len, y / len, z / len, w / len); }}

        public float[] glVal { get { return values; } }

        public void Normalize() {
            values = normalized.values;
        }

        public static Vector4 operator * (Vector4 left, float right){
            return new Vector4(left.x * right, left.y * right, left.z * right, left.w * right );
        }
        public static Vector4 operator * (float left, Vector4 right){
            return new Vector4(right.x * left, right.y * left, right.z * left, right.w * left );
        }

    }
}