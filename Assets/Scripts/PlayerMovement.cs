using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Audio;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    List<IEnumerator> MoveCards = new List<IEnumerator>();

    public Animator anim;
    public AudioSource soundEffect;

    public ColorCubeManager _ColorCubeManager;
    public GameObject temp;

    public bool isWalkable, canJump;
    private RaycastHit hit,hit2;
    public GameObject rayCenter;
    public void Walkable()
    {
        Physics.Raycast(rayCenter.transform.position, Vector3.down, out hit, 10);
        {
          Debug.DrawRay(rayCenter.transform.position, Vector3.down * hit.distance, Color.red);
          Debug.Log(hit.distance);
        }
      
       
        if (hit.collider == null || hit.distance < 1)
        {
           isWalkable = false;
        }
        if(hit.collider == null)
        {
            canJump = false;
        }
        else
        {
           isWalkable = true;           
           canJump = true;
        }
        
    }

    private void Update()
    {
        Walkable();
    }

    public void PlayMoves()
    {
        StartCoroutine(_PlayMoves());
    }

    IEnumerator _PlayMoves()
    {
        foreach (var item in MoveCards)
        {
            yield return item;
        }
    }

    public void MoveDirect()
    {
        MoveCards.Add(MoveForward());
        Debug.Log("İLERİ HAREKET");
    }
    public void MoveRight()
    {
        MoveCards.Add(RotateRight());

        Debug.Log("SAĞA HAREKET");
    }
    public void MoveLeft()
    {
        MoveCards.Add(RotateLeft());

        Debug.Log("SOLA HAREKET");
    }
    public void Jump()
    {
        MoveCards.Add(Jumpp());
        Debug.Log("ZIPLAMA");
    }
    public void Press()
    {
        //StartCoroutine(press());

        MoveCards.Add(press());

        Debug.Log("PRESS");
    }


    // COROUTİNES

    public IEnumerator  MoveForward()
    {
        anim.SetBool("isWalk", true);
        if (isWalkable)
        {
            transform.DOMove( transform.position + (transform.forward * 2F),1.8F);
        }
        yield return new WaitForSeconds(1.5f);

        anim.SetBool("isWalk", false);
    }

    public IEnumerator RotateRight()
    {
        Vector3 newRotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90,
            transform.rotation.eulerAngles.z);
        transform.DORotate(newRotation, 1F).OnComplete(() =>
        {

        });

        yield return new WaitForSeconds(1.5f);
    }
    public IEnumerator RotateLeft()
    {
        Vector3 newRotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 90,
            transform.rotation.eulerAngles.z);
        transform.DORotate(newRotation, 1F).OnComplete(() =>
        {
          
        });

        yield return new WaitForSeconds(1.5f);
    }
    
    public IEnumerator  Jumpp()
    {
        anim.SetTrigger("isJumpp");
        if (canJump)
        {
            transform.DOMove(transform.position + (transform.forward * 2F + Vector3.up * 1F), .9F);
            //.OnComplete(() =>
            //{
            //  anim.SetBool("isJump", false);
            // });
        }
        //anim.SetBool("isJump", true);
        soundEffect.Play();
        yield return new WaitForSeconds(1.5f);
        
        //anim.SetBool("isJump", false);       
        soundEffect.Stop();

    }

    public IEnumerator press()
    {
        anim.SetBool("isPress", true);
        
        yield return new WaitForSeconds(1.2f);

        if (temp != null)
        {
            _ColorCubeManager.ChangeCubeColor(temp);
        }
        
        anim.SetBool("isPress", false);
    }

    public void Dance()
    {
        anim.SetInteger("FinishIndex", Random.Range(0,2));
        anim.SetBool("isFinish", true);
        
    } 
    public void Cry()
    {
        anim.SetBool("isCry",false);
    } 
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlueCube"))
        {
            temp = other.gameObject;
        }
    }


    // public IEnumerator moveDirect()
    // {
    //     anim.SetBool("isWalk", true);
    //
    //     Vector3 rightTarget = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 2f);
    //
    //     transform.DOLocalMove(rightTarget, 1.8f);
    //
    //     yield return new WaitForSeconds(1f);
    //
    //     anim.SetBool("isWalk", false);
    // }
    //
    // public IEnumerator moveBack()
    // {
    //     anim.SetBool("isWalk", true);
    //
    //     Vector3 rightTarget = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2f);
    //
    //     transform.DOMove(rightTarget, 1.8f);
    //
    //     yield return new WaitForSeconds(1f);
    //
    //     anim.SetBool("isWalk", false);
    // }
    //
    // public IEnumerator moveRight()
    // {
    //     Vector3 rightTarget = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z );
    //
    //     transform.DOMove(rightTarget, 1.8f);
    //     transform.DOLocalRotate(new Vector3(0, 90, 0), .3f, RotateMode.FastBeyond360);
    //     
    //     yield return new WaitForSeconds(1f);
    // }
    //
    // public IEnumerator moveLeft()
    // {
    //     Vector3 rightTarget = new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z);
    //
    //     transform.DOMove(rightTarget, 1.8f);
    //     transform.DOLocalRotate(new Vector3(0, -90, 0), .3f, RotateMode.FastBeyond360);
    //
    //
    //     yield return new WaitForSeconds(1f);
    // }

    /*
    public IEnumerator jump()
    {
        anim.SetBool("isJump", true);

        Vector3 rightTarget = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2f);
        soundEffect.Play();
        transform.DOJump(rightTarget,1f,1 ,.8f);
        soundEffect.Stop();

        yield return new WaitForSeconds(1f);

        anim.SetBool("isJump", false);
    }
    */
    
}
