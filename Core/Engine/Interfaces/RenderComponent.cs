namespace Engine {
    interface RenderComponent {
        public void AttachComponent(GameObject parent);
        public void RenderUpdate();
    }
}