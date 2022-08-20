using Engine;
using GLFW;
using static OpenGL.GL;

namespace CoreEngine {
    class Shader {

        private uint program;

        public Shader(string vertexShaderCode, string fragmentShaderCode){
            uint vertexShader;
            vertexShader = glCreateShader(GL_VERTEX_SHADER);
            glShaderSource(vertexShader, vertexShaderCode);
            glCompileShader(vertexShader);

            if(glGetShaderiv(vertexShader, GL_COMPILE_STATUS, 1)[0] == 0){
                Console.WriteLine(glGetShaderInfoLog(vertexShader, 512));
            }

            uint fragmentShader;
            fragmentShader = glCreateShader(GL_FRAGMENT_SHADER);
            glShaderSource(fragmentShader, fragmentShaderCode);
            glCompileShader(fragmentShader);

            if(glGetShaderiv(fragmentShader, GL_COMPILE_STATUS, 1)[0] == 0){
                Console.WriteLine(glGetShaderInfoLog(fragmentShader, 512));
            }

            program = glCreateProgram();
            glAttachShader(program, vertexShader);
            glAttachShader(program, fragmentShader);
            glLinkProgram(program);

            if(glGetProgramiv(program, GL_LINK_STATUS, 1)[0] == 0){
                Console.WriteLine(glGetProgramInfoLog(program, 512));
            }

            glDeleteShader(vertexShader);
            glDeleteShader(fragmentShader);

        }

        public void Use(){
            glUseProgram(program);
        }

    }
}