using CoreEngine;
using Engine;


namespace App {
    class App {
        private static void Main(string[] args){

            Vector4 a = new Vector4(10, 11, 12, 13);
            var matA = new Matrix4f(new float[]{
                1, 2, 3, 4,
                5, 6, 7, 8,
                9, 10, 11, 12,
                13, 14, 15, 16
            });
            a = Matrix4f.identity * a;
            matA = matA * matA;

            MainProcess mainProcess = new MainProcess();

            mainProcess.width = 600;
            mainProcess.height = 400;
            mainProcess.title = "Hello";

            mainProcess.Init();

            // Shader shader = new Shader("", "");
            
        }
    }
}