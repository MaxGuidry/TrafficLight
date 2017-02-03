using UnityEngine;
using System.Collections;
using System;

public class RedState : ILightBehaviour{
    Lights lighting;
    public RedState(Lights lights)
    {
        lighting = lights;
        lighting.bulbs["Red"].TurnOff();
    }
    public void ToGreen()
    {
     
        lighting.m_timer = 0;
        End();
        lighting.currentState = lighting.greenState;
    }

    public void ToRed()
    {
        throw new NotImplementedException();
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
        lighting.bulbs["Red"].TurnOff();

    }

    public void UpdateState()
    {
        if (lighting.m_timer < .5)
        {
            lighting.bulbs["Red"].TurnOn();

        }
        if (lighting.m_timer >= 6)
            ToGreen();
    }
}
