using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfSpells : MonoBehaviour
{
    [Header("All Castable Spells")]
    public Spell fireball;
    public Spell icicle;

    public List<Spell> spells = new List<Spell>();
}
