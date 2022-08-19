//#define WINDOWS
#define APPLE
//#define UNIX moze dodam

using System;
using static OpenGL.GL;
using GLFW;
using Engine;

namespace CoreEngine {

    static class MainProcess {

        public static GLFW.Window window;

        public static int width = 600;
        public static int height = 800;

        public static string title = "Title";

        public static void Init() {
            
            Glfw.WindowHint(Hint.ClientApi, ClientApi.OpenGL);
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
        #if APPLE
            Glfw.WindowHint(Hint.OpenglForwardCompatible, true);
        #endif
            Glfw.WindowHint(Hint.Doublebuffer, true);
            Glfw.WindowHint(Hint.Decorated, true);

            window = Glfw.CreateWindow(width, height, title, GLFW.Monitor.None, Window.None);

            Glfw.MakeContextCurrent(window);

            Import(Glfw.GetProcAddress); 

            Glfw.SetWindowSizeCallback(window, sizeCallabck);

        }

        //Callbacks

        private static void sizeCallabck(Window window, int width, int height){
            MainProcess.width = width;
            MainProcess.height = height;
            glViewport(0, 0, width, height);
        }

        public static bool windowShouldClose(){
            return Glfw.WindowShouldClose(window);
        }

    }

}