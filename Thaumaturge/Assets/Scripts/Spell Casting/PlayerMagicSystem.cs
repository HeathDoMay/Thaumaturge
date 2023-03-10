using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    public Spell fireball;
    public Spell icicle;

    [Header("Inventory Reference")]
    public Scroll fireballScroll;
    public Scroll icicleScroll;
    

    [Header("Mana and Cast Time")]
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 2f;
    [SerializeField] private float timeBetweenCasts = 0.25f;
    private float currentCastTimer;

    [Header("Spell Casting Point")]
    [SerializeField] private Transform castPoint;

    private bool castingMagic = false;

    private void Awake()
    {
        currentMana = maxMana;
    }

    private void Update()
    {
        SpellOne();
        SpellTwo();

        // replaces a spell with another and then addes the spell that was replaced
        // if (Input.GetKeyUp(KeyCode.Alpha1))
        // {
        //     list.spells[0] = list.spells[1];
        //     list.spells.Add(list.fireball);
        // }

        // if (Input.GetKeyUp(KeyCode.Alpha2))
        // {
        //     list.spells[0] = list.spells[2];
        // }
    }

    void CastSpellOne()
    {
        if(fireballScroll.isCollected)
        {
            Instantiate(fireball, castPoint.position, castPoint.rotation);
        }
    }

    void CastSpellTwo()
    {
        if(icicleScroll.isCollected == true)
        {
            Instantiate(icicle, castPoint.position, castPoint.rotation);
        }
    }

    public void SpellOne()
    {
        // player has enough mana and input key
        bool hasEnoughMana = currentMana - fireball.spellToCast.manaCost >= 0f;
        bool isCastingMagic = Input.GetKey(KeyCode.Q);

        if (!castingMagic && isCastingMagic && hasEnoughMana)
        {
            castingMagic = true;
            currentMana -= fireball.spellToCast.manaCost;
            currentCastTimer = 0;
            CastSpellOne();
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
        bool hasEnoughMana = currentMana - icicle.spellToCast.manaCost >= 0f;
        bool isCastingMagic = Input.GetKey(KeyCode.E);

        if (!castingMagic && isCastingMagic && hasEnoughMana)
        {
            castingMagic = true;
            currentMana -= icicle.spellToCast.manaCost;
            currentCastTimer = 0;
            CastSpellTwo();
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
