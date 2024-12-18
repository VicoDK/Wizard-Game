using UnityEngine;

public class Cam : MonoBehaviour
{
    Transform Player1;
    Transform Player2;

    void Start()
    {
        Player1 = GameObject.Find("Player1Body").transform;
        Player2 = GameObject.Find("Player2Body").transform;

    }

    void Update()
    {
        this.transform.position = new Vector3((Player2.position.x + Player1.position.x)/2, (Player2.position.y + Player1.position.y)/2, -100);
        this.GetComponent<Camera>().orthographicSize = (Player2.position.x - Player1.position.x)/2;
    }

}
