using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Caravanne")]
    public Transform[] StartPointsForCart;
    public Transform EndPointForCart;
    public GameObject CartPrefab;
    public GameObject CartHolder;
    public List<GameObject> CartInstantiate;

    [Header("Ressource")]
    public List<Transform> ResourceSpawnPoints;
    public List<GameObject> ResourcesPrefab;
    public int ResourcesValueOnMap;
    Dictionary<string, List<GameObject>> dictionaryRessources = new Dictionary<string, List<GameObject>>();
    public bool LegendaryAlreadyOnMap;

    [Header("Monster")]
    public List<Transform> MonsterSpawnPoints;
    public List<GameObject> MonstersPrefab;
    public GameObject MonsterHolder;

    [Header("Player")]
    public Transform PlayerSpawnPoint;

    public void SpawnCarts()
    {
        CartInstantiate = new List<GameObject>();
        foreach (var point in StartPointsForCart)
        {
            var cart = SpawnUnitAt(CartPrefab, point, CartHolder.transform);
            cart.GetComponent<MoveCart>().Goal = EndPointForCart;
            CartInstantiate.Add(cart);
        }
    }

    public void SpawnMonsters()
    {
        //Sortir ça ailleurs, car on va en avoir besoin tout le long de la game?
        var MonsterToSpawn = GetRandomElementOfList(MonstersPrefab);
        var SpawnPoint = GetRandomElementOfList(MonsterSpawnPoints);
        var monstergO = SpawnUnitAt(MonsterToSpawn, SpawnPoint, MonsterHolder.transform);
        monstergO.GetComponent<MonsterNavMeshMovment>().SpawnPoint = SpawnPoint.position;
        //monstergO.GetComponent<MonsterNavMeshMovment>().Target = GetRandomElementOfList(CartInstantiate).transform;
    }

    public void SpawnResources(int scoreMax)
    {
        //get all element par rareté
        //spawn random de chaque élement, d'abord 1 légendaire (préparer des sapwn spécifique?)
        //puis les autres etc etc, on garde trace de leur valeur, et ont compléte j'usqua avoir >= GeneralScoreMax?
       
        foreach (var resource in ResourcesPrefab)
        {
            var lootInfo = resource.GetComponent<Loot>();
            if (!dictionaryRessources.Keys.Contains(lootInfo.lootRarity.ToString()))
            {
                dictionaryRessources.Add(lootInfo.lootRarity.ToString(), new List<GameObject>(){ resource });
            }
            else
            {
                dictionaryRessources[lootInfo.lootRarity.ToString()].Add(resource);
            }
        }

        //Test
        int nbL = 0;
        int nbE = 0;
        int nbR = 0;
        int nbU = 0;
        int nbC = 0;
        //
        while (ResourcesValueOnMap < scoreMax)
        {
            var random = Random.Range(0, 101);
            if (random <= 5 && !LegendaryAlreadyOnMap)
            {
                SpawnRarityItem("Légendaire");
                LegendaryAlreadyOnMap = true;
                nbL++;
            }
            else if (random <= 10)
            {
                SpawnRarityItem("Epique");
                nbE++;
            }
            else if (random <= 15)
            {
                SpawnRarityItem("Rare");
                nbR++;
            }
            else if (random <= 40)
            {
                SpawnRarityItem("Uncommon");
                nbU++;
            }
            else
            {
                SpawnRarityItem("Common");
                nbC++;
            }
        }
        Debug.Log("nb L : " + nbL + " nb E : " + nbE + " nb R : " + nbR + " nb U : " + nbU + " nb C : " +nbC);
        Debug.Log("total : " + (nbC+nbL+nbE+nbR+nbU));
    }


    private void SpawnRarityItem(string RarityItem)
    {
        var liste = dictionaryRessources[RarityItem];
        var lootPrefab = GetRandomElementOfList(liste);
        ResourcesValueOnMap += lootPrefab.GetComponent<Loot>().ValueGainOnLooted;
        //Récupérer aussi ceux des coffres! ou alors on fait que les coffres ont un loot qui ouvre un pael pour loot façon rpg (wow)
        var listSpawnPointAvailable =
            ResourceSpawnPoints.Where(x => x.GetComponent<SpawnPointResource>().isUsed == false).ToList();
        
        var spawnPoint = GetRandomElementOfList(listSpawnPointAvailable);
        spawnPoint.GetComponent<SpawnPointResource>().isUsed = true;
        Instantiate(lootPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
    }

    private T GetRandomElementOfList<T>(List<T> list)
    {
        var rand = Random.Range(0, list.Count);
        return list[rand];
    }

    private GameObject SpawnUnitAt(GameObject prefabToInstanciate, Transform SpawnPoint, Transform holder)
    {
        var gO = Instantiate(prefabToInstanciate, SpawnPoint.position, Quaternion.identity, holder);
        return gO;
    }
}