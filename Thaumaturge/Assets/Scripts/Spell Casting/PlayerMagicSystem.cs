using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    [Header("Inventory Reference")]
    public Scroll fireballScroll;
    public Scroll icicleScroll;

    [Header("Mana and Cast Time")]
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 2f;
    [SerializeField] private float timeBetweenCasts = 0.25f;
    
    private float currentCastTimer;
    private bool castingMagic = false;

    private void Awake()
    {
        currentMana = maxMana;
    }

    private void Update()
    {
        SpellOne();
        SpellTwo();
    }

    public void SpellOne()
    {
        // player has enough mana and input key
        bool hasEnoughMana = currentMana - fireballScroll.spell.spellToCast.manaCost >= 0f;
        bool isCastingMagic = Input.GetKey(KeyCode.Q);

        if (!castingMagic && isCastingMagic && hasEnoughMana)
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
        bool isCastingMagic = Input.GetKey(KeyCode.F);

        if (!castingMagic && isCastingMagic && hasEnoughMana)
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
