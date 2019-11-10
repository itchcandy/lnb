namespace game
{
    using UnityEngine;
    using player;

    public class Game : MonoBehaviour
    {
        public Transform world;
        public Player player;
        public Level level;

        void Start()
        {
            level = Instantiate<Level>(Resources.Load<Level>("levels/Level 1"));
            level.transform.SetParent(world);
            level.transform.localPosition = Vector3.zero;
            // player.transform.position = level.spawnPoint.position;
            player.Respawn(level.spawnPoint.position);
        }

        public void Restart()
        {
            level.Reset();
            player.Respawn(level.spawnPoint.position);
        }
    }
}