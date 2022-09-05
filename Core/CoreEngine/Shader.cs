using Engine;
using GLFW;
using static OpenGL.GL;

namespace CoreEngine {
    class Shader {

        private uint program;

        private Dictionary<string, int> uniforms;

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

            uniforms = new Dictionary<string, int>();

        }

        public void SetupUniform(string uniformName){
            int uniform = glGetUniformLocation(program, uniformName);
            if(uniform != -1){
                Console.WriteLine("Cannot find uniform named: " + uniformName);
                return;
            }
            uniforms.Add(uniformName, uniform);
        }

        public void SetupUniforms(params string[] uniformsName){
            int uniform;
            foreach(var v in uniformsName){
                uniform = glGetUniformLocation(program, v);
                if(uniform == -1){
                    Console.WriteLine("Cannot find uniform named: " + v);
                    return;
                }
                uniforms.Add(v, uniform);
            }
        }

        public void Use() => glUseProgram(program);

        public void SetUniformMaterial(Material value){
            glUniform3fv(uniforms["material.ambinet"], 1, value.ambient.glVal);
            glUniform3fv(uniforms["material.diffuse"], 1, value.diffuse.glVal);
            glUniform3fv(uniforms["material.specular"], 1, value.specular.glVal);
            glUniform1f(uniforms["material.shininess"], value.shininess);
            glBindTexture(GL_TEXTURE_2D, value.texture.id);
        }

        public void SetUniformMatrix4f(string uniformName, in Matrix4f value){
            if(uniforms.ContainsKey(uniformName))
                glUniformMatrix4fv(uniforms[uniformName], 1, false, value.values);
        }

        public void SetUniformVector3f(string uniformName, in Vector3 value){
            if(uniforms.ContainsKey(uniformName))
                glUniform3fv(uniforms[uniformName], 1, value.glVal);
        }

        public void SetUniformFloat(string uniformName, float value){
            if(uniforms.ContainsKey(uniformName))
                glUniform1f(uniforms[uniformName], value);
        }

        public void SetUniformInt(string uniformName, int value){
            if(uniforms.ContainsKey(uniformName))
                glUniform1i(uniforms[uniformName], value);
        }

    }
}