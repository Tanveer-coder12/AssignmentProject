using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GridManager : MonoBehaviour
{
   
    public int width = 5;
    public int height = 5;

   
    public float cellSize = 1f;
    [SerializeField] private GameObject tilePrefab;
   
    
    private void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            
            for (int z = 0; z < height; z++)
            {
                
                Vector3 position = new Vector3(x * cellSize,0.1f,z * cellSize);

                GameObject tile = Instantiate(tilePrefab,position,tilePrefab.transform.rotation);
                
                tile.transform.parent = transform; // Set the grid manager as the parent of the tile
                

            }
          
        }
    }

   
}
