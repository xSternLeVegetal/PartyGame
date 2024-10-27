using Photon.Pun;
using TMPro;
using UnityEngine;

public class InterractionPlayerManager : MonoBehaviourPun
{
    public Transform PlayerCameraTransform;
    private RaycastHit Hit = new RaycastHit();
    //private GameObject PreviousObjectHitted;
    [SerializeField] public LayerMask LayerMask;
    public TextMeshProUGUI InterractionUI;


    public void Start()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        InterractionUI = GameObject.Find("Interraction UI").GetComponent<TextMeshProUGUI>();
        InterractionUI.enabled = false;
    }

    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        Vector3 direction = (PlayerCameraTransform.position + PlayerCameraTransform.forward) -
                            PlayerCameraTransform.position;
        //Vector3 pointC = PlayerCameraTransform.position + (direction.normalized * 2);
        Ray rayon = new Ray(PlayerCameraTransform.position /* + PlayerCameraTransform.up*/, (direction.normalized * 2));

        //Debug.DrawRay(rayon.origin, rayon.direction * 3, Color.black, 5f);
       
        if (Physics.Raycast(PlayerCameraTransform.position, PlayerCameraTransform.forward, out Hit, 3f, LayerMask))
        {
            var gO = Hit.transform.gameObject;
            if (gO.GetComponent<InterractableBase>())
            {
                var InterractableBase = gO.GetComponent<InterractableBase>();
                //var gOType = InterractableBase.InteractionType;
                //switch (gOType)
                //{
                //    case InteractionType.Pnj:
                //    case InteractionType.Action:
                //        Debug.Log(gO.name);
                //        break;
                //    case InteractionType.Loot:
                //        var loot = (Loot) InterractableBase;
                //        Debug.Log(loot.LootName);
                //        break;
                //    default:
                //        break;
                //}

                //Icic pop de l'ui pour interragir avec E , et le Action est lié au fait de faire E
                InterractionUI.enabled = true;
            }

        }
        else
        {
            HideInterractionUi();
        }

        if (Hit.collider != null && Input.GetKeyDown(KeyCode.E))
        {
            //    Debug.Log(Hit.transform.gameObject.name);
            Hit.transform?.gameObject.GetComponent<InterractableBase>().Action(this.gameObject);
        }
    }

    private void HideInterractionUi()
    {
            InterractionUI.enabled = false;
            //PreviousObjectHitted = null;
    }
}