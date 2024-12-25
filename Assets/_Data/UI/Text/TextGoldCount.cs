using UnityEngine;

public class TextGoldCount : TextAbstact
{
    protected virtual void Update()
    {
        this.LoadGoldCount();
    }

    protected virtual void LoadGoldCount()
    {
        ItemInventory item = InventoriesManager.Instance.Currency().FindItem(ItemCode.Gold);
        this.textPro.text = "$" + item.itemCount.ToString();
    }
}
