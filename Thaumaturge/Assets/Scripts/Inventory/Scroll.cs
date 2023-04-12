using UnityEngine;

public class Scroll : MonoBehaviour, Collectible
{
    public static event HanldeScrollCollected onScrollCollected;
    public delegate void HanldeScrollCollected(ItemData itemData);
    
    [Header("Inventory Item Scribtable Object")]
    public ItemData scrollData;

    [Header("Spell")]
    [Tooltip("Scroll gives the player a spell to cast. This is a reference to that spell.")]
    public Spell spell;

    [Tooltip("Bool to Check if scroll is collected")]
    public bool isCollected;

    [Tooltip("This is where the spell will spawn in the world.")]
    [SerializeField] private Transform castPoint;
    [SerializeField] private Transform healthPotionCastPoint;

    // if object is collected the game object will be destroyed, data collected, and isColledted is set to true
    public void Collect()
    {
        Destroy(gameObject);
        onScrollCollected?.Invoke(scrollData);
        isCollected = true;

        Debug.Log(isCollected);
    }

    public void CastSpell()
    {
        Instantiate(spell, castPoint.position, castPoint.rotation);

        if (isCollected == true)
        {
            
        }
    }

    public void HealthSpell()
    {
        Instantiate(spell, healthPotionCastPoint.position, healthPotionCastPoint.rotation);
    }
}
