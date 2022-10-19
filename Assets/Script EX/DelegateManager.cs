using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateManager : MonoBehaviour
{
    public delegate void DelegateDeneme();

    public DelegateDeneme _delegateDeneme;

    public void Delegate()
    {
        //Debug.Log("Delegate scriptine girildi");
        _delegateDeneme();
    }

    private void Update()
    {
        // _delegateDeneme();
    }
}
