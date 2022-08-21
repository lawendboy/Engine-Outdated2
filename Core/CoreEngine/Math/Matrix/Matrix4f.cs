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

        public static Matrix4f rotationMatrix(Quaternion quat) => new Matrix4f(new float[]{
            1-2*quat.y*quat.y-2*quat.z*quat.z, 2*quat.x*quat.y - 2*quat.w*quat.z, 2*quat.x*quat.z + 2*quat.w*quat.y, 0,
            2*quat.x*quat.y + 2*quat.w*quat.z, 1-2*quat.x*quat.x-2*quat.z*quat.z, 2*quat.y*quat.z-2*quat.w*quat.x, 0,
            2*quat.x*quat.z-2*quat.w*quat.y, 2*quat.y*quat.z+2*quat.w*quat.x, 1-2*quat.x*quat.x-2*quat.y*quat.y, 0,
            0, 0, 0, 1
        });

        public static Matrix4f rotationMatrixAroundX(float angle) => new Matrix4f(new float[]{
            1, 0, 0, 0,
            0, MathF.Cos(angle), -MathF.Sin(angle), 0,
            0, MathF.Sin(angle), MathF.Cos(angle), 0,
            0, 0, 0, 1
        });

        public static Matrix4f rotationMatrixAroundY(float angle) => new Matrix4f(new float[]{
            MathF.Cos(angle), 0, MathF.Sin(angle), 0,
            0, 1, 0, 0,
            -MathF.Sin(angle), 0, MathF.Cos(angle), 0,
            0, 0, 0, 1
        });

        public static Matrix4f rotationMatrixAroundZ(float angle) => new Matrix4f(new float[]{
            MathF.Cos(angle), -MathF.Sin(angle), 0, 0,
            MathF.Sin(angle), MathF.Cos(angle), 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1
        });

        public static Matrix4f projection(float fieldOfView, float aspect, float zNear, float zFar){
            float[] output = new float[16];
            
            float scale = 1 / MathF.Tan(fieldOfView * 0.5f * MathF.PI / 180); 
            output[0] = scale;
            output[5] = scale;
            output[10] = zFar / (zFar - zNear);
            output[11] = -zFar * zNear / (zFar - zNear);
            output[14] = -1;
            output[15] = 0;

            return new Matrix4f(output);
        }


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

        public static Matrix4f operator + (Matrix4f left, Matrix4f right){
            float[] output = new float[16];
            output[0] = left.values[0] + right.values[0];
            output[1] = left.values[1] + right.values[1];
            output[2] = left.values[2] + right.values[2];
            output[3] = left.values[3] + right.values[3];
            output[4] = left.values[4] + right.values[4];
            output[5] = left.values[5] + right.values[5];
            output[6] = left.values[6] + right.values[6];
            output[7] = left.values[7] + right.values[7];
            output[8] = left.values[8] + right.values[8];
            output[9] = left.values[9] + right.values[9];
            output[10] = left.values[10] + right.values[10];
            output[11] = left.values[11] + right.values[11];
            output[12] = left.values[12] + right.values[12];
            output[13] = left.values[13] + right.values[13];
            output[14] = left.values[14] + right.values[14];
            output[15] = left.values[15] + right.values[15];
            return new Matrix4f(output);
        }

        public static Matrix4f operator * (Matrix4f left, float right){
            float[] output = new float[16];
            output[0] = left.values[0] * right;
            output[1] = left.values[1] * right;
            output[2] = left.values[2] * right;
            output[3] = left.values[3] * right;
            output[4] = left.values[4] * right;
            output[5] = left.values[5] * right;
            output[6] = left.values[6] * right;
            output[7] = left.values[7] * right;
            output[8] = left.values[8] * right;
            output[9] = left.values[9] * right;
            output[10] = left.values[10] * right;
            output[11] = left.values[11] * right;
            output[12] = left.values[12] * right;
            output[13] = left.values[13] * right;
            output[14] = left.values[14] * right;
            output[15] = left.values[15] * right;
            return new Matrix4f(output);
        }

        public static Matrix4f operator * (float left, Matrix4f right){
            float[] output = new float[16];
            output[0] = right.values[0] * left;
            output[1] = right.values[1] * left;
            output[2] = right.values[2] * left;
            output[3] = right.values[3] * left;
            output[4] = right.values[4] * left;
            output[5] = right.values[5] * left;
            output[6] = right.values[6] * left;
            output[7] = right.values[7] * left;
            output[8] = right.values[8] * left;
            output[9] = right.values[9] * left;
            output[10] = right.values[10] * left;
            output[11] = right.values[11] * left;
            output[12] = right.values[12] * left;
            output[13] = right.values[13] * left;
            output[14] = right.values[14] * left;
            output[15] = right.values[15] * left;
            return new Matrix4f(output);
        }
    }
}