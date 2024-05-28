using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class CollectedWater : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(this.gameObject);
    }

}
