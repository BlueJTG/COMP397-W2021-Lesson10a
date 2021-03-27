using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelController : MonoBehaviour
{
    [Header("World Size")]
    public float tileLength;
    public float tileWidth;
    public List<GameObject> tilePrefab;
    public List<GameObject> activeTiles;

    [Header("Navigation")]
    private NavMeshSurface navMeshSurface;

    void Awake()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
        BuildWorld();
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshSurface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildWorld()
    {
        for(int width = 0; width < tileWidth; width++)
        {
            for(int length = 0; length < tileLength; length++)
            {
                var randomTileIndex = Random.Range(0, tilePrefab.Count);
                var randomTilePosition = new Vector3(width * 16, 0.0f, length * 16);
                var randomTileRotation = Random.Range(0, 4) * 90.0f;
                var randomTile = Instantiate(tilePrefab[randomTileIndex], randomTilePosition, Quaternion.Euler(0.0f, randomTileRotation, 0.0f));
                randomTile.transform.parent = this.transform; //make this GameObject the Level Parent
                activeTiles.Add(randomTile);
            }
        }
    }
}
