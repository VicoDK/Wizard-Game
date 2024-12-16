using UnityEngine;

public class spawnroom : MonoBehaviour
{
    public int pendir;
    private roomtemplates templates;
    private int rand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("library").GetComponent<roomtemplates>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (pendir)
        {
            case 1:
                rand = Random.Range(0,templates.bottomrooms.Length);
                Instantiate(templates.bottomrooms[rand]);
                // spawn a room with a bot door
                break;
            case 2:
                rand = Random.Range(0, templates.bottomrooms.Length);
                Instantiate(templates.toprooms[rand]);
                // spawn a room with a top door
                break;
            case 3:
                rand = Random.Range(0, templates.bottomrooms.Length);
                Instantiate(templates.leftrooms[rand]);
                // spawn a room with a left door
                break;
            case 4:
                rand = Random.Range(0, templates.bottomrooms.Length);
                Instantiate(templates.rightrooms[rand]);
                // spawn a room with a right door
                break;
        }
    }
}
