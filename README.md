# UI Gen

Procedurally create Canvas objects from code.

## Example

### Code

```c#
var onChange = delegate (float x) { Debug.Log(x); };
var formatValue = delegate (float x) { return x.ToString("0.00"); };
var onButtonPressed = delegate () { Debug.Log("button pressed"); };

var windowElements = new IElement[] {
    new SliderElement(0, 1, .5f, onChange, formatValue),
    new ButtonElement("Save", onButtonPressed),
};
var window = new Window("Set Value", windowElements);
var view = new View(window);
view.Build(Vector3.zero, Vector3.zero, new Vector2(1, 1.2f));
```

### Generates

![Cool](https://i.imgur.com/8e9yRWN.png)