#pragma warning disable CS8618
namespace Engine {
    abstract class Component {
        public GameObject gameObject;
        public Transform transform;
        public virtual void Start() {}
        public virtual void Update() {}
    }
}