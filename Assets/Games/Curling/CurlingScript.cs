
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class CurlingScript : UdonSharpBehaviour
{
    private Vector3 InitialPosition;
    void Start()
    {
        InitialPosition = this.transform.position;
    }

    public void RespawnCurlingThing()
    {
        this.transform.position = InitialPosition;
    }
}
