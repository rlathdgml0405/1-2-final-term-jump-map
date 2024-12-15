using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Ammo;
    public int maxAmmo;

    public float speed;
    public float rotSpeed;
    float hAxis;
    float vAxis;
    float MouseX;
    bool wDown;
    bool jDown;

    bool isJump;

    Vector3 moveVec;
    Rigidbody rigid;
    Animator anim;
    private Vector3 startPosition;



    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();


    }

    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        FreezeRotation();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButton("Jump");
        MouseX = Input.GetAxis("Mouse X");
    }

    void Move()
    {
        // moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        //transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;

        Vector3 hori = transform.right * hAxis;
        Vector3 vert = transform.forward * vAxis;

        moveVec = (hori + vert).normalized * speed;
        rigid.MovePosition(transform.position + moveVec * Time.deltaTime);



        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("iswalk", wDown);
    }

    void Turn()
    {
        //transform.LookAt(transform.position + moveVec);
        //transform.Rotate(Vector3.up * hAxis * speed * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.up * rotSpeed * MouseX);
        }


    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * 2000, ForceMode.Impulse);
            anim.SetBool("isJimp", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }

        if (collision.gameObject.tag == "Water")
        {
            transform.position = startPosition;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            Item item = other.GetComponent<Item>();
            switch (item.type)
            {
                case Item.Type.Ammo:
                    Ammo += item.value;
                        if(Ammo > maxAmmo)
                        Ammo = maxAmmo; 
                    break;
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.name.Equals("SwitchObject"))
        {
            Door d = FindObjectOfType<Door>();

            if (d.door_state == 0)
            {
                d.door_state = 1;
            }
            else if (d.door_state == 1)
            {
                d.door_state = 2;
            }
            else if (d.door_state == 2)
            {
                d.door_state = 1;
            }
        }
    }
}

