using UnityEngine;
using System.Collections;
using System;

public class YellowState : ILightBehaviour {

    Lights lighting;
    public YellowState(Lights lights)
    {
        lighting = lights;
        lighting.bulbs["Yellow"].TurnOff();

    }

    public void ToGreen()
    {
        
    }

    public void ToRed()
    {
        lighting.m_timer = 0;
        End();
        lighting.currentState = lighting.redState;
    }

    public void ToYellow()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        
    }

    

    // Update is called once per frame
  
    void End()
    {
        lighting.bulbs["Yellow"].TurnOff();

    }



    public void UpdateState()
    {
        if (lighting.m_timer < .5)
        {
            lighting.bulbs["Yellow"].TurnOn();

        }
        if (lighting.m_timer > 2)
            ToRed();
    }
}
