using System;
using CoreEngine;

namespace Engine {
    struct Material {
        public Texture texture;
        public Vector3 ambient;
        public Vector3 diffuse;
        public Vector3 specular;
        public float shininess;
    }
}