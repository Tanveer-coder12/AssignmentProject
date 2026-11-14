
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public SpriteRenderer TileSpriteRender;
    public bool IsSelected;
    public Vector3 centrepos;

    void Start()
    {
        TileSpriteRender = GetComponent<SpriteRenderer>();

        // Get the centre position of the tile
        centrepos = TileSpriteRender.bounds.center;
    }

    private void OnMouseDown()
    {
        if (IsSelected)
            return;

        IsSelected = true;

        // Highlight selected tile
        TileSpriteRender.color = Color.yellow;

        // Send this tile reference to GameManager
        GameManager.Instance.SelectTile(this);
    }

    public void Deselect()
    {
        IsSelected = false;

        // Reset tile color
        TileSpriteRender.color = Color.white;
    }
}
