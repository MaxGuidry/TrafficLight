using UnityEngine;
using System.Collections;

public interface ILightBehaviour
{
    void UpdateState();
    void ToRed();
    void ToGreen();
    void ToYellow();
}
