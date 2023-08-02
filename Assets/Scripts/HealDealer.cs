using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDealer : MonoBehaviour
{
    [SerializeField] int heal = 20;


    public int GetHeal()
    {
        return heal;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
