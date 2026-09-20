using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Match3/Normal Item Skin", fileName = "NormalItemSkin", order = 0)]
public class NormalItemSkin : ScriptableObject
{
    [Serializable]
    public struct Skin
    {
        public NormalItem.eNormalType Type;
        public Sprite Sprite;
    }
    [SerializeField] private Skin[] skins;

    private Dictionary<NormalItem.eNormalType, Sprite> _cached;

    public Sprite GetSkin(NormalItem.eNormalType type)
    {
        if (_cached == null) BuildCached();
        return _cached.TryGetValue(type, out Sprite result) ? result : null;
    }

    private void BuildCached()
    {
        _cached = new Dictionary<NormalItem.eNormalType, Sprite>();
        if (skins == null) return;
        for (int i = 0; i < skins.Length; i++)
        {
            _cached[skins[i].Type] = skins[i].Sprite;
        }
    }

    private void OnDisable()
    {
        if (_cached != null)
            _cached.Clear();
    }
}