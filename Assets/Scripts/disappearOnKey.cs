using UnityEngine;

public class DisappearOnKey : MonoBehaviour
{
    [SerializeField] GameObject thingToDisappear;
    public GameObject player;
    private PlayerInventory playerInventory;
    public bool disappearOnLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (disappearOnLeft)
        {
            if(playerInventory.LeftKey == false)
            {
                thingToDisappear.SetActive(true);
            } else
            {
                thingToDisappear.SetActive(false);
            }
        } else
        {
            if(playerInventory.RightKey == false)
            {
                thingToDisappear.SetActive(true);
            } else
            {
                thingToDisappear.SetActive(false);
            } 
        }
       
    }

}