namespace Engine {
    class PlayerScript : Behaviour {

        public override void Update(){
            if(Input.GetKey(KeyCode.W)){
                transform.position += new Vector3(1.0f, 0.0f, 0.0f);
            }
        }
    }
}