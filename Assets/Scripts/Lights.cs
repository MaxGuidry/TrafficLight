using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Lights : MonoBehaviour {

    [HideInInspector]
    public GreenState greenState;

    [HideInInspector]
    public RedState redState;

    [HideInInspector]
    public YellowState yellowState;

    public string cs;
 
    public ILightBehaviour currentState;
    [HideInInspector]
    public float m_timer;

    [SerializeField]
    private OnOffSwitch[] objs;
   
    public Dictionary<string,OnOffSwitch> bulbs= new Dictionary<string, OnOffSwitch>();
    
    // Use this for initialization
    void Start () {
        bulbs.Add("Red", objs[2]);
        bulbs.Add("Green", objs[0]);
        bulbs.Add("Yellow", objs[1]);
        greenState = new GreenState(this);
        redState = new RedState(this);
        yellowState = new YellowState(this);
        currentState = redState;
        m_timer = 0f;
       
    }
	
	// Update is called once per frame
	void Update () {
        
        currentState.UpdateState();
        cs = currentState.GetType().ToString();
        m_timer += Time.deltaTime;

	}
}
