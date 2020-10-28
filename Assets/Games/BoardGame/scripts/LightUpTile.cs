
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class LightUpTile : UdonSharpBehaviour
{

    public Color offColor;
    public Color onColor;
    private void Start()
    {
        //Debug.Log("Setting color");
        //this.GetComponent<Renderer>().material.color = offColor;
        //Debug.Log("Color set");
    }

    override public void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
    {
        //Debug.Log("Updating color");
        this.GetComponent<SpriteRenderer>().color = onColor;
    }

    override public void OnPlayerTriggerExit(VRCPlayerApi other)
    {
        //Debug.Log("Updating color on exit");
        this.GetComponent<SpriteRenderer>().color = offColor;
    }
}
