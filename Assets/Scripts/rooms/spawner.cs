using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cameraposition();
        for (int i = 0; i <= 4; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void cameraposition()
    {
        camera.transform.position = this.transform.position + new Vector3(0,0,-10);
    }
}
