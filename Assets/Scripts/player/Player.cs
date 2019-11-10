namespace player
{
    using UnityEngine;
    using game;

    public class Player : MonoBehaviour
    {
        public Game game;
        public float walkSpeed = 1f;
        public float jumpIntensity = 1f;
        public float explosionRadius = 1f;
        public float upwardMod = 1f;
        Rigidbody body;

        void Awake()
        {
            body = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if(Input.GetKey(KeyCode.A)) Move(Direction.LEFT);
            if(Input.GetKey(KeyCode.S)) Move(Direction.BACKWARD);
            if(Input.GetKey(KeyCode.D)) Move(Direction.RIGHT);
            if(Input.GetKey(KeyCode.W)) Move(Direction.FORWARD);
            if(Input.GetKeyDown(KeyCode.Space)) Jump();
        }

        void Move(Direction direction)
        {
            switch(direction) {
                case Direction.FORWARD:
                    Walk(new Vector2(0, walkSpeed * Time.timeScale));
                    break;
                case Direction.BACKWARD:
                    Walk(new Vector2(0, -1 * walkSpeed * Time.timeScale));
                    break;
                case Direction.LEFT:
                    Walk(new Vector2(-1 * walkSpeed * Time.timeScale, 0));
                    break;
                case Direction.RIGHT:
                    Walk(new Vector2(walkSpeed * Time.timeScale, 0));
                    break;
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "kill")
            {
                game.Restart();
            }
        }

        public void Respawn(Vector3 position)
        {
            transform.position = position;
        }

        void Jump()
        {
            body.AddExplosionForce(jumpIntensity, transform.position, explosionRadius, upwardMod);
        }

        void Walk(Vector2 moveBy)
        {
            transform.position += new Vector3(moveBy.x, 0, moveBy.y);
        }
    }
}