using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;

public class Utils
{
    private static readonly NormalItem.eNormalType[] AllNormalTypes = (NormalItem.eNormalType[])Enum.GetValues(typeof(NormalItem.eNormalType));
    public static NormalItem.eNormalType GetRandomNormalType() => AllNormalTypes[URandom.Range(0, AllNormalTypes.Length)];

    public static NormalItem.eNormalType GetRandomNormalTypeExcept(NormalItem.eNormalType[] types)
    {
        List<NormalItem.eNormalType> list = AllNormalTypes.Cast<NormalItem.eNormalType>().Except(types).ToList();

        int rnd = URandom.Range(0, list.Count);
        NormalItem.eNormalType result = list[rnd];

        return result;
    }
}
