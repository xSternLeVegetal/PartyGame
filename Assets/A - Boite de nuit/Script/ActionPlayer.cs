using UnityEngine;

public class ActionPlayer : MonoBehaviour
{
    [SerializeField]
    public RoleEnum roleUser;

    public void OnCollisionEnter(Collision collision)
    {
        //if (roleUser == RoleEnum.Any || collision.gameObject.GetComponent<PlayerManager>().PlayerInfo.Role == roleUser)
        //{
        //    collision.gameObject.GetComponent<PlayerManager>().actionJoueur += ActionAFaire;
        //}
    }

    public void ActionAFaire()
    {
        Debug.Log("Coucou");
        //Afficher le truc de l'action et lancer le mini jeux
    }

}
