
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject cubePrefab;

    private List<Tiles> selectedTile = new List<Tiles>();

    public int cubenum;

    public List<Cubemanager> cubeslist = new List<Cubemanager>();

    public List<GameObject> spawnedCubes = new List<GameObject>();

    public GameObject HelpPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectTile(Tiles tile)
    {
        if (!selectedTile.Contains(tile))
        {
            selectedTile.Add(tile);
        }
    }

    public void RemoveTile(Tiles tile)
    {
        selectedTile.Remove(tile);
    }

    private void Start()
    {
        HelpPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            cubenum = 1;
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            cubenum = 2;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (selectedTile.Count > 0)
            {
                cubeSpawn();
            }
        }
    }

    public void cubeSpawn()
    {
        foreach (Tiles tile in selectedTile)
        {
            GameObject cubes = Instantiate(
                cubePrefab,
                tile.centrepos + Vector3.up * 0.5f,
                Quaternion.identity
            );

            cubes.GetComponent<Renderer>().material =
                cubeslist[cubenum].TileMaterials[0];

            spawnedCubes.Add(cubes);

            tile.Deselect();
        }

        selectedTile.Clear();

        cubenum = 0;
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
