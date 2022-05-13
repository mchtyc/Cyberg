using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatModTypeOld
{
	Flat = 100,
	PercentAdd = 200,
	PercentMult = 300,
}

public class StatModifierSample
{
	public readonly float Value;
	public readonly StatModTypeOld Type;
	public readonly int Order;
	public readonly object Source;

	public StatModifierSample(float value, StatModTypeOld type, int order, object source)
	{
		Value = value;
		Type = type;
		Order = order;
		Source = source;
	}

	public StatModifierSample(float value, StatModTypeOld type) : this(value, type, (int)type, null) { }

	public StatModifierSample(float value, StatModTypeOld type, int order) : this(value, type, order, null) { }

	public StatModifierSample(float value, StatModTypeOld type, object source) : this(value, type, (int)type, source) { }
}
