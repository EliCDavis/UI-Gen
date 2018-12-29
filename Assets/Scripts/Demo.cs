using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{

    void Start()
    {
        var windowElements = new IElement[] {
            new TextElement("Help me"),
            new SliderElement(0, 1, delegate (float x) { Debug.Log(x); })
		};
        var window = new Window("test", windowElements);
        var view = new View(window);
        view.Build(Vector3.zero, Vector3.zero, new Vector2(2, 2));
    }

}
