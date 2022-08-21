namespace Engine {
    struct Quaternion {
        private float[] values = new float[4];
        public Quaternion(float x, float y, float z, float w){
            values[0] = x;
            values[1] = y;
            values[2] = z;
            values[3] = w;
        }

        public static Quaternion identity = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);

        public float x {get {return values[0];} set {values[0] = value;}}
        public float y {get {return values[1];} set {values[1] = value;}}
        public float z {get {return values[2];} set {values[2] = value;}}
        public float w {get {return values[3];} set {values[3] = value;}}

        private float norm => MathF.Sqrt(values[0] * values[0] + values[1] * values[1] + values[2] * values[2] + values[3] * values[3]);
        
        private void normalize(){
            var invLen = 1.0f / norm;
            values[0] *= invLen;
            values[1] *= invLen;
            values[2] *= invLen;
            values[3] *= invLen;
        }

        public static Quaternion eulerAngles(float x, float y, float z){ //yaw (Z), pitch (Y), roll (X)
            float cy = MathF.Cos(z * 0.5f);
            float sy = MathF.Sin(z * 0.5f);
            float cp = MathF.Cos(y * 0.5f);
            float sp = MathF.Sin(y * 0.5f);
            float cr = MathF.Cos(x * 0.5f);
            float sr = MathF.Sin(x * 0.5f);

            
            return new Quaternion(
                sr * cp * cy + cr * sp * sy,
                cr * sp * cy - sr * cp * sy, 
                cr * cp * sy + sr * sp * cy, 
                cr * cp * cy - sr * sp * sy
            );
        }

        public static Quaternion eulerAngles(Vector3 eulerAngles){ //yaw (Z), pitch (Y), roll (X)
            float cy = MathF.Cos(eulerAngles.z * 0.5f);
            float sy = MathF.Sin(eulerAngles.z * 0.5f);
            float cp = MathF.Cos(eulerAngles.y * 0.5f);
            float sp = MathF.Sin(eulerAngles.y * 0.5f);
            float cr = MathF.Cos(eulerAngles.x * 0.5f);
            float sr = MathF.Sin(eulerAngles.x * 0.5f);

            
            return new Quaternion(
                sr * cp * cy + cr * sp * sy,
                cr * sp * cy - sr * cp * sy, 
                cr * cp * sy + sr * sp * cy, 
                cr * cp * cy - sr * sp * sy
            );
        }

        public static Vector3 ToEulerAngles(Quaternion q) {
            Vector3 angles = new Vector3();

            // roll (x-axis rotation)
            float sinr_cosp = 2 * (q.w * q.x - q.y * q.z);
            float cosr_cosp = 1 - 2 * (q.x * q.x + q.y * q.y);
            angles.x = MathF.Atan2(sinr_cosp, cosr_cosp);

            // pitch (y-axis rotation)
            float sinp = 2 * (q.w * q.y + q.z * q.x);
            if (MathF.Abs(sinp) >= 1)
                angles.y = MathF.CopySign(MathF.PI / 2, sinp); // use 90 degrees if out of range
            else
                angles.y = MathF.Asin(sinp);

            // yaw (z-axis rotation)
            float siny_cosp = 2 * (q.w * q.z - q.x * q.y);
            float cosy_cosp = 1 - 2 * (q.y * q.y + q.z * q.z);
            angles.z = MathF.Atan2(siny_cosp, cosy_cosp);

            return angles;
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