namespace Engine {
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
        // [Obsolete] Edytor musi to zrobić
        // public ColorRGB(int red, int green, int blue){
        //     r = red / 255;
        //     g = green / 255;
        //     b = blue / 255;
        // }
    }
}