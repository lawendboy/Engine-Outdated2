using Engine;
using CoreEngine;
namespace Engine{
    static class Input {
        // public static bool GetKeyCode(KeyCode key){
        //     return GLFW.Glfw.GetKey(MainProcess.window, 0);
        // }
        public static bool GetKey(KeyCode key){
            return GLFW.Glfw.GetKey(MainProcess.window, ((int)key)) == GLFW.InputState.Press;
        }
        public static bool GetKeyReleased(KeyCode key){
            return GLFW.Glfw.GetKey(MainProcess.window, ((int)key)) == GLFW.InputState.Release;
        }
    }
}