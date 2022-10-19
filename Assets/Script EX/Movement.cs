using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    public float Speed = 5f;
    public Animator anim;
    private Quaternion originalRot;

    public delegate void DelegateDeneme();

    public DelegateDeneme _delegateDeneme;

    void Start()
    {
        originalRot = transform.rotation;

        _delegateDeneme += MoveDirect;
        _delegateDeneme += MoveDirect;
        // _delegateDeneme += MoveRight;
         _delegateDeneme += MoveBack;

    }


    void Update()
    {
        
    }

    public void Delegate()
    {
        _delegateDeneme();
    }

    public void MoveDirect()
    {
        Vector3 temp = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2f);
        transform.position = temp;

        //transform.rotation = originalRot;

        //transform.DOMoveZ(transform.position.z + 2f, 2f).OnComplete(() =>
        //{
        //  Debug.Log(transform.position);
        //});

        //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2f), .1f);

    }

    public void MoveBack()
    {
        Vector3 temp = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2f);
        transform.position = temp;

        Quaternion tempQ = new Quaternion(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z, transform.rotation.w);
        transform.rotation = tempQ;
    }

    public void MoveRight()
    {
        //Vector3 temp = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
        //transform.position = temp;

        //Quaternion tempQ = new Quaternion(transform.rotation.x, transform.rotation.y + 90f, transform.rotation.z, transform.rotation.w);
        //transform.rotation = tempQ;

        transform.Rotate(new Vector3(0, 90, 0));
    }

    public void MoveLeft()
    {
        //Vector3 temp = new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z);
        //transform.position = temp;

        //Quaternion tempQ = new Quaternion(transform.rotation.x, transform.rotation.y - 90f, transform.rotation.z, transform.rotation.w);
        //transform.rotation = tempQ;

        transform.Rotate(new Vector3(0,-90,0));
    }

    public void Jump()
    {
        Vector3 temp = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z + 2f);
        transform.position = temp;
    }

    public void Press()
    {
        anim.SetBool("isPress", true);
    }

}