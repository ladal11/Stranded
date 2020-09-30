using UnityEngine;

public class PlayerItemManager : MonoBehaviour
{
    public GameObject itemPositionMarker;
    public Transform[] selectionSlots = new Transform[10];
    private Player player;
    private GameObject itemGO;

    public Transform selectionIcon;

    public Item currentItem;
    public int itemSelection = 0;
    public Item[] selectionBar = new Item[10];
    



    private Item selectedItem
    {
        get
        {
            return selectionBar[itemSelection];
        }
    }

    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
    }

    private void Start()
    {
        InitializeSelectionBar();

        // for dev purposes
        ItemData shovelItemData = GetItemData(ItemName.Shovel);
        Item debugShovel = new Item(ItemName.Shovel, shovelItemData.itemType, shovelItemData.gameState, shovelItemData.prefabPath, shovelItemData.iconPath);
        AddItemToSelectionBar(debugShovel, 1);

        ItemData primitiveAxeItemData = GetItemData(ItemName.PrimitiveAxe);
        Item debugPrimitiveAxe = new Item(ItemName.PrimitiveAxe, primitiveAxeItemData.itemType, primitiveAxeItemData.gameState, primitiveAxeItemData.prefabPath, primitiveAxeItemData.iconPath);
        AddItemToSelectionBar(debugPrimitiveAxe, 2);

    }

    private void Update()
    {
        CheckChangeItem();
    }
    public ItemData GetItemData(ItemName _item)
    {
        return ItemDatabase.items[_item];
    }

    // This logic is broken but will do for now. We need to not only check for a scroll wheel to assert if we should change item. (ex: Start of game, picking up new object, num keys, etc.)
    private void CheckChangeItem()
    {
        float _scrollingInput = Input.GetAxisRaw("Mouse ScrollWheel");
        if (_scrollingInput != 0)
        {
            ScrollItemSelection((int)_scrollingInput);

            // Need to be removed
            Debug.Log(itemSelection);

            if (selectedItem != currentItem)
            {
                ChangeItem(selectedItem);
            }
        }
    }


    public void ChangeItem(Item _item)
    {
        if (itemGO != null)
        {
            Destroy(itemGO);
        }


        player.currentGameState = _item.gameState;

        if (_item.prefabPath != "")
        {
            itemGO = Instantiate(Resources.Load(_item.prefabPath), itemPositionMarker.transform) as GameObject; 
        }
        currentItem = _item;
    }

    private void ScrollItemSelection(int scrollValue)
    {
        int minSelectionValue = 0;
        int maxSelectionValue = 9;

        int tempSelection = itemSelection + scrollValue;

        if (tempSelection > maxSelectionValue)
        {
            itemSelection = minSelectionValue;
        }
        else if (tempSelection < minSelectionValue)
        {
            itemSelection = maxSelectionValue;
        }
        else
        {
            itemSelection = tempSelection;
        }

        selectionIcon.position = selectionSlots[itemSelection].position;

    }

    private void InitializeSelectionBar()
    {
        for (int i = 0; i < selectionBar.Length; i++)
        {
            selectionBar[i] = Item.Nothing;
        }

    }

    public void AddItemToSelectionBar(Item _item)
    {
        for (int i = 0; i < 10; i++)
        {
            if (selectionBar[i] == Item.Nothing)
            {
                selectionBar[i] = _item;
            }
        }
    }

    // Debug purpose REMOVE!
    public void AddItemToSelectionBar(Item _item, int slot)
    {
        if (slot < 1 || slot > 10 )
        {
            Debug.Log("Slot index out of bound");
            return;
        }
        selectionBar[slot - 1] = _item;
    }

}
