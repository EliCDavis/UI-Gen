using UnityEngine;
using System.IO;
using System;

public interface IElement
{

    GameObject Build(GameObject parent, AssetBundle assetBundleInstance);

}