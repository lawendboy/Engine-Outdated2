using CoreEngine;
using Engine;


namespace App {
    class App {
        private static void Main(string[] args){

            MainProcess mainProcess = new MainProcess();

            mainProcess.width = 600;
            mainProcess.height = 400;
            mainProcess.title = "Hello";

            mainProcess.Init();

            // Shader shader = new Shader("", "");
            
        }
    }
}