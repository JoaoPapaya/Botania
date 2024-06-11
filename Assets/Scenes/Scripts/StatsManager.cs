using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class StatsManager : MonoBehaviour
{
    [SerializeField] public PlayerMovement stats;



    public TMP_Text h2o;
    public TMP_Text co2;
    public TMP_Text atp;

    public int water;
    public int carbon;
    public int energy;

    public static StatsManager Instance;

    private void Start()
    {
        water = 0; 
        carbon = 0;
        energy = 10;
    }

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        h2o.text = "H2O: " + water.ToString();
        co2.text = "CO2: " + carbon.ToString();
        atp.text = "Energia: " + energy.ToString();

    }
}
