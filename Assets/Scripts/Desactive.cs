using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactive : MonoBehaviour
{
    [SerializeField] private GameObject z;
   
    public void Desa(bool y)
    {
        if(y)
        {
            z.SetActive(false);
        }
    }
}
