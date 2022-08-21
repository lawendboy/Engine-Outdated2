using CoreEngine;

namespace Engine {
    public struct Vector2 {

        public float[] values = new float[2];

        public Vector2(float x, float y){
            values[0] = x;
            values[1] = y;
        }

        public Vector2(){
            values[0] = 0;
            values[1] = 0;
        }

        public float x {get {return values[0];} set {values[0] = value;}}
        public float y {get {return values[1];} set {values[1] = value;}}

        public float length { get { return MathF.Sqrt(x * x + y * y); } }

        public Vector2 normalized { get {float len = 1.0f / length; return new Vector2(x * len, y * len); }}

        public float[] glVal { get { return values; } }

        public void Normalize() {
            values = normalized.values;
        }

        public static Vector2 operator + (Vector2 left, Vector2 right){
            return new Vector2(left.x + right.x, left.y + right.y);
        }

        public static implicit operator Vector3(Vector2 vec) => new Vector3(vec.x, vec.y, 0.0f);
        public static implicit operator Vector4(Vector2 vec) => new Vector4(vec.x, vec.y, 0.0f, 0.0f);
    }
}