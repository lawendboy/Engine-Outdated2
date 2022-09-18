namespace Engine {
    class PlayerScript : Behaviour {

        float roll = 0;
        float yaw = 0;
        public override void Update(){
            if(Input.GetKey(KeyCode.W)){
                transform.position -= Time.deltaTime * transform.forward;
            }
            if(Input.GetKey(KeyCode.S)){
                transform.position += Time.deltaTime * transform.forward;
            }
            if(Input.GetKey(KeyCode.A)){
                transform.position -= Time.deltaTime * transform.left;
            }
            if(Input.GetKey(KeyCode.D)){
                transform.position += Time.deltaTime * transform.left;
            }
            if(Input.GetKey(KeyCode.Left)){
                yaw += 0.1f;
            }
            if(Input.GetKey(KeyCode.Right)){
                yaw -= 0.1f;
            }
            if(Input.GetKey(KeyCode.Up)){
                roll += 0.1f;
            }
            if(Input.GetKey(KeyCode.Down)){
                roll -= 0.1f;
            }
            transform.rotation = Quaternion.eulerAngles(roll, yaw, 0);
            Console.WriteLine($"{transform.position.x} {transform.position.y} {transform.position.z} | {transform.rotation.x} {transform.rotation.y} {transform.rotation.z} {transform.rotation.w}");
            Console.WriteLine($"{transform.forward.x} {transform.forward.y} {transform.forward.z}");
        }
    }
}