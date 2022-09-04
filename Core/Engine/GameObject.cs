namespace Engine {
    class GameObject {
        public Transform transform;
        public List<Component> components;
        #pragma warning disable CS0649
        public MeshRenderer? renderComponent;
        #pragma warning restore CS0649
        public GameObject(){
            components = new List<Component>();
            transform = new Transform();
        }
        public void AddComponent(Component component) => components.Add(component);
    }
}