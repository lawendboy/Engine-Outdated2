#version 330 core
layout (location = 0) in vec3 pos;

uniform float value;

void main()
{
    gl_Position = /*projection* */ vec4(pos.x, pos.y, pos.z, 1.0);
}