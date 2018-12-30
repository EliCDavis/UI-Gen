using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

namespace EliCDavis.UIGen
{

    public class SliderElement : IElement
    {
        private float min;

        private float max;

        private Action<float> onValueChanged;

        Func<float, string> formatter;

        public SliderElement(float min, float max, Action<float> onValueChanged) : this(min, max, onValueChanged, null)
        {
        }

        public SliderElement(float min, float max, Action<float> onValueChanged, Func<float, string> formatter)
        {
            this.min = min;
            this.max = max;
            this.onValueChanged = onValueChanged;
            this.formatter = formatter;
        }

        public GameObject Build(GameObject parent, AssetBundle assetBundleInstance)
        {
            GameObject ele = null;
            if (formatter == null)
            {
                ele = UnityEngine.Object.Instantiate(assetBundleInstance.LoadAsset<GameObject>("Slider"));
            }
            else
            {
                ele = UnityEngine.Object.Instantiate(assetBundleInstance.LoadAsset<GameObject>("Slider With Text"));
            }
            ele.transform.SetParent(parent.transform);

            Slider slider = ele.transform.Find("Slider 1").GetComponent<Slider>();
            slider.minValue = min;
            slider.maxValue = max;

            if (formatter == null)
            {
                var sliderEvent = new Slider.SliderEvent();
                sliderEvent.AddListener(new UnityAction<float>(onValueChanged));
                slider.onValueChanged = sliderEvent;
            }
            else
            {
                var formatEvent = new Slider.SliderEvent();
                formatEvent.AddListener(delegate (float input)
                {
                    ele.transform.Find("Text").GetComponent<Text>().text = formatter(input);
                    onValueChanged(input);
                });
                slider.onValueChanged = formatEvent;
            }

            return ele;
        }

    }

}