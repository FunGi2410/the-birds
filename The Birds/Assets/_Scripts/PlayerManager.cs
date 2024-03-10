using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Object cards sellect
    [SerializeField] private List<GameObject> birdCardCollection;
    [SerializeField] private Objects_SO birdCardCollectionData;

    private void Start()
    {
        this.birdCardCollection = this.birdCardCollectionData.GetAllObjectsData();
    }

    public void UnlockNewPlantCard(int indexPlantCard)
    {
        this.birdCardCollection[indexPlantCard].GetComponent<CardSelect>().IsUnlocked = true;
    }
}
