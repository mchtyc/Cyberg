using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatMod
{
	Flat = 100,
	Percent = 200,
}

[System.Serializable]
public class StatModifier
{
	public readonly float Value;
	public readonly StatMod Type;
	public readonly int Order;

	public StatModifier(float value, StatMod type, int order)
	{
		Value = value;
		Type = type;
		Order = order;
	}

	public StatModifier(float value, StatMod type) : this(value, type, (int)type) { }
}
