using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    //public List<Spell> spells = new List<Spell>();
    [Header("List Reference")]
    public ListOfSpells list;
    

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
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            list.spells[0] = list.spells[1];
            list.spells.Add(list.fireball);
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            list.spells[0] = list.spells[2];
        }
    }

    void CastSpellOne()
    {
        Instantiate(list.spells[0], castPoint.position, castPoint.rotation);
    }

    void CastSpellTwo()
    {
        Instantiate(list.spells[1], castPoint.position, castPoint.rotation);
    }

    public void SpellOne()
    {
        // player has enough mana and input key
        bool hasEnoughMana = currentMana - list.spells[0].spellToCast.manaCost >= 0f;
        bool isCastingMagic = Input.GetKey(KeyCode.Q);

        if (!castingMagic && isCastingMagic && hasEnoughMana)
        {
            castingMagic = true;
            currentMana -= list.spells[0].spellToCast.manaCost;
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
        bool hasEnoughMana = currentMana - list.spells[1].spellToCast.manaCost >= 0f;
        bool isCastingMagic = Input.GetKey(KeyCode.E);

        if (!castingMagic && isCastingMagic && hasEnoughMana)
        {
            castingMagic = true;
            currentMana -= list.spells[1].spellToCast.manaCost;
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
