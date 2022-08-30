namespace Engine {
    class GameObject {
        public Transform transform;
        public List<Component> components;
        public GameObject(){
            components = new List<Component>();
            transform = new Transform();
        }
        public void AddComponent(Component component) => components.Add(component);
    }
}