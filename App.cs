using CoreEngine;
using Engine;

namespace App {
    class App {
        private static void Main(string[] args){

            MainProcess.Init();

            

            // List<Behaviour> behavioursList = new List<Behaviour>();
            // int behaviourCount = behavioursList.Count;
            // int behaviourIterator = 0;

            while(!MainProcess.windowShouldClose()){

                OpenGL.GL.glClearColor(0.18f, 0.18f, 0.18f, 1f);
                OpenGL.GL.glClear(OpenGL.GL.GL_COLOR_BUFFER_BIT | OpenGL.GL.GL_DEPTH_BUFFER_BIT);

                

                GLFW.Glfw.PollEvents();
                GLFW.Glfw.SwapBuffers(MainProcess.window);
            }

        }

    }
}