
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Badminton : UdonSharpBehaviour
{
    private Vector3 InitialPosition;
    private Quaternion InitialRotation;
    void Start()
    {
        InitialPosition = this.transform.position;
        InitialRotation = this.transform.rotation;

    }

    public void Respawn()
    {
        this.transform.position = InitialPosition;
        this.transform.rotation = InitialRotation;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
