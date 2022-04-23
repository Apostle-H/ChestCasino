using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    private IChest CreateChest()
    {
        float chestRandomizer = Random.Range(0f, 1f);
        IChest resultChest;
        
        if (chestRandomizer < .7f)
        {
            int maxLootAmount = ItemsPool.Instance.GetLength() > 4 ? 5 : ItemsPool.Instance.GetLength();
            int lootAmount = Random.Range(1, maxLootAmount);
            resultChest = new SimpleChest(lootAmount);
        }
        else if (chestRandomizer < .9f)
        {
            resultChest = new HalfVoidChest();
        }
        else
        {
            resultChest = new VoidChest();
        }


        return resultChest;
    }

    public void OpenNewChest()
    {
        CreateChest().Open();

        JSONSaveLoad.WriteInventoryJSON();
        JSONSaveLoad.WritePoolJSON();
    }

}
