namespace CoreEngine {
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

        public Vector2 normalized { get {float len = length; return new Vector2(x / len, y / len); }}

        public float[] glVal { get { return values; } }

        public void Normalize() {
            values = normalized.values;
        }
    }
}