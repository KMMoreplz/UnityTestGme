using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class startButtonMenue : MonoBehaviour
{
    public Text TextForStart;
    public Button  ButtonForStart;
    public GameObject Player;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
//        Text.GetComponent<Renderer>().enabled = false;
       // Player.GetComponent<Renderer>().enabled = false;
    }   
    public void onClick(){
    ButtonForStart.GetComponent<Renderer>().enabled = false;
     Debug.Log("click");

    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
