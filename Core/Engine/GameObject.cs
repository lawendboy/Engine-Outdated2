namespace Engine {
    class GameObject {
        public Transform transform;
        public List<Component> components;
        public GameObject(){
            transform = new Transform();
            components = new List<Component>();
        }
    }
}