using UnityEngine;
using EliCDavis.UIGen;

public class Demo : MonoBehaviour
{

    void Start()
    {
        var windowElements = new IElement[] {
            new SliderElement(0, 1, .5f, delegate (float x) { Debug.Log(x); }, delegate (float x) { return x.ToString("0.00"); }),
            new ButtonElement("Save", delegate () { Debug.Log("button pressed"); }),
        };
        var window = new Window("Set Value", windowElements);
        var view = new View(window);
        view.Build(Vector3.zero, Vector3.zero, new Vector2(1, 1.2f));
    }

}
