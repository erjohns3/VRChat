
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class CurlingScript : UdonSharpBehaviour
{
    private Vector3 InitialPosition;
    private Quaternion InitialRotation;
    void Start()
    {
        InitialPosition = this.transform.position;
        InitialRotation = this.transform.rotation;
    }

    public void RespawnCurlingThing()
    {
        this.transform.position = InitialPosition;
        this.transform.rotation = InitialRotation;
    }
}
