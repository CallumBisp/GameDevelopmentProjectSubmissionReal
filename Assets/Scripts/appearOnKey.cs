using UnityEngine;

public class AppearOnKey : MonoBehaviour
{
    [SerializeField] GameObject bridgeWalkable;
    [SerializeField] GameObject bridgeModel;
    public GameObject player;
    private PlayerInventory playerInventory;
    public bool AppearOnLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
       if(playerInventory.LeftKey == false)
        {
            bridgeWalkable.SetActive(false);
            bridgeModel.SetActive(false);
        } else
        {
            bridgeModel.SetActive(true);
            bridgeWalkable.SetActive(true);
        }
    }

}
