using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemName
{
    Nothing,
    Shovel,
    PrimitiveAxe
}

public enum ItemType
{
    None,
    Tool,
    Weapon,
    FunctionalProp,
    DecorativeProp,
    Material,
    Equipment,
    Consumable,
    Other
}


public struct ItemData
{
    public ItemType itemType;
    public GameState gameState;
    public string prefabPath;
    public string iconPath;

    public ItemData(ItemType _itemType, GameState _gameState, string _prefabPath, string _iconPath)
    {
        itemType = _itemType;
        gameState = _gameState;
        prefabPath = _prefabPath;
        iconPath = _iconPath;
    }
}

public class ItemDatabase
{
    public static Dictionary<ItemName, ItemData> items = new Dictionary<ItemName, ItemData>();

    public static void CreateItemDatabase()
    {
        // Special case when holding nothing
        //items.Add(ItemName.Nothing, new ItemData(ItemType.None, GameState.Exploring, "", ""));

        // Terraforming items
        items.Add(ItemName.Shovel, new ItemData(ItemType.Other, GameState.Terraforming, "", ""));

        // Exploring items
        items.Add(ItemName.PrimitiveAxe, new ItemData(ItemType.Weapon, GameState.Exploring, "GameObjects/ItemPrefabs/basicAxeDebug1", "GameObjects/ItemIcons/AxeWithPalmLeavesOutline"));
    }

}

public class Item : IEquatable<Item>
{
    public ItemName name;
    public ItemType itemType;
    public GameState gameState;
    public string prefabPath;
    public string iconPath;

    public Item(ItemName _name, ItemType _itemType, GameState _gameState, string _prefabPath, string _iconPath)
    {
        name = _name;
        itemType = _itemType;
        gameState = _gameState;
        prefabPath = _prefabPath;
        iconPath = _iconPath;
    }

    public static Item Nothing
    {
        get
        {
            return new Item(ItemName.Nothing, ItemType.None, GameState.Exploring, "", "");
        }
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Item);
    }

    public bool Equals(Item _otherItem)
    {
        // If parameter is null, return false.
        if (ReferenceEquals(_otherItem, null))
        {
            return false;
        }

        // Optimization for a common success case.
        if (ReferenceEquals(this, _otherItem))
        {
            return true;
        }

        // If run-time types are not exactly the same, return false.
        if (GetType() != _otherItem.GetType())
        {
            return false;
        }

        // Return true if the fields match.
        // Note that the base class is not invoked because it is
        // System.Object, which defines Equals as reference equality.
        return name == _otherItem.name;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }

    public static bool operator ==(Item lhs, Item rhs)
    {
        // Check for null on left side.
        if (ReferenceEquals(lhs, null))
        {
            if (ReferenceEquals(rhs, null))
            {
                // null == null = true.
                return true;
            }

            // Only the left side is null.
            return false;
        }
        // Equals handles case of null on right side.
        return lhs.Equals(rhs);
    }
    public static bool operator !=(Item lhs, Item rhs)
    {
        return !(lhs == rhs);
    }
}

