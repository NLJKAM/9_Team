using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public ItemData Data { get; private set; }

    public Item(ItemData data) => Data = data;

    public int Amount { get; private set; }

    // 이 속성에 접근 할 때 get에 람다식을 사용하여 항상 maxStack에 접근할 수 있게 함. (런타임 중에 바뀌어도 변경에 대응됨)
    public int MaxAmount => Data.maxStack;

    public bool IsMaxStack => Amount >= MaxAmount;

    public bool IsEmpty => Amount <= 0;

    public void ModifyAmount(int amount)
    {
        int newAmount = Amount + amount;
        if (MaxAmount >= newAmount)
            Amount += amount;
        else Amount += (MaxAmount - Amount);
    }
}
