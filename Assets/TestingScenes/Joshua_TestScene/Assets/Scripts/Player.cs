using UnityEngine;

public class Player : Actor
{
        [SerializeField] private string playerName = "Scab";
        [SerializeField] private Sprite playerSprite;
        [SerializeField] private SpriteRenderer playerRenderer;
       

        public void Initialize(string playerName, Sprite playerSprite, Vector3 playerPosition)
        {
            playerRenderer = gameObject.AddComponent<SpriteRenderer>();
            this.playerName = playerName;
            this.playerSprite = playerSprite;
            transform.position = playerPosition;
            playerRenderer.sprite = playerSprite;
        }
        
        public static Player CreatePlayer(string objectName, string playerName, Sprite playerSprite, Vector3 playerPosition)
        {
                GameObject playerObject =  new GameObject(objectName);
                Player player = playerObject.AddComponent<Player>();
                player.Initialize(playerName, playerSprite, playerPosition);
                return player;
        }
    

}
