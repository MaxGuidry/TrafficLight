using UnityEngine;
using System.Collections;
using System;

public class GreenState : ILightBehaviour {

    Lights lighting;
    public GreenState(Lights lights)
    {
        lighting = lights;
        lighting.bulbs["Green"].TurnOff();
      

    }

    public void ToGreen()
    {
       
    }

    public void ToRed()
    {
        
    }

    public void ToYellow()
    {
        
        lighting.m_timer = 0;
        End();
        lighting.currentState = lighting.yellowState;
    }

    // Use this for initialization
    void Start () {

       
	}

   
    // Update is called once per frame
   
    void End()
    {
        lighting.bulbs["Green"].TurnOff();
    }

    public void UpdateState()
    {
        if(lighting.m_timer <.5)
        {
            lighting.bulbs["Green"].TurnOn();
        }
        if (lighting.m_timer > 4)
            ToYellow();
    }
   
}
