using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private Transform terrainHolder;
    
    private List<GameObject> currentTerrains = new List<GameObject>();
    private Vector3 currentPosition = new Vector3(0,0,0);
    private void Start()
    {
        for(int i = 0; i <= maxTerrainCount; i++){
            SpawnTerrain(true);
        }
        maxTerrainCount = currentTerrains.Count;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SpawnTerrain(false);
        }
    }
    private void SpawnTerrain(bool isStart)
    {
        int whichTerrain = Random.Range(0, terrainDatas.Count);
        int terrainInSuccesion = Random.Range(1, terrainDatas[whichTerrain].maxInSuccesion);
        for(int i = 0; i < terrainInSuccesion; i++){
            GameObject terrain = Instantiate(terrainDatas[whichTerrain].terrain ,currentPosition,Quaternion.identity, terrainHolder);
            currentTerrains.Add(terrain);
            if (!isStart){
                if(currentTerrains.Count > maxTerrainCount){
                    Destroy(currentTerrains[0]);
                    currentTerrains.RemoveAt(0);
                }
            }
            currentPosition.y+=2;
        }
    }
}
