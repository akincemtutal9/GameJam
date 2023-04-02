using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class WaveContent{
        [SerializeField] [NonReorderable] GameObject [] WaveSpawner;

        public GameObject[] GetMonsterSpawnList(){
            return WaveSpawner;
        }
    }
    [SerializeField][NonReorderable] WaveContent[] waves;
    private int currentWave = 0;
    public List<GameObject> spawnedObjects;
    float SpawnRange = 10;
    public int enemiesKilled;

    public GameObject WinCanvas;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave();
    }

    // Update is called once per frame
     void Update()
    {
        if (currentWave < waves.Length && Enemy.killCount >= waves[currentWave].GetMonsterSpawnList().Length){
            Enemy.killCount = 0;
            currentWave++;
            if (currentWave >= waves.Length) {
                Debug.Log("You won");
                StartCoroutine(winCanvas());
            } else {
                SpawnWave();
            }
        }
    }
    private void SpawnWave(){
        for(int i = 0; i < waves[currentWave].GetMonsterSpawnList().Length;i++){       
        Instantiate(waves[currentWave].GetMonsterSpawnList()[i],FindSpawnLocation(),Quaternion.identity);
        }
    }
    private Vector3 FindSpawnLocation(){
        Vector3 SpawnPos;
        float xLoc = Random.Range(-SpawnRange,SpawnRange) + transform.position.x;
        float zLoc = Random.Range(-SpawnRange,SpawnRange) + transform.position.z;
        float yLoc = transform.position.y;
    
        SpawnPos= new Vector3(xLoc,yLoc,zLoc);
    
        if(Physics.Raycast(SpawnPos,Vector3.down,5)){
            return SpawnPos;
        }   
        else{
          return FindSpawnLocation();
        }
    }

    private IEnumerator winCanvas(){
        yield return new WaitForSeconds(2f);
        WinCanvas.gameObject.SetActive(true);
    }

}
