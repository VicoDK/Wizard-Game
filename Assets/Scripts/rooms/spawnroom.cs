using UnityEngine;

public class spawnroom : MonoBehaviour
{
    public int pendir;
    private roomtemplates templates;
    private int rand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("spawn", 0.1f);
        templates = GameObject.FindGameObjectWithTag("library").GetComponent<roomtemplates>();

        
    }

    void spawn()
    {
        switch (pendir)
        {
            case 1:
                rand = Random.Range(0, templates.bottomrooms.Length);
                Instantiate(templates.bottomrooms[rand], transform.position, transform.rotation);
                // spawn a room with a bot door
                Destroy(this.gameObject);
                break;
            case 2:
                rand = Random.Range(0, templates.bottomrooms.Length);
                Instantiate(templates.toprooms[rand], transform.position, transform.rotation);
                // spawn a room with a top door
                Destroy(this.gameObject);
                break;
            case 3:
                rand = Random.Range(0, templates.bottomrooms.Length);
                Instantiate(templates.leftrooms[rand], transform.position, transform.rotation);
                // spawn a room with a left door
                Destroy(this.gameObject);
                break;
            case 4:
                rand = Random.Range(0, templates.bottomrooms.Length);
                Instantiate(templates.rightrooms[rand], transform.position, transform.rotation);
                // spawn a room with a right door
                Destroy(this.gameObject);

                break;
        }
    }
    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
