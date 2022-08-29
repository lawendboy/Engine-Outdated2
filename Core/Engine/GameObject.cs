namespace Engine {
    class GameObject {
        public Transform transform;
        public List<Component> components;
        public Component? renderComponent;
        public List<Behaviour> behaviours;
        public GameObject(){
            transform = new Transform();
            components = new List<Component>();
            behaviours = new List<Behaviour>();
        }
    }
}