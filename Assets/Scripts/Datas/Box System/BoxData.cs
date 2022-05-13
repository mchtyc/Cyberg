using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "new Box", menuName = "Box", order = 52)]
public class BoxData : ScriptableObject
{
    public BoxSlots boxSlot;
    public BoxType type;
    public BoxState state;
    public int coins;
    public int gems;
    public int minCoins;
    public int maxCoins;
    public int minGems;
    public int maxGems;
    public int maxCount;
    public double maxTimeInSeconds;
    
    int currentCount;
    double remainingTime;
    int level = 1;

    public BoxType Type { set { type = value; } get { return type; } }

    public BoxState State { set { state = value; } get { return state; } }

    public string Name { get { return boxSlot + " Box"; } }

    public int MinCoins { get { return finalBoundaries(minCoins); } }

    public int MaxCoins { get { return finalBoundaries(maxCoins); } }

    public int MinGems { get { return finalBoundaries(minGems); } }

    public int MaxGems { get { return finalBoundaries(maxGems); } }

    public double MaxTimeInSeconds { get { return finalMaxTime(maxTimeInSeconds); } }

    public TimeSpan RemainingTime { set { remainingTime = value.TotalSeconds; } get { return TimeSpan.FromSeconds(remainingTime); } }

    public int Coins { get { return finalCoins(); } }

    public int Gems { get { return finalGems(); } }
    
    public int Level { set { level = value; } get { return level; } }

    public int MaxCount { get { return maxCount; } }

    public int CurrentCount { set { currentCount = value; } get { return currentCount; } }

    int finalBoundaries(int value)
    {
        value *= level * (int)type;
        return value;
    }

    int finalCoins()
    {
        if (boxSlot == BoxSlots.Ad)
        {
            return coins * level;
        }
        else
        {
            return Random.Range(MinCoins, MaxCoins + 1);
        }    
    }

    int finalGems()
    {
        if (boxSlot == BoxSlots.Ad)
        {
            return gems * level;
        }
        else
        {
            return Random.Range(MinGems, MaxGems + 1);
        }
    }

    double finalMaxTime(double value)
    {
        return value * Mathf.Pow((int)type, 2);
    }

    public void RestartRemainingTime() 
    {
        remainingTime = maxTimeInSeconds;
    }

    public void RestartCurrentCount()
    {
        CurrentCount = 0;
    }

    public void createBox()
    {
        int probability = Random.Range(1, 101);

        if (probability <= 10)
        {
            Type = BoxType.Gold;
        }
        else if (probability <= 40)
        {
            Type = BoxType.Silver;
        }
        else
        {
            Type = BoxType.Bronze;
        }
    }
}
