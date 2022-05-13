using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuManager_Master : MonoBehaviour
{
    public delegate void MenuManagerGeneralHandler();

    public event MenuManagerGeneralHandler EventMenuToggled;
    public event MenuManagerGeneralHandler EventCloseBoxMenu;

    // FreeBox Events
    public event MenuManagerGeneralHandler EventUpdateFreeBox;
    public event MenuManagerGeneralHandler EventOpenFreeBox;
    public event MenuManagerGeneralHandler EventRestartFreeBox;

    // AdBox Events
    public event MenuManagerGeneralHandler EventUpdateAdBox;
    public event MenuManagerGeneralHandler EventOpenAdBox;
    public event MenuManagerGeneralHandler EventRestartAdBox;

    // KeyBox Events
    public event MenuManagerGeneralHandler EventUpdateKeyBox;
    public event MenuManagerGeneralHandler EventOpenKeyBox;
    public event MenuManagerGeneralHandler EventRestartKeyBox;

    // MissionBox Events
    public event MenuManagerGeneralHandler EventUpdateMissionBox;
    public event MenuManagerGeneralHandler EventOpenMissionBox;
    public event MenuManagerGeneralHandler EventRestartMissionBox;

    // GameBox1 Events
    public event MenuManagerGeneralHandler EventUpdateGameBox1;
    public event MenuManagerGeneralHandler EventOpenGameBox1;
    public event MenuManagerGeneralHandler EventRestartGameBox1;
    public event MenuManagerGeneralHandler EventWaitingGameBox1;

    // GameBox2 Events
    public event MenuManagerGeneralHandler EventUpdateGameBox2;
    public event MenuManagerGeneralHandler EventOpenGameBox2;
    public event MenuManagerGeneralHandler EventRestartGameBox2;
    public event MenuManagerGeneralHandler EventWaitingGameBox2;

    // GameBox3 Events
    public event MenuManagerGeneralHandler EventUpdateGameBox3;
    public event MenuManagerGeneralHandler EventOpenGameBox3;
    public event MenuManagerGeneralHandler EventRestartGameBox3;
    public event MenuManagerGeneralHandler EventWaitingGameBox3;

    public void CallEventMenuToggled()
    {
        if (EventMenuToggled != null)
        {
            EventMenuToggled();
        }
    }

    public void CallEventCloseBoxMenu()
    {
        if(EventCloseBoxMenu != null)
        {
            EventCloseBoxMenu();
        }
    }

    // FreeBox Callers
   
    public void CallEventUpdateFreeBox()
    {
        if (EventUpdateFreeBox != null)
        {
            EventUpdateFreeBox();
        }
    }
 
    public void CallEventOpenFreeBox()
    {
        if (EventOpenFreeBox != null)
        {
            EventOpenFreeBox();
        }
    }
   
    public void CallEventRestartFreeBox()
    {
        if (EventRestartFreeBox != null)
        {
            EventRestartFreeBox();
        }
    }

    // AdBox Callers

    public void CallEventUpdateAdBox()
    {
        if (EventUpdateAdBox != null)
        {
            EventUpdateAdBox();
        }
    }

    public void CallEventOpenAdBox()
    {
        if (EventOpenAdBox != null)
        {
            EventOpenAdBox();
        }
    }

    public void CallEventRestartAdBox()
    {
        if (EventRestartAdBox != null)
        {
            EventRestartAdBox();
        }
    }

    // KeyBox Callers

    public void CallEventUpdateKeyBox()
    {
        if (EventUpdateKeyBox != null)
        {
            EventUpdateKeyBox();
        }
    }

    public void CallEventOpenKeyBox()
    {
        if (EventOpenKeyBox != null)
        {
            EventOpenKeyBox();
        }
    }

    public void CallEventRestartKeyBox()
    {
        if (EventRestartKeyBox != null)
        {
            EventRestartKeyBox();
        }
    }

    // MissionBox Callers

    public void CallEventUpdateMissionBox()
    {
        if (EventUpdateMissionBox != null)
        {
            EventUpdateMissionBox();
        }
    }

    public void CallEventOpenMissionBox()
    {
        if (EventOpenMissionBox != null)
        {
            EventOpenMissionBox();
        }
    }

    public void CallEventRestartMissionBox()
    {
        if (EventRestartMissionBox != null)
        {
            EventRestartMissionBox();
        }
    }

    // GameBox1 Callers

    public void CallEventUpdateGameBox1()
    {
        if (EventUpdateGameBox1 != null)
        {
            EventUpdateGameBox1();
        }
    }

    public void CallEventOpenGameBox1()
    {
        if (EventOpenGameBox1 != null)
        {
            EventOpenGameBox1();
        }
    }

    public void CallEventRestartGameBox1()
    {
        if (EventRestartGameBox1 != null)
        {
            EventRestartGameBox1();
        }
    }

    public void CallEventWaitingGameBox1()
    {
        if(EventWaitingGameBox1 != null)
        {
            EventWaitingGameBox1();
        }
    }

    // GameBox2 Callers

    public void CallEventUpdateGameBox2()
    {
        if (EventUpdateGameBox2 != null)
        {
            EventUpdateGameBox2();
        }
    }

    public void CallEventOpenGameBox2()
    {
        if (EventOpenGameBox2 != null)
        {
            EventOpenGameBox2();
        }
    }

    public void CallEventRestartGameBox2()
    {
        if (EventRestartGameBox2 != null)
        {
            EventRestartGameBox2();
        }
    }

    public void CallEventWaitingGameBox2()
    {
        if (EventWaitingGameBox2 != null)
        {
            EventWaitingGameBox2();
        }
    }

    // GameBox3 Callers

    public void CallEventUpdateGameBox3()
    {
        if (EventUpdateGameBox3 != null)
        {
            EventUpdateGameBox3();
        }
    }

    public void CallEventOpenGameBox3()
    {
        if (EventOpenGameBox3 != null)
        {
            EventOpenGameBox3();
        }
    }

    public void CallEventRestartGameBox3()
    {
        if (EventRestartGameBox3 != null)
        {
            EventRestartGameBox3();
        }
    }

    public void CallEventWaitingGameBox3()
    {
        if (EventWaitingGameBox3 != null)
        {
            EventWaitingGameBox3();
        }
    }
}
