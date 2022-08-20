using CoreEngine;
using Engine;


namespace App {
    class App {
        private static void Main(string[] args){

            // MainProcess.Init();

            // List<Behaviour> behavioursList = new List<Behaviour>();
            // int behaviourCount = behavioursList.Count;
            // int behaviourIterator = 0;

            Quaternion result = Quaternion.eulerAngles(90, 90, 0);

            Console.WriteLine(
                // $"Result: w: {result.w} x: {result.x} y: {result.y} z: {result.z}"
                $"Result: x: {result.x} y: {result.y} z: {result.z} w: {result.w}"
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