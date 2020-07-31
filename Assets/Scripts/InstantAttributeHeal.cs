﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantAttributeHeal : BuffInstant
{
    public float healing;
    public Attribute atr;

    public InstantAttributeHeal(float healing, Attribute atr)
    {
        this.healing = healing;
        this.atr = atr;
    }

    public override void Execute(Unit target)
    {
        int bonus;
        Hero hero = target.buffSources[this] as Hero;
        if (!hero)
        {
            target.Heal(healing);
            return;
        }
        switch (atr)
        {
            case Attribute.DEX: bonus = hero.dexterity; break;
            case Attribute.STR: bonus = hero.strength; break;
            default: bonus = hero.wisdom; break;
        }
        if (hero.heroClass == HeroClass.CLERIC)
            healing *= 1.5f;
        target.Heal(healing * (1 + bonus / 100));
    }
}
