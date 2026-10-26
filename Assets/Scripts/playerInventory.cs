using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool LeftKey;
    public bool RightKey;
    void Start()
    {
        LeftKey = false;
        RightKey = false;
    }
}
