namespace CoreEngine {
    public struct ColorRGB {
        private float[] values = new float[3];

        public float r { get { return values[0]; } set { values[0] = value; } }
        public float g { get { return values[1]; } set { values[1] = value; } }
        public float b { get { return values[2]; } set { values[2] = value; } }

        public ColorRGB(float red, float green, float blue) {
            r = red;
            g = green;
            b = blue;
        }
        public ColorRGB(){
            r = 0; 
            b = 0;
            g = 0;
        }

        public void clmap(){
            values[0] = Math.Clamp(values[0], 0f, 1f);
            values[1] = Math.Clamp(values[1], 0f, 1f);
            values[2] = Math.Clamp(values[2], 0f, 1f);
        }

        public static ColorRGB operator * (ColorRGB left, ColorRGB right){
            ColorRGB output = new ColorRGB(left.r * right.r, left.g * right.g, left.b * right.b);
            return output;
        }

        public static implicit operator ColorRGBA(ColorRGB col) => new ColorRGBA(col.r, col.g, col.b, 1.0f);
        // [Obsolete] Edytor musi to zrobić
        // public ColorRGB(int red, int green, int blue){
        //     r = red / 255;
        //     g = green / 255;
        //     b = blue / 255;
        // }
    }
}