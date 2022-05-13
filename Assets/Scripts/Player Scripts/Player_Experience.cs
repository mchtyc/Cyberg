using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Experience : MonoBehaviour
{
    public PlayerStats P_Stats;
    public float levelPoint = 100; //Busa statlara alınabilir

    Player_Master P_Master;

    void OnEnable()
    {
        P_Master = GetComponent<Player_Master>();

        P_Master.EventExperienceIncrease += gainExperience;
    }

    void OnDisable()
    {
        P_Master.EventExperienceIncrease -= gainExperience;
    }

    void gainExperience(float amount)
    {
        P_Stats.experience.Change(amount, false);
        gainLevel();
    }

    void gainLevel()
    {
        if (P_Stats.experience.Value >= levelPoint)
        {
            P_Stats.level.Change(1, false);
            P_Master.CallEventOnLevelIncrease();

            P_Stats.experience.Change(-levelPoint, false);
            levelPoint += levelPoint * 3 / 10;
            levelPoint = Mathf.Floor(levelPoint);

            gainLevel();
        }
    }
}
