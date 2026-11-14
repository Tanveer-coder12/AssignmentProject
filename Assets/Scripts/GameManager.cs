using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject cubePrefab;

    private Tiles selectedTile;
    public int cubenum;
    public List<Cubemanager> cubeslist = new List<Cubemanager>();

    public GameObject HelpPanel;
    
    private void Awake()
    {
        Instance = this;
    }

    public void SelectTile(Tiles tile)
    {
       
        selectedTile = tile;
    }

    private void Start()
    {
        HelpPanel.SetActive(false);
    }
    void Update()
    {
        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0f) // forward
        {
            cubenum = 1;
           
        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f) // backwards
        {
            cubenum = 2;
        }
        


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (selectedTile != null)
            {
                cubeSpawn();
               
                selectedTile = null; // Deselect the tile after spawning the cube
            }
        }
    }

    public void cubeSpawn()
    {
        GameObject cubes = Instantiate(cubePrefab, selectedTile.centrepos+Vector3.up*0.5f, Quaternion.identity);
        

        cubes.GetComponent<Renderer>().material = cubeslist[cubenum].TileMaterials[0];
        cubenum= 0;

        selectedTile.Deselect();
    }
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void HelpPanelMethod()
    {
        HelpPanel.SetActive(true);
    }
    public void Back_Button_In_Help()
    {
        HelpPanel.SetActive(false);
    }
    public void BackButton()
    {
        SceneManager.LoadScene("StartGameScene");
       
    }
}