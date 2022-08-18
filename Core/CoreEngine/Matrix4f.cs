using Engine;

namespace CoreEngine {
    struct Matrix4f {
        public readonly float[] values = new float[16];
        
        public Matrix4f(){ }

        public static Matrix4f identity = new Matrix4f(new float[]{
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1
        });

        public Matrix4f(float[] values){
            this.values = values;
        }

        public static Matrix4f translationMatrix(Vector3 vector) => new Matrix4f(new float[]{
            1, 0, 0, vector.x,
            0, 1, 0, vector.y,
            0, 0, 1, vector.z,
            0, 0, 0, 1
        });

        public static Matrix4f scalarMatrix(Vector3 vector) => new Matrix4f(new float[]{
            vector.x, 0, 0, 0,
            0, vector.y, 0, 0,
            0, 0, vector.z, 0,
            0, 0, 0, 1
        });

        public static Matrix4f operator * (Matrix4f left, Matrix4f right){
            float[] output = new float[16];
            output[0] = left.values[0] * right.values[0] + left.values[1] * right.values[4] + left.values[2] * right.values[8] + left.values[3] * right.values[12];
            output[1] = left.values[0] * right.values[1] + left.values[1] * right.values[5] + left.values[2] * right.values[9] + left.values[3] * right.values[13];
            output[2] = left.values[0] * right.values[2] + left.values[1] * right.values[6] + left.values[2] * right.values[10] + left.values[3] * right.values[14];
            output[3] = left.values[0] * right.values[3] + left.values[1] * right.values[7] + left.values[2] * right.values[11] + left.values[3] * right.values[15];
            output[4] = left.values[4] * right.values[0] + left.values[5] * right.values[4] + left.values[6] * right.values[8] + left.values[7] * right.values[12];
            output[5] = left.values[4] * right.values[1] + left.values[5] * right.values[5] + left.values[6] * right.values[9] + left.values[7] * right.values[13];
            output[6] = left.values[4] * right.values[2] + left.values[5] * right.values[6] + left.values[6] * right.values[10] + left.values[7] * right.values[14];
            output[7] = left.values[4] * right.values[3] + left.values[5] * right.values[7] + left.values[6] * right.values[11] + left.values[7] * right.values[15];
            output[8] = left.values[8] * right.values[0] + left.values[9] * right.values[4] + left.values[10] * right.values[8] + left.values[11] * right.values[12];
            output[9] = left.values[8] * right.values[1] + left.values[9] * right.values[5] + left.values[10] * right.values[9] + left.values[11] * right.values[13];
            output[10] = left.values[8] * right.values[2] + left.values[9] * right.values[6] + left.values[10] * right.values[10] + left.values[11] * right.values[14];
            output[11] = left.values[8] * right.values[3] + left.values[9] * right.values[7] + left.values[10] * right.values[11] + left.values[11] * right.values[15];
            output[12] = left.values[12] * right.values[0] + left.values[13] * right.values[4] + left.values[14] * right.values[8] + left.values[15] * right.values[12];
            output[13] = left.values[12] * right.values[1] + left.values[13] * right.values[5] + left.values[14] * right.values[9] + left.values[15] * right.values[13];
            output[14] = left.values[12] * right.values[2] + left.values[13] * right.values[6] + left.values[14] * right.values[10] + left.values[15] * right.values[14];
            output[15] = left.values[12] * right.values[3] + left.values[13] * right.values[7] + left.values[14] * right.values[11] + left.values[15] * right.values[15];
            return new Matrix4f(output);
        }

        public static Vector4 operator * (Matrix4f left, Vector4 right){
            return new Vector4(left.values[0] * right.x + left.values[1] * right.y + left.values[2] * right.z + left.values[3] * right.w,
                               left.values[4] * right.x + left.values[5] * right.y + left.values[6] * right.z + left.values[7] * right.w,
                               left.values[8] * right.x + left.values[9] * right.y + left.values[10] * right.z + left.values[11] * right.w,
                               left.values[12] * right.x + left.values[13] * right.y + left.values[14] * right.z + left.values[15] * right.w);
        }
    }
}