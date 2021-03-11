using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> colorWallsList = new List<GameObject>();
   public List<GameObject> templist = new List<GameObject>();
    [Space]
    public GameObject ColorWallPrefab;
    public int[] rotationData;
    public int random;
    public static Spawner instance;
    private void Awake()
    {
        if (instance== null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        //intialising 30 sets of colors and rotation given randomly.
        for (int i = 0; i < 30; i++)
        {
            random = Random.Range(0, rotationData.Length - 1);
            GameObject temp = Instantiate(ColorWallPrefab,colorWallsList[colorWallsList.Count-1].transform.position+ new Vector3(0,0,5f),Quaternion.Euler(0,0,rotationData[random]));
            temp.name = "Set " + i;
            colorWallsList.Add(temp);
        }
    }


    public void RePostionWalls()
    {
        for (int i = 0; i < colorWallsList.Count; i++)
        {
            //taking first 4 elements
            if (i<6)
            {
            GameObject firstIndex = colorWallsList[0];

               
                firstIndex.transform.position = colorWallsList[colorWallsList.Count - 1].transform.position + new Vector3(0, 0, 5);
                colorWallsList.Remove(firstIndex);
                colorWallsList.Add(firstIndex);
              
            }

            continue;
        }
    }

}
