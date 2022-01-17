using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private GameObject playerObj;
    public GameObject[] section;
    private GameObject[] generatedSections = new GameObject[3];
    private int generatedSectionsNum = 0;
    private int destroyedSectionsNum = 0;
    public int sectionNum;
    public int zPos = 0; 

    // Start is called before the first frame update
    void Start()
    {
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(GenerateSection());
    }

    // Update is called once per frame
    void Update()
    {
        float playerZpos = (playerObj.transform.position.z + 125.0f) - 50.0f * generatedSectionsNum;
        if (playerZpos >= 50.0f)
        {
            StartCoroutine(GenerateSection());
        }
        Debug.Log((playerObj.transform.position.z + 50.0f) - 50.0f * destroyedSectionsNum);
        if (((playerObj.transform.position.z + 50.0f) - 50.0f * destroyedSectionsNum) >= 100.0f)
        {
            StartCoroutine(DestroySection());
        }
    }

    IEnumerator GenerateSection()
    {
        sectionNum = Random.Range(0, 4);
        generatedSections[generatedSectionsNum % 3] = Instantiate(section[sectionNum % 2], 
            new Vector3(0, 0, zPos), 
            Quaternion.AngleAxis(sectionNum * 180, Vector3.up));
        generatedSectionsNum++;
        zPos += 50;
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator DestroySection()
    {
        Destroy(generatedSections[destroyedSectionsNum % 3]);
        destroyedSectionsNum++;
        yield return new WaitForSeconds(0.1f);
    }
}
