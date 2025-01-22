using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject gas;

    public void Move(float movement)
    {
        transform.Translate(Vector3.back * movement);

        if (transform.position.z < -40)
        {
            gas.SetActive(false);
            transform.position = new Vector3(0, 0, 80);
            RoadManager.instance.lastRoad = this;
        }
    }

    public void SpawnGas()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        gas.transform.position = spawnPoints[randomIndex].transform.position;
        gas.SetActive(true); 
    }
}