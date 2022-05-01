using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Transform tr;
    public Transform childTr;
    public Transform body;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithSpeed();
        RotateChildren();
    }
    Vector3 MoveDir(){
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        return (Vector3.forward * ver + Vector3.right * hor);
    }
    void MoveWithSpeed(){
        float speed = 0.02f;

        Vector3 dir = MoveDir();
        body.Translate(dir * speed);
    }
    void RotateChildren(){
        float speed = 3f;

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        Vector3 vecY = Vector3.left * speed * y;
        Vector3 vecX = Vector3.up * speed * x;

        if (childTr.eulerAngles.x >= 320 && childTr.eulerAngles.x <= 360)
            childTr.Rotate(vecY);
        else if(childTr.eulerAngles.x >= 0 && childTr.eulerAngles.x <= 40)
            childTr.Rotate(vecY);
        else if (childTr.eulerAngles.x <= 320 && childTr.eulerAngles.x >= 150)
            childTr.rotation = Quaternion.Euler(320,childTr.eulerAngles.y,0);
        else
            childTr.rotation = Quaternion.Euler(40,childTr.eulerAngles.y,0);

        childTr.rotation = Quaternion.Euler(childTr.eulerAngles.x,childTr.eulerAngles.y,0);

        body.Rotate(vecX);
    }
}
