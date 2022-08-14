using System;

namespace CoreEngine {
    public struct Matrix4f {
        public float[] values = new float[16];
        
        public Matrix4f(){
            // values = new float[16];
        }

        public static Matrix4f operator *(Matrix4f left, float right){
            for(int i = 0; i < left.values.Length; i++){
                left.values[i] *= right;
            }
            return left;
        }

        public static Matrix4f operator *(float right, Matrix4f left){
            for(int i = 0; i < left.values.Length; i++){
                left.values[i] *= right;
            }
            return left;
        }
    }
}