//#define WINDOWS
#define APPLE
//#define UNIX moze dodam

using System;
using static OpenGL.GL;
using GLFW;
using Engine;

namespace CoreEngine {

    class MainProcess {

        private GLFW.Window window;

        public int width;
        public int height;

        public string title = "";

        public void Init() {
            
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

        }

    }

}