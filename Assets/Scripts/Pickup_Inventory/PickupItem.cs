using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [Header("Item Info")]
    public int ItemPrice;
    public int ItemRadius;
    public string ItemTag;
    private GameObject ItemToPick;

    [Header("Player Info")]
    //change this part if the player name changed
    public PlayerController PlayerController;
    
}
