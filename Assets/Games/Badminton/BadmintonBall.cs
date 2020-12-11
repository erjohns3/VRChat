
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class BadmintonBall : UdonSharpBehaviour
{
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
            Vector3 boost = Vector3.Dot(Vector3.Normalize(collider.attachedRigidbody.velocity), collider.transform.forward) * collider.attachedRigidbody.velocity;
            GetComponent<Rigidbody>().velocity = (input - 2 * Vector3.Dot(collider.transform.forward, input) * collider.transform.forward) + boost;
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
