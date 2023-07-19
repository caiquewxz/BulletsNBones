using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimControl : MonoBehaviour
{
    Vector2 mousePos = new Vector2();

    [SerializeField] LayerMask mouseCollisionMask;

    void Update()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 screenPointWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 5));

        Vector3 direction = Vector3.Normalize(screenPointWorldSpace -  origin);

        RaycastHit hit;
        bool hittedGround = Physics.Raycast(origin, direction, out hit, 100f, mouseCollisionMask);

        if (hittedGround)
        {
            Vector3 lookRotation = Quaternion.LookRotation(Vector3.Normalize(hit.point - transform.position)).eulerAngles;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lookRotation.y, transform.rotation.eulerAngles.z);
        }

        //projectile launch and creation
        /*if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(template, transform.position, transform.rotation);
            
        }*/
    }

    void OnGUI()
    {
        Event currentEvent = Event.current;

        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = Camera.main.pixelHeight - currentEvent.mousePosition.y;

    }
}
