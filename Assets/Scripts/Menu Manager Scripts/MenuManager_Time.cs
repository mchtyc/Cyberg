using System;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager_Time : MonoBehaviour
{
    public static string Format(TimeSpan t)
    {
        if (t.Hours > 0)
        {
            return (int)t.TotalHours + " h " + t.Minutes + " m";
        }
        else if (t.Hours == 0 && t.Minutes > 0)
        {
            return t.Minutes + " m";
        }
        else if(t.Minutes == 0)
        {
            return t.Seconds + " s";
        }

        return "Time Conversion Error";
    }
}
