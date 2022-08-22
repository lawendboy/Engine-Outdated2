using Engine;
using static OpenGL.GL;
using System.Drawing;
using System.Drawing.Imaging;
namespace CoreEngine {
    static class Loader {
        public static Texture LoadTexture(string path){
            Bitmap bitmap = new Bitmap(path);
            uint id = glGenTexture();
            
            BitmapData data = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb
            );

            glBindTexture(GL_TEXTURE_2D, id);
            glTexImage2D(
                GL_TEXTURE_2D,
                0,
                GL_RGBA,
                bitmap.Width,
                bitmap.Height,
                0,
                GL_BGRA,
                GL_UNSIGNED_BYTE,
                data.Scan0
            );

            bitmap.UnlockBits(data);

            glGenerateMipmap(GL_TEXTURE_2D);

            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

            return new Texture(id);
        }
    }
}