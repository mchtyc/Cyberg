using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStatSample
{
	public float BaseValue;
	List<StatModifierSample> statModifiers = new List<StatModifierSample>();
	//public readonly ReadOnlyCollection<StatModifier> StatModifiers;

	bool isDirty = true;
	float lastBaseValue;

	float _value;

	public float Value
	{
		get
		{
			if (isDirty || lastBaseValue != BaseValue)
			{
				lastBaseValue = BaseValue;
				_value = CalculateFinalValue();
				isDirty = false;
			}
			return _value;
		}
	}

	//public CharacterStat()
	//{
	//	statModifiers = new List<StatModifier>();
	//	//StatModifiers = statModifiers.AsReadOnly();
	//}

	//public CharacterStat(float baseValue) : this()
	//{
	//	BaseValue = baseValue;
	//}

	void Notify()
	{
		// Notify other objects that need this stat to update their values
		// Gerek yok gibi ama bir ihtimal olabilir.
	}

	public void AddModifier(StatModifierSample mod, float t, CharacterStatSample cs)
	{
		isDirty = true;
		statModifiers.Add(mod);
		Notify();
		remove.instance.removeModifier(mod, t, cs);
		
	}

	//public IEnumerator c(StatModifierSample s, float t)
	//{
	//	yield return new WaitForSeconds(t);

	//	RemoveModifier(s);
	//}

	public bool RemoveModifier(StatModifierSample mod)
	{
		if (statModifiers.Remove(mod))
		{
			isDirty = true;
			return true;
		}

		Notify();
		return false;
	}

	public bool RemoveAllModifiersFromSource(object source)
	{
		int numRemovals = statModifiers.RemoveAll(mod => mod.Source == source);

		if (numRemovals > 0)
		{
			isDirty = true;
			return true;
		}

		Notify();
		return false;
	}

	protected int CompareModifierOrder(StatModifierSample a, StatModifierSample b)
	{
		if (a.Order < b.Order)
			return -1;
		else if (a.Order > b.Order)
			return 1;
		return 0; //if (a.Order == b.Order)
	}

	float CalculateFinalValue()
	{
		float finalValue = BaseValue;
		float sumPercentAdd = 0;

		statModifiers.Sort(CompareModifierOrder);

		for (int i = 0; i < statModifiers.Count; i++)
		{
			StatModifierSample mod = statModifiers[i];

			if (mod.Type == StatModTypeOld.Flat)

			{
				finalValue += mod.Value;
			}
			else if (mod.Type == StatModTypeOld.PercentAdd)
			{
				sumPercentAdd += mod.Value;

				if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModTypeOld.PercentAdd)
				{
					finalValue *= 1 + sumPercentAdd;
					sumPercentAdd = 0;
				}
			}
			else if (mod.Type == StatModTypeOld.PercentMult)
			{
				finalValue *= 1 + mod.Value;
			}
		}

		// Workaround for float calculation errors, like displaying 12.00001 instead of 12
		return (float)Math.Round(finalValue, 4);
	}
}
