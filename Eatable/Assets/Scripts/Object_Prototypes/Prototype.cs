using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "Prototype", menuName = "Prototype")]

//SO ��� �������� ��������� �������� (���-��������-���)
public class Prototype : ScriptableObject
{
    public string objectName;

    public AssetReference assetReference;

    public enum ObjectType
    {
        eatable,
        uneatable
    }

    public ObjectType objectType;
}
