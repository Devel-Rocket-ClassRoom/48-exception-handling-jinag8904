
using System;
using System.Collections.Generic;

class Inventory
{
    int maxCapacity;
    List<string> items;

    public Inventory(int maxCapacity)
    {
        this.maxCapacity = maxCapacity;
        items = new List<string>(maxCapacity);
    }

    public void AddItem(string itemName)
    {
        // 용량 초과 시 예외 발생
        if (items.Count == maxCapacity) throw new InventoryFullException(maxCapacity, itemName);

        items.Add(itemName);
        Console.WriteLine($"아이템 '{itemName}' 추가됨");
    }

    public void RemoveItem(string itemName)
    {
        foreach (string item in items)
        {
            if (itemName == item)
            {
                items.Remove(itemName);
                Console.WriteLine($"아이템 '{itemName}' 제거됨");
                return;
            }
        }

        // 아이템 없으면 예외 발생
        throw new ItemNotFoundException(itemName);
    }

    public void ShowItems()
    {
        Console.Write("현재 인벤토리: ");

        foreach (var item in items)
        {
            Console.Write($"{item} ");
        }

        Console.WriteLine();
    }
}

class ItemNotFoundException : Exception
{
    public new string Message => $"아이템을 찾을 수 없습니다: {ItemName}";

    string ItemName { get; set; }

    public ItemNotFoundException(string itemName)
    {
        ItemName = itemName;
    }
}

class InventoryFullException : Exception
{
    public new string Message => $"인벤토리가 가득 찼습니다. (용량: {Capacity}, 아이템: {ItemName})";

    int Capacity { get; set; }
    string ItemName { get; set; }

    public InventoryFullException(int capacity, string itemName)
    {
        Capacity = capacity;
        ItemName = itemName;
    }
}