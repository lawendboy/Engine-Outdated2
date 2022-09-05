#version 330 core
out vec4 FragColor;

uniform float value;

void main()
{
    FragColor = vec4(value);
}