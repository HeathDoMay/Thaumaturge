using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    [Header("Player Health Reference")]
    public PlayerHealth playerHealth;
    public HealthPotion potion;

    [Header("Inventory Reference")]
    public Inventory inventory;

    [Header("Scroll Reference")]
    public Scroll fireballScroll;
    public Scroll icicleScroll;
    public Scroll shieldScroll;
    public Scroll healthScroll;

    [Header("Mana and Cast Time")]
    [SerializeField] private float maxMana;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate;
    [SerializeField] private float timeBetweenCasts;

    private float currentCastTimer;
    private bool castingMagic = false;

    private bool fireballSelected = false;
    private bool icicleSelected = false;
    private bool shieldSelected = false;
    private bool healthPotionSelected = false;

    private void Awake()
    {
        currentMana = maxMana;
    }

    private void Update()
    {
        SpellOne();
        SpellTwo();
        SpellThree();
        HealthPotion();

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            inventory.SelectSpell(0);
            fireballSelected = true;
            icicleSelected = false;
            shieldSelected = false;
            healthPotionSelected = false;
            Debug.Log("Fireball selected");
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            inventory.SelectSpell(1);
            icicleSelected = true;
            fireballSelected = false;
            shieldSelected = false;
            healthPotionSelected = false;
            Debug.Log("Icicle selected");
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            inventory.SelectSpell(2);
            shieldSelected = true;
            fireballSelected = false;
            healthPotionSelected = false;
            icicleSelected = false;

            Debug.Log("Shield Selected");
        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            inventory.SelectSpell(3);
            healthPotionSelected = true;
            fireballSelected = false;
            shieldSelected = false;
            icicleSelected = false;
            Debug.Log("Health Potion Selcted");
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

    public void SpellThree()
    {
        bool hasEnoughMana = currentMana - shieldScroll.spell.spellToCast.manaCost >= 0f;
        bool isCastingMagic = Input.GetMouseButtonUp(0);

        if (!castingMagic && isCastingMagic && hasEnoughMana && shieldSelected == true)
        {
            castingMagic = true;
            currentMana -= shieldScroll.spell.spellToCast.manaCost;
            currentCastTimer = 0;
            shieldScroll.CastSpell();
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

    public void HealthPotion()
    {
        bool hasEnoughMana = currentMana - healthScroll.spell.spellToCast.manaCost >= 0f;
        bool isCastingMagic = Input.GetMouseButtonUp(0);

        if (!castingMagic && isCastingMagic && hasEnoughMana && healthPotionSelected == true)
        {
            if (playerHealth.canHeal == true)
            {
                castingMagic = true;
                currentMana -= healthScroll.spell.spellToCast.manaCost;
                currentCastTimer = 0;
                healthScroll.HealthSpell();

                playerHealth.currentHP = potion.healAmount + playerHealth.currentHP;
                Debug.Log(playerHealth.currentHP);
            }
            else
            {
                Debug.Log("Player HP is currently MAXED: " + playerHealth.currentHP);
            }
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