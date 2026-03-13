using System;
using System.Collections.Generic;

Console.WriteLine("=== 인벤토리 테스트 ===");
Inventory inven = new(3);
inven.AddItem("검");
inven.AddItem("방패");
inven.AddItem("포션");

try
{
    inven.AddItem("활");
}
catch (Exception ex)
{
    Console.WriteLine($"[인벤토리 오류] {ex.Message}");
}

Console.WriteLine();
inven.ShowItems();

inven.RemoveItem("포션");

try
{
    inven.RemoveItem("도끼");
}
catch (Exception ex)
{
    Console.WriteLine($"[인벤토리 오류] {ex.Message}");
}

Console.WriteLine();
inven.ShowItems();