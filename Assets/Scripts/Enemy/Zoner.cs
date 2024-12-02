using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
public class Zoner : MonoBehaviour
{
    public GameObject Spikes;


    private void Awake()
    {
        StartCoroutine(attackmode());



    }

    public IEnumerator attackmode()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(Create());
        yield return new WaitForSeconds(6);
        StartCoroutine(attackmode());
    }




    public IEnumerator Create()
    {
        yield return new WaitForSeconds(2f);

        Transform player = GameObject.Find("Player1Body").GetComponent<Transform>();
        GameObject spike = Instantiate(Spikes, player.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        spike.GetComponent<SpikeZone>().Turnon();
       

    }

















}
