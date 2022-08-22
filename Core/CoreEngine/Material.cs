using System;
using CoreEngine;

namespace Engine {
    struct Material {
        Texture texture;
        Vector3 ambient;
        Vector3 diffuse;
        Vector3 specular;
        float shininess;
    }
}