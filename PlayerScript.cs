namespace Engine {
    class PlayerScript : Behaviour {

        public override void Update(){
            if(Input.GetKey(KeyCode.W)){
                transform.position += new Vector3(.1f, 0.0f, 0.0f);
            }
            if(Input.GetKey(KeyCode.S)){
                transform.position += new Vector3(-.1f, 0.0f, 0.0f);
            }
            if(Input.GetKey(KeyCode.A)){
                transform.position += new Vector3(0.0f, 0.0f, -.1f);
            }
            if(Input.GetKey(KeyCode.D)){
                transform.position += new Vector3(0.0f, 0.0f, .1f);
            }
            Console.WriteLine($"{transform.position.x} {transform.position.y} {transform.position.z}");
        }
    }
}