using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
public class View
{
    private static AssetBundle assetBundleInstance = null;

    private static AssetBundle GetAssetBundleInstance()
    {
        if (assetBundleInstance == null)
        {
            assetBundleInstance = AssetBundle.LoadFromFile(Path.Combine("Assets/AssetBundles", "uiparts"));

            if (assetBundleInstance == null)
            {
                throw new Exception("Failed to load AssetBundle!");
            }
        }

        return assetBundleInstance;
    }

    private IElement root;

    public View(IElement root)
    {
        this.root = root;
    }

    public GameObject Build(Vector3 position, Vector3 rotation,  Vector2 dimensions) {
        GameObject canvas = GameObject.Instantiate(GetAssetBundleInstance().LoadAsset<GameObject>("Canvas"));
        canvas.transform.position = position;
        canvas.transform.eulerAngles = rotation;
        canvas.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, dimensions.x);
        canvas.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, dimensions.y);
        root.Build(canvas, GetAssetBundleInstance());
        return canvas;
    }

}