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

        if (types == null || types.Length == 0)
        {
            return GetRandomNormalType();
        }
        NormalItem.eNormalType result;
        do
        {
            result = GetRandomNormalType();
        }
        while (Array.IndexOf(types, result) >= 0);

        return result;
    }
}
