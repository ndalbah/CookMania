using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // counter empty
            if (player.HasKitchenObject())
            {
                // player carrying object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // player not carrying anything => do nothing
            }
        }
        else
        {
            // counter already has KitchenObject
            if(player.HasKitchenObject())
            {
                // player carrying object => do nothing
            }
            else
            {
                // player not carrying anything => give player object
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
