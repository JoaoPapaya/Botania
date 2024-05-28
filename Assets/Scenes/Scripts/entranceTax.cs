using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class entranceTax : MonoBehaviour
{


    [SerializeField] public PlayerMovement stats;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        stats.energia = stats.energia - 5;
        Destroy(this.gameObject);
    }
}
