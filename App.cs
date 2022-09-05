using CoreEngine;
using Engine;
using System.Runtime.CompilerServices;

namespace App {
    static class App {
        private static void Main(string[] args){

            MainProcess.Init();

            Shader mainShader = new Shader(
                File.ReadAllText(Directory.GetCurrentDirectory() + "/shaders/vertex.glsl"),
                File.ReadAllText(Directory.GetCurrentDirectory() + "/shaders/fragment.glsl")
            );
            //FragColor = vec4(texture(inputTexture, fs_in.TexCoords).rgb, 1.0);

            float[] objectArray = new float[]{
                1.000000f, 1.000000f, -1.000000f, 
                1.000000f, -1.000000f, -1.000000f,
                1.000000f, 1.000000f, 1.000000f,
                1.000000f, -1.000000f, 1.000000f, 
                -1.000000f, 1.000000f, -1.000000f,
                -1.000000f, -1.000000f, -1.000000f,
                -1.000000f, 1.000000f, 1.000000f, 
                -1.000000f, -1.000000f, 1.000000f,
            };

            var vertices = new[] {
            -0.5f, -0.5f, 0.0f, 0, 0, 0, 0, 0,
            0.5f, -0.5f, 0.0f, 0, 0, 0, 0, 0,
            0.0f,  0.5f, 0.0f, 0, 0, 0, 0, 0
            };

            // mainShader.SetupUniform("inputTexture");

            // mainShader.SetupUniform("projection");
            mainShader.SetupUniform("value");
            // mainShader.SetupUniform("inp");
            // mainShader.SetupUniform("view");
            // mainShader.SetupUniform("model");

            MainProcess.shaders.Add(mainShader);

            GameObject cameraGameObject = new GameObject();
            Camera camera = new Camera();
            cameraGameObject.AddComponent(camera);
            cameraGameObject.AddComponent(new PlayerScript());

            GameObject cube = new GameObject();

            MeshRenderer renderer = new MeshRenderer();
            renderer.mesh = Loader.LoadMeshFloatArray(vertices);
            renderer.material = new Material();
            renderer.shader = 0;

            cube.renderComponent = renderer;

            MainProcess.sceneGameobjects.Add(cameraGameObject);
            MainProcess.sceneGameobjects.Add(cube);

            MainProcess.StartScene();

            // List<Behaviour> behavioursList = new List<Behaviour>();
            // int behaviourCount = behavioursList.Count;
            // int behaviourIterator = 0;

            // List<GameObject> sceneObjectsList = new List<GameObject>();
            // int sceneObjectsCount = sceneObjectsList.Count;
            // int sceneObjectsIterator = 0;

        }

    }
}