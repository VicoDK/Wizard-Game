using UnityEngine;

public class Cam : MonoBehaviour
{
    Transform Player1;
    Transform Player2;

    public float min = 4.5F;
    public float max = 8F;


    void Update()
    {

        if (Player1 == null||Player2 == null)
        {
            Player1 = GameObject.Find("Player1Body").transform;
            Player2 = GameObject.Find("Player2Body").transform;
        }
        
        this.transform.position = new Vector3((Player2.position.x + Player1.position.x)/2, (Player2.position.y + Player1.position.y)/2, -100);
        
        if ((Vector3.Distance(Player1.position, Player2.position)/2)-2 < 4.5)
        {
            this.GetComponent<Camera>().orthographicSize = min;
        }
        else  if ((Vector3.Distance(Player1.position, Player2.position)/2)-2 > 8)
        {
            this.GetComponent<Camera>().orthographicSize =max;
        }
        else 
        {
            this.GetComponent<Camera>().orthographicSize = (Vector3.Distance(Player1.position, Player2.position)/2)-2;
        }
    }

}
