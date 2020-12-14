using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedFraction = 1f;
    
    private Camera cam;
    private Vector3 posToMove;
    private Mover _mover;

    void Start()
    {
        cam = Camera.main;
        _mover = GetComponent<Mover>();
    }
    void Update()
    {
        InteractWithMovement();
    }

    private void InteractWithMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                _mover.MoveTo(hit.point, speedFraction);
            }
        }
    }
    private Ray GetMouseRay()
    {
        return cam.ScreenPointToRay(Input.mousePosition);
    }
}
