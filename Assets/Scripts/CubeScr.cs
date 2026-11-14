using Unity.VisualScripting;
using UnityEngine;

public class CubeScr : MonoBehaviour
{
    public Renderer Rn;
    public float Boundry;

    public AudioSource Ad;
    private void Awake()
    {
        Rn = GetComponent<Renderer>();
        Ad = GetComponent<AudioSource>();
        
    }
    private void Start()
    {
        Boundry = FindFirstObjectByType<GridManager>().width-0.3f;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)&& transform.position.z< Boundry)
        {
           
            MoveCube(new Vector3(0, 0, 1.1f));
            Ad.Play();
        }
        if(Input.GetKeyDown(KeyCode.S)&& transform.position.z >=1.1)
        {

            MoveCube(new Vector3(0, 0, -1.1f));
            Ad.Play();
        }
        if(Input.GetKeyDown(KeyCode.D) && transform.position.x < Boundry )
        {

          MoveCube(new Vector3(1.1f, 0, 0));
            Ad.Play();
        }
        if(Input.GetKeyDown(KeyCode.A) && transform.position.x >=1.1)
        {
            MoveCube(new Vector3(-1.1f, 0, 0));
            Ad.Play();
        }
    }
    public void MoveCube(Vector3 direction)
    {

        Vector3 nextPosition = transform.position + 1f * direction;

        Collider[] hits = Physics.OverlapSphere(nextPosition, 0.1f);

        foreach (Collider hit in hits)
        {
            if (hit.gameObject != gameObject && hit.GetComponent<CubeScr>() != null)
            {  
                return;
            }
        }
        transform.position = nextPosition;
    }
}
