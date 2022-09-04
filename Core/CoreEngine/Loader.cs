using Engine;
using static OpenGL.GL;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
namespace CoreEngine {
    static class Loader {
        public static RenderMesh LoadMeshFloatArray(float[] vertices){

            uint VAO, VBO;
            VAO = glGenVertexArray();
            VBO = glGenBuffer();

            glBindVertexArray(VAO);
            glBindBuffer(GL_ARRAY_BUFFER, VBO);

        unsafe{            
            fixed(float* data = &vertices[0]){
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, data, GL_STATIC_DRAW);
            }

            glEnableVertexAttribArray(0);
            glVertexAttribPointer(0, 3, GL_FLOAT, false, 8 * sizeof(float), (void*)0);
            glEnableVertexAttribArray(1);
            glVertexAttribPointer(1, 3, GL_FLOAT, false, 8 * sizeof(float), (void*)(3 * sizeof(float)));
            glEnableVertexAttribArray(2);
            glVertexAttribPointer(2, 2, GL_FLOAT, false, 8 * sizeof(float), (void*)(6 * sizeof(float)));
            glBindVertexArray(0);

        }

            return new RenderMesh(VAO, (uint)vertices.Length / 8, VBO);
        }
    }
}