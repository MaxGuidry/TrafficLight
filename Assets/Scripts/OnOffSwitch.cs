using UnityEngine;
using System.Collections;

public class OnOffSwitch : MonoBehaviour
{

    public Light[] colors;
   public void TurnOn()
    {
        foreach (Light l in colors)
            l.enabled = true;
    }
    public void TurnOff()
    {
        foreach (Light l in colors)
            l.enabled = false;
    }
}
