﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffInstant : Buff
{
    public BuffInstant()
    {
        durationMax = -1;
        stacksMax = 1;
        buffName = "Instant Buff";
    }
    public override void OnApply(Unit target)
    {
        base.OnApply(target);
        target.RemoveBuff(this);
        Execute(target);
    }

    public override void TriggeredUpdate(Unit target)
    {
    }

    public abstract void Execute(Unit target);
}
