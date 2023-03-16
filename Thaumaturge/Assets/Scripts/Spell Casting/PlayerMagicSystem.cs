using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    public Inventory inventory;

    [Header("Scroll Reference")]
    public Scroll fireballScroll;
    public Scroll icicleScroll;

    [Header("Mana and Cast Time")]
    [SerializeField] private float maxMana;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate;
    [SerializeField] private float timeBetweenCasts;
    
    private float currentCastTimer;
    private bool castingMagic = false;
    private bool fireballSelected = false;
    private bool icicleSelected = false;

    private void Awake()
    {
        currentMana = maxMana;
    }

    private void Update()
    {
        SpellOne();
        SpellTwo();

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            inventory.SelectSpell(0);
            fireballSelected = true;
            icicleSelected = false;
            Debug.Log("Spell is selected");
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            inventory.SelectSpell(1);
            icicleSelected = true;
            fireballSelected = false;
            Debug.Log("Spell is selected");
        }
    }

    public void SpellOne()
    {
        // player has enough mana and input key
        bool hasEnoughMana = currentMana - fireballScroll.spell.spellToCast.manaCost >= 0f;
        bool isCastingMagic = Input.GetMouseButtonUp(0);

        if (!castingMagic && isCastingMagic && hasEnoughMana && fireballSelected == true)
        {
            castingMagic = true;
            currentMana -= fireballScroll.spell.spellToCast.manaCost;
            currentCastTimer = 0;
            fireballScroll.CastSpell();
        }

        if (castingMagic)
        {
            currentCastTimer += Time.deltaTime;

            if (currentCastTimer > timeBetweenCasts)
            {
                castingMagic = false;
            }
        }

        // mana recharge
        if (currentMana < maxMana && !castingMagic && !isCastingMagic)
        {
            currentMana += manaRechargeRate * Time.deltaTime;

            if (currentMana > maxMana)
            {
                currentMana = maxMana;
            }
        }
    }

    public void SpellTwo()
    {
        // player has enough mana and input key
        bool hasEnoughMana = currentMana - icicleScroll.spell.spellToCast.manaCost >= 0f;
        bool isCastingMagic = Input.GetMouseButtonUp(0);

        if (!castingMagic && isCastingMagic && hasEnoughMana && icicleSelected == true)
        {
            castingMagic = true;
            currentMana -= icicleScroll.spell.spellToCast.manaCost;
            currentCastTimer = 0;
            icicleScroll.CastSpell();
        }

        if (castingMagic)
        {
            currentCastTimer += Time.deltaTime;

            if (currentCastTimer > timeBetweenCasts)
            {
                castingMagic = false;
            }
        }

        // mana recharge
        if (currentMana < maxMana && !castingMagic && !isCastingMagic)
        {
            currentMana += manaRechargeRate * Time.deltaTime;

            if (currentMana > maxMana)
            {
                currentMana = maxMana;
            }
        }
    }
}
