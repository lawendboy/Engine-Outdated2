using Engine;
using GLFW;
using static OpenGL.GL;

namespace CoreEngine {
    class Shader {

        private uint program;

        private Dictionary<string, uint> uniforms;

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

            uniforms = new Dictionary<string, uint>();

        }

        public void SetupUniform(string uniformName){
            uint uniform = glGetUniformLocation(program, uniformName);
            if(uniform == 0xFFFF){
                Console.WriteLine("Cannot find uniform named: " + uniformName);
                return;
            }
            uniforms.Add(uniformName, uniform);
        }

        public void SetupUniforms(string[] uniformsName){
            uint uniform;
            foreach(var v in uniformsName){
                uniform = glGetUniformLocation(program, v);
                if(uniform == 0xFFFF){
                    Console.WriteLine("Cannot find uniform named: " + v);
                    return;
                }
                uniforms.Add(v, uniform);
            }
        }
        public void Use(){
            glUseProgram(program);
        }



    }
}