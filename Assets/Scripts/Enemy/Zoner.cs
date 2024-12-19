using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
public class Zoner : MonoBehaviour
{
    public GameObject swamp;
    public GameObject Spikes;
    private Animator animator;
    GameObject spike;


    private void Awake()
    {
        StartCoroutine(attackmode());
        animator = GetComponent<Animator>();



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
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist < 7) 
        {
            int Nummer = Random.Range(1, 3);
            switch (Nummer)
            {
                case 1:
                    spike = Instantiate(Spikes, player.position, Quaternion.identity);
                    animator.SetTrigger("Attack");
                    yield return new WaitForSeconds(0.1f);
                    spike.GetComponent<SpikeZone>().Turnon();
                    yield return new WaitForSeconds(1.1f);
                    spike.GetComponent<PolygonCollider2D>().enabled = false;
                    spike.GetComponent<PolygonCollider2D>().enabled = true;
                    animator.SetTrigger("Attack");

                    break;
                case 2:
                    spike = Instantiate(swamp, player.position, Quaternion.identity);
                    animator.SetTrigger("Attack");
                    yield return new WaitForSeconds(0.1f);
                    animator.SetTrigger("Attack");
                    yield return new WaitForSeconds(5.9f);
                    Destroy(spike);
                    break;
            }
        }
    }
}
