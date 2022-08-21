namespace CoreEngine {
    public struct ColorRGBA {
        private float[] values = new float[4];

        public float r { get { return values[0]; } set { values[0] = value; }}
        public float g { get { return values[1]; } set { values[1] = value; }}
        public float b { get { return values[2]; } set { values[2] = value; }}
        public float a { get { return values[3]; } set { values[3] = value; }}

        public ColorRGBA(float red, float green, float blue, float alpha) {
            r = red;
            g = green;
            b = blue;
            a = alpha;
        }
        public ColorRGBA(){
            r = 0; 
            b = 0;
            g = 0;
            a = 0;
        }

        public static implicit operator ColorRGB(ColorRGBA col) => new ColorRGB(col.r, col.g, col.b);
        // [Obsolete] Edytor musi to zrobić
        // public ColorRGBA(int red, int green, int blue, int alpha){
        //     r = red / 255;
        //     g = green / 255;
        //     b = blue / 255;
        //     a = alpha / 100;???
        // }
    }
}