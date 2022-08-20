using CoreEngine;
using Engine;


namespace App {
    class App {
        private static void Main(string[] args){

            // MainProcess.Init();

            // List<Behaviour> behavioursList = new List<Behaviour>();
            // int behaviourCount = behavioursList.Count;
            // int behaviourIterator = 0;

            Quaternion a = new Quaternion(18, 49, 19, 64); // 0.2123977, 0.5781937, 0.2241976, 0.7551918
            Quaternion b = new Quaternion(64, 21, 47, 72); // 0.5859489, 0.1922645, 0.4303062, 0.6591925
            Quaternion result = a * b;

            Console.WriteLine(
                $"Result: w: {result.w} x: {result.x} , y: {result.y} , z: {result.z}"
            );

            // while(!MainProcess.windowShouldClose()){
            //     GLFW.Glfw.PollEvents();
            //     if(Input.GetKey(KeyCode.A))
            //         Console.WriteLine("A");
            //     GLFW.Glfw.SwapBuffers(MainProcess.window);
            // }
            
        }

    }
}