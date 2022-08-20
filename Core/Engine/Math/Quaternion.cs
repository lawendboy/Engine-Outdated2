namespace Engine {
    struct Quaternion {
        private float[] values = new float[3];
        public Quaternion(float x, float y, float z, float w){
            values[0] = x;
            values[1] = y;
            values[2] = z;
            values[3] = w;
        }
        public float x {get {return values[0];} set {values[0] = value;}}
        public float y {get {return values[1];} set {values[1] = value;}}
        public float z {get {return values[2];} set {values[2] = value;}}
        public float w {get {return values[3];} set {values[3] = value;}}

        private float length => MathF.Sqrt(values[0] * values[0] + values[1] * values[1] + values[2] * values[2] + values[3] * values[3]);
        
        private void normalize(){
            var invLen = 1 / length;
            values[0] *= invLen;
            values[1] *= invLen;
            values[2] *= invLen;
            values[3] *= invLen;
        }
    }
}