using CoreEngine;
using Engine;

namespace App {
    static class App {
        private static void Main(string[] args){

            MainProcess.Init();

            GameObject cameraGameObject = new GameObject();
            Camera camera = new Camera();
            cameraGameObject.AddComponent(camera);
            cameraGameObject.AddComponent(new PlayerScript());

            MainProcess.sceneGameobjects.Add(cameraGameObject);

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