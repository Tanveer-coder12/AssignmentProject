using UnityEngine;

public class Tiles : MonoBehaviour
{
    public SpriteRenderer TileSpriteRender;
    public bool IsSelected;
    public Vector3 centrepos;

    void Start()
    {
        TileSpriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        IsSelected = true;

        centrepos = TileSpriteRender.bounds.center;

        TileSpriteRender.color = Color.green;

        GameManager.Instance.SelectTile(this);
    }

    public void Deselect()
    {
        IsSelected = false;
        TileSpriteRender.color = Color.white;
    }
}