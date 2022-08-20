namespace Engine {
    struct Quaternion {
        private float[] values = new float[4];
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

        private float norm => MathF.Sqrt(values[0] * values[0] + values[1] * values[1] + values[2] * values[2] + values[3] * values[3]);
        
        private void normalize(){
            var invLen = 1 / norm;
            values[0] *= invLen;
            values[1] *= invLen;
            values[2] *= invLen;
            values[3] *= invLen;
        }

        public static Quaternion eulerAngles(){
            return new Quaternion(); // DO ZROBIENIA
        }

        public static Quaternion operator + (Quaternion left, Quaternion right){
            return new Quaternion(left.x + right.x, left.y + right.y, left.z + right.z, left.w + right.w);
        }
        
        public static Quaternion operator * (Quaternion left, Quaternion right){
            Quaternion output = new Quaternion(
                left.w * right.x + left.x * right.w + left.y * right.z - left.z * right.y, //x
                left.w * right.y - left.x * right.z + left.y * right.w + left.z * right.x,
                left.w * right.z + left.x * right.y - left.y * right.x + left.z * right.w,
                left.w * right.w - left.x * right.x - left.y * right.y - left.z * right.z //w
            );
            output.normalize();
            return output;
        }

        public static Quaternion multiplyWithoutNormalization(Quaternion left, Quaternion right){
            return new Quaternion(
                left.w * right.x + left.x * right.w + left.y * right.z - left.z * right.y, //x
                left.w * right.y - left.x * right.z + left.y * right.w + left.z * right.x,
                left.w * right.z + left.x * right.y - left.y * right.x + left.z * right.w,
                left.w * right.w - left.x * right.x - left.y * right.y - left.z * right.z //w
            );
        }
    }
}