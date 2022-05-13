using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
	[SerializeField]
	float value;
	List<StatModifier> statModifiers = new List<StatModifier>();

	bool isDirty = true;

	public float Value
	{
		get
		{
			if (isDirty)
			{
				value = CalculateFinalValue();
				isDirty = false;
			}
			return value;
		}
	}

	void Notify()
	{
		// Notify other objects that need this stat to update their values
		// Gerek yok gibi ama bir ihtimal olabilir.
	}

	public void Change(float amount, bool percent)
	{
		if (percent)
		{
			value *= 1 + amount;
		}
		else
		{
			value += amount;
		}

		if (value <= 0)
		{
			value = 0;
		}

		isDirty = true;
	}

	public void Set(float amount)
	{
		value = amount;
	}

	public void AddModifier(StatModifier mod, float time, Stat stat)
	{
		isDirty = true;
		statModifiers.Add(mod);
		Notify();
		GameManager_RemoveModifier.instance.remove(mod, time, stat);
	}

	public bool RemoveModifier(StatModifier mod)
	{
		if (statModifiers.Remove(mod))
		{
			isDirty = true;
			return true;
		}

		Notify();
		return false;
	}

	float CalculateFinalValue()
	{
		float finalValue = value;

		for (int i = 0; i < statModifiers.Count; i++)
		{
			StatModifier mod = statModifiers[i];

			if (mod.Type == StatMod.Flat)

			{
				finalValue += mod.Value;
			}
			else if (mod.Type == StatMod.Percent)
			{
				finalValue *= 1 + mod.Value;
			}
		}
		return finalValue;
	}
}
