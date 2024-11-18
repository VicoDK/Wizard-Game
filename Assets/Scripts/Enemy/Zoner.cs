using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;


public class Zoner : MonoBehaviour
{
    public GameObject Spikes;
    public Transform player = GameObject.Find("Player1Body").transform;


    private void Start()
    {

        Transform player = GameObject.Find("Player1Body").transform;
        GameObject Spike = Instantiate(Spikes, player, true);
        Spike.GetComponent<SpikeZone>().TurnOn();


    }


















}
