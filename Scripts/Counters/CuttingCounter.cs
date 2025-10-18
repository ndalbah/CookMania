using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    public static void ResetStaticData()
    {
        //OnAnyCut
    }

    public event EventHandler OnCut;

    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;
    public override void Interact(Player player)
    {
        // counter empty
        if (!HasKitchenObject())
        {
            // player carrying object
            if (player.HasKitchenObject())
            {
                // check if object is in any recipe (object that can be cut)
                if(HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
                
            }
            else
            {
                // player not carrying anything => do nothing
            }
        }
        else
        {
            // counter already has KitchenObject
            if (player.HasKitchenObject())
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

    public override void InteractAlternate(Player player)
    {
        // there is an object on the cutting counter and it can be cut
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            OnCut?.Invoke(this, EventArgs.Empty);

            // find output for current object on cutting counter
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            
            GetKitchenObject().DestroySelf();

            // spawn sliced object (output)
            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
        }
    }

    // check if object is cuttable (if object is an input in any recipe)
    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return true;
            }
        }

        return false;
    }

    // function to sort through the cuttingRecipeSO array to find which object is on the counter
    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach(CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if(cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO.output;
            }
        }

        return null;
    }
}
