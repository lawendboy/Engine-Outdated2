using Engine;
using static OpenGL.GL;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
namespace CoreEngine {
    static class Loader {
        public static RenderMesh LoadMeshFloatArray(float[] vertices){
            var vao = glGenVertexArray();
            var vbo = glGenBuffer();

            glBindVertexArray(vao);

            glBindBuffer(GL_ARRAY_BUFFER, vbo);
            unsafe {
                fixed (float* v = &vertices[0])
                {
                    glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, v, GL_STATIC_DRAW);
                }
                glVertexAttribPointer(0, 3, GL_FLOAT, false, 8 * sizeof(float), (void*)0);
                glEnableVertexAttribArray(0);
                glVertexAttribPointer(1, 3, GL_FLOAT, false, 8 * sizeof(float), (void*)(3 * sizeof(float)));
                glEnableVertexAttribArray(1);
                glVertexAttribPointer(2, 2, GL_FLOAT, false, 8 * sizeof(float), (void*)(6 * sizeof(float)));
                glEnableVertexAttribArray(2);
            }
            return new RenderMesh(vao, 3, vbo);
        }
    }
}