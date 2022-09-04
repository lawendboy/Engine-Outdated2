#version 330 core
out vec4 FragColor;

uniform float inp;

void main()
{
    FragColor = vec4(inp);
}