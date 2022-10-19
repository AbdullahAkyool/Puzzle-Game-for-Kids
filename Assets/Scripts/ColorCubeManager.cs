using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ColorCubeManager : MonoBehaviour
{
    public PlayerMovement _PlayerMovement;
    public List<GameObject> ColorCubes;
    public int activatedCubes=0;

    public Button NextButton;
    

    void Start()
    {
        _PlayerMovement = FindObjectOfType<PlayerMovement>();
        foreach (var item in GameObject.FindGameObjectsWithTag("BlueCube"))
        {
            ColorCubes.Add(item);
        }
    }
    void Update()
    {
        if (activatedCubes == ColorCubes.Count)
        {
            _PlayerMovement.Dance();
            NextButton.gameObject.SetActive(true);
        }
    }

    public void ChangeCubeColor(GameObject temp)
    {
        temp.GetComponent<MeshRenderer>().material.color=Color.green;
        activatedCubes++;
    }
}
