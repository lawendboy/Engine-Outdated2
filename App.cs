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
                GLFW.Glfw.PollEvents();
                if(Input.GetKey(KeyCode.A))
                    Console.WriteLine("A");
                GLFW.Glfw.SwapBuffers(MainProcess.window);
            }
            
        }

    }
}