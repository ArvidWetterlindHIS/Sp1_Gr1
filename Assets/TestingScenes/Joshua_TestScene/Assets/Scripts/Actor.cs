using UnityEngine;

public class Actor : Combat
{
    [SerializeField] public static TMPro.TMP_Text HealthText;
    [SerializeField] private int actorDamage;
    [SerializeField] private int actorMaxHealth;
    [SerializeField] private int actorHealth;

    [SerializeField] private string actorName;
    [SerializeField] private Sprite actorSprite;
    [SerializeField] private SpriteRenderer actorRenderer;
    
    public void Initialize(string actorName, Sprite actorSprite, Vector3 actorPosition, int actorDamage, int actorMaxHealth, int actorHealth)
    {
        actorRenderer = gameObject.AddComponent<SpriteRenderer>();
        this.actorName = actorName;
        this.actorSprite = actorSprite;
        transform.position = actorPosition;
        actorRenderer.sprite = actorSprite;
    }
        
    public Actor CreateActor(string objectName, string actorName, Sprite actorSprite, Vector3 actorPosition, int actorDamage, int actorMaxHealth, int actorHealth)
    {
        GameObject actorObject =  new GameObject(objectName);
        Actor actor = actorObject.AddComponent<Actor>();
        actor.Initialize(actorName, actorSprite, actorPosition, actorDamage, actorMaxHealth, actorHealth);
        return actor;
    }
}
