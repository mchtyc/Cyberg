using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Master : MonoBehaviour
{
    public delegate void PlayerEventTargetHandler(Transform t);
    public delegate void PlayerEventHealthHandler();
    //public delegate void PlayerEventModifierHandler(StatModifier modifier, ModifierOperation mOperation);
    //public delegate void PlayerEventStatHandler();
    public delegate void PlayerEventExperienceHandler(float amount);
    public delegate void PlayerEventLevelHandler();

    public event PlayerEventTargetHandler EventFindTarget;
    
    public event PlayerEventHealthHandler EventHealthUIUpdate;

    // Modifiers of Stats
    //public event PlayerEventModifierHandler EventBulletSpeedModifier;
    //public event PlayerEventModifierHandler EventCurrentHPModifier;
    //public event PlayerEventModifierHandler EventDamageModifier;
    //public event PlayerEventModifierHandler EventDefenseModifier;
    //public event PlayerEventModifierHandler EventExperienceModifier;
    //public event PlayerEventModifierHandler EventFireRateModifier;
    //public event PlayerEventModifierHandler EventHealModifier;
    //public event PlayerEventModifierHandler EventLevelModifier;
    //public event PlayerEventModifierHandler EventMaxHPModifier;
    //public event PlayerEventModifierHandler EventRangeModifier;
    //public event PlayerEventModifierHandler EventSpeedModifier;

    //public event PlayerEventStatHandler EventStatChanged;

    public event PlayerEventExperienceHandler EventExperienceIncrease;

    public event PlayerEventLevelHandler EventOnLevelIncrease;

    public void CallEventFindTarget(Transform t)
    {
        if (EventFindTarget != null)
        {
            EventFindTarget(t);
        }
    }

   public void CallEventHealthUIUpdate()
   {
        if (EventHealthUIUpdate != null)
        {
            EventHealthUIUpdate();
        }
   }

    // Event Calls of Modifiers

    //public void CallEventBulletSpeedModifier(StatModifier modifier, ModifierOperation mO)
    //{
    //    if (EventBulletSpeedModifier != null)
    //    {
    //        EventBulletSpeedModifier(modifier, mO);
    //    }
    //}

    //public void CallEventCurrentHPModifier(StatModifier modifier, ModifierOperation mO)
    //{
    //    if (EventCurrentHPModifier != null)
    //    {
    //        EventCurrentHPModifier(modifier, mO);
    //    }
    //}

    //public void CallEventDamageModifier(StatModifier modifier, ModifierOperation mO)
    //{
    //    if (EventDamageModifier != null)
    //    {
    //        EventDamageModifier(modifier, mO);
    //    }
    //}

    //public void CallEventDefenseModifier(StatModifier modifier, ModifierOperation mO)
    //{
    //    if (EventDefenseModifier != null)
    //    {
    //        EventDefenseModifier(modifier, mO);
    //    }
    //}

    //public void CallEventExperienceModifier(StatModifier modifier, ModifierOperation mO)
    //{
    //    if (EventExperienceModifier != null)
    //    {
    //        EventExperienceModifier(modifier, mO);
    //    }
    //}

    //public void CallEventFireRateModifier(StatModifier modifier, ModifierOperation mO)
    //{
    //    if (EventFireRateModifier != null)
    //    {
    //        EventFireRateModifier(modifier, mO);
    //    }
    //}

    //public void CallEventHealModifier(StatModifier modifier, ModifierOperation mO)
    //{
    //    if (EventHealModifier != null)
    //    {
    //        EventHealModifier(modifier, mO);
    //    }
    //}

    //public void CallEventLevelModifier(StatModifier modifier, ModifierOperation mO)
    //{
    //    if (EventLevelModifier != null)
    //    {
    //        EventLevelModifier(modifier, mO);
    //    }
    //}

    //public void CallEventMaxHPModifier(StatModifier modifier, ModifierOperation mO)
    //{
    //    if (EventMaxHPModifier != null)
    //    {
    //        EventMaxHPModifier(modifier, mO);
    //    }
    //}

    //public void CallEventRangeModifier(StatModifier modifier, ModifierOperation mO)
    //{
    //    if (EventRangeModifier != null)
    //    {
    //        EventRangeModifier(modifier, mO);
    //    }
    //}

    //public void CallEventSpeedModifier(StatModifier modifier, ModifierOperation mO)
    //{
    //    if (EventSpeedModifier != null)
    //    {
    //        EventSpeedModifier(modifier, mO);
    //    }
    //}

    //public void CallEventStatChanged()
    //{
    //    if (EventStatChanged != null)
    //    {
    //        EventStatChanged();
    //    }
    //}

    public void CallEventExperienceIncrease(float amount)
    {
        if (EventExperienceIncrease != null)
        {
            EventExperienceIncrease(amount);
        }
    }

    public void CallEventOnLevelIncrease()
    {
        if (EventOnLevelIncrease != null)
        {
            EventOnLevelIncrease();
        }
    }
}
