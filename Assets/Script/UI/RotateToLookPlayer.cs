using UnityEngine;

public class RotateToLookPlayer : MonoBehaviour
{
    public Camera PlayerCamera;
    // Start is called before the first frame update
    //void Start()
    //{
    //    //var GO = FindObjectsByType<PlayerManager>(FindObjectsSortMode.None);
    //    var GO = FindObjectOfType<PlayerManager>();
    //    PlayerCamera = GO.MyCamera;
    //}

    void OnEnable()
    {
        var GO = FindObjectOfType<PlayerInputManager>();
        PlayerCamera = GO.MyCamera;
        this.transform.LookAt(PlayerCamera.transform);
        this.transform.Rotate(Vector3.up, 180);
    }
    
    //// Update is called once per frame
    //void Update()
    //{
    //    this.transform.LookAt(PlayerCamera.transform);
    //    this.transform.Rotate(Vector3.up,180);
    //}
}
