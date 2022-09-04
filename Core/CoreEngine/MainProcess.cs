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

        public static float fieldOfView = 60;

        public static List<Shader> shaders = new List<Shader>();
        public static int currentShader = -1;

        public static Matrix4f projectionMatrix;
        public static Matrix4f viewMatrix;

        private static Camera mainCamera = new Camera();

        public static List<GameObject> sceneGameobjects = new List<GameObject>();

        private static int counter1 = 0;
        private static int counter2 = 0;

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

            projectionMatrix = Matrix4f.projection(fieldOfView, width / (float) height, 0.1f, 1000.0f); 

            UpdateProjectionMatrixOnShaders();

        }

        public static void StartScene() {
            //Sekcja ładowania sceny
            //Ładowanie gameobjectow i ich komponentów
            
            //Attaching components;

            for(counter1 = 0; counter1 < sceneGameobjects.Count; counter1++){

                for(counter2 = 0; counter2 < sceneGameobjects[counter1].components.Count; counter2++){
                    sceneGameobjects[counter1].components[counter2].gameObject = sceneGameobjects[counter1];
                    sceneGameobjects[counter1].components[counter2].transform = sceneGameobjects[counter1].transform;
                }

            }

            SetMainCamera();
            shaders[0].Use();
            shaders[0].SetUniformFloat("inp", 1f);

            while(!windowShouldClose()) MainLoop();
        }

        private static void UpdateProjectionMatrixOnShaders(){
            for(int i = 0; i < shaders.Count; i++){
                shaders[i].SetUniformMatrix4f("projection", projectionMatrix);
            }
        }

        private static void sizeCallabck(Window window, int width, int height){
            MainProcess.width = width;
            MainProcess.height = height;
            projectionMatrix = Matrix4f.projection(fieldOfView, width / (float) height, 0.1f, 1000.0f);
            glViewport(0, 0, width, height);
        }

        public static bool windowShouldClose(){
            return Glfw.WindowShouldClose(window);
        }

        private static void SetMainCamera(){
            for(int i = 0; i < sceneGameobjects.Count; i++){
                for(int j = 0; j < sceneGameobjects[i].components.Count; j++){
                    if(sceneGameobjects[i].components[j] is Camera)
                        mainCamera = (Camera) sceneGameobjects[i].components[j];

                }
            }
        }

        private static void UpdateComponents(){
            for(counter1 = 0; counter1 < sceneGameobjects.Count; counter1++){
                for(counter2 = 0; counter2 < sceneGameobjects[counter1].components.Count; counter2++){
                    sceneGameobjects[counter1].components[counter2].Update();
                }
            }
        }

        private static void Render(){
            //Ustawianie view matrixa
            for(counter1 = 0; counter1 < shaders.Count; counter1++){
                shaders[counter1].SetUniformMatrix4f("view", viewMatrix);
            }

            //Renderowanie wszystkich gameobjectów z rendermeshem
            for(counter1 = 0; counter1 < sceneGameobjects.Count; counter1++){
                int shader;
                if(sceneGameobjects[counter1].renderComponent != null){
                #pragma warning disable CS8602

                    shader = sceneGameobjects[counter1].renderComponent.shader;
                    if(currentShader != shader){
                        shaders[shader].Use(); 
                        currentShader = shader;
                    }

                    shaders[currentShader].SetUniformMatrix4f("model", sceneGameobjects[counter1].transform.GetModelMatrix());

                    glBindVertexArray(sceneGameobjects[counter1].renderComponent.mesh.id);
                    // shaders[currentShader].SetUniformMaterial(sceneGameobjects[counter1].renderComponent.material);
                    glDrawArrays(GL_TRIANGLES, 0, sceneGameobjects[counter1].renderComponent.mesh.vertices);

                #pragma warning restore CS8602
                }
            }
        }

        public static void MainLoop(){
            OpenGL.GL.glClearColor(0.18f, 0.18f, 0.18f, 1f);
            OpenGL.GL.glClear(OpenGL.GL.GL_COLOR_BUFFER_BIT | OpenGL.GL.GL_DEPTH_BUFFER_BIT);

            UpdateComponents();

            // renderThread.Start();

            Render();

            GLFW.Glfw.PollEvents();                
            GLFW.Glfw.SwapBuffers(MainProcess.window);
            
        }

    }

}   