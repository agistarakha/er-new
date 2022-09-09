using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public List<GameObject> platforms;

    private SpriteRenderer lastGeneratedPlatform;

    // Start is called before the first frame update
    void Start()
    {
        lastGeneratedPlatform = null;
        GeneratesPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        if (lastGeneratedPlatform != null)
        {
            float offset = lastGeneratedPlatform.transform.position.x +  lastGeneratedPlatform.size.x;
            //Debug.Log(lastGeneratedPlatform.size.x / 2);
            //Debug.Log(transform.position.x - offset);
            if (transform.position.x - offset >= 2f)
            {
               GeneratesPlatform();
            }

        }
    }

    private void GeneratesPlatform(float offset = 0)
    {
        Vector3 offsetVector = new Vector3(offset, 0, 0);
        GameObject platformPrefab = platforms[Random.Range(0, platforms.Count)];
        GameObject platform = Instantiate(platformPrefab, transform.position + offsetVector, Quaternion.identity);

        lastGeneratedPlatform = platform.GetComponent<SpriteRenderer>();
    }
}
