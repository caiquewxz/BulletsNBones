using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class TpsAnimController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private Vector3 lastPosition;
    private Vector3 velocity;
    private float forwardSpeed;
    private float sideSpeed;
    private readonly float maxSpeed = .35f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CalcVelocity());
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("ForwardSpeed", forwardSpeed);
        animator.SetFloat("SideSpeed", sideSpeed);
    }


    IEnumerator CalcVelocity()
    {
        while (true)
        {
            velocity = (transform.position - lastPosition);
            forwardSpeed = Vector3.Dot(transform.forward, velocity) / maxSpeed;
            sideSpeed = Vector3.Dot(transform.right, velocity) / maxSpeed;

            Debug.Log("Forward: " + forwardSpeed + " SideSpeed: " + sideSpeed);

            lastPosition = transform.position;
            yield return new WaitForSeconds(.1f);
        }
    }
}
