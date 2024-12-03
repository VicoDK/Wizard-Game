using UnityEngine;

public class WaveController : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject spawnBox;
    public int round;
    public float spawnTime;

    void Start()
    {
        Debug.Log("start");
        InvokeRepeating("WaveSpawn", spawnTime, spawnTime); //timer passer ikke 

    }

    public void WaveSpawn()
    {
        Debug.Log("Run");
        round++;
       for (int i = 0; i <= round; i++)
       {
            Instantiate(Enemy1, new Vector3(this.transform.position.x + Random.Range(-spawnBox.transform.localScale.x/2,spawnBox.transform.localScale.x/2), this.transform.position.y + Random.Range(-spawnBox.transform.localScale.y/2,spawnBox.transform.localScale.y/2), 0), Quaternion.identity);
            Instantiate(Enemy2, new Vector3(this.transform.position.x + Random.Range(-spawnBox.transform.localScale.x/2,spawnBox.transform.localScale.x/2), this.transform.position.y + Random.Range(-spawnBox.transform.localScale.y/2,spawnBox.transform.localScale.y/2), 0), Quaternion.identity);

       }

    }

}
