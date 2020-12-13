
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class BadmintonBall : UdonSharpBehaviour
{
    public float bounce;
    public float boost;

    private Vector3 InitialPosition;
    private Quaternion InitialRotation;
    void Start()
    {
        InitialPosition = this.transform.position;
        InitialRotation = this.transform.rotation;

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.enabled && collider.material.name == "racket (Instance)")
        {
            Vector3 input = GetComponent<Rigidbody>().velocity;
            Vector3 output = bounce * (input - 2 * Vector3.Dot(collider.transform.forward, input) * collider.transform.forward);
            float mult = Vector3.Dot(Vector3.Normalize(collider.attachedRigidbody.velocity), collider.transform.forward);
            if (mult > 0)
            {
                output += boost * mult * collider.transform.forward;
            }
            GetComponent<Rigidbody>().velocity = output;
        }
    }

    public void Respawn()
    {
        this.transform.position = InitialPosition;
        this.transform.rotation = InitialRotation;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
