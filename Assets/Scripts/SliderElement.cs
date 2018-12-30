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

        private UnityAction<float> onValueChanged;

        public SliderElement(float min, float max, Action<float> onValueChanged)
        {
            this.min = min;
            this.max = max;
            this.onValueChanged = new UnityAction<float>(onValueChanged);
        }

        public GameObject Build(GameObject parent, AssetBundle assetBundleInstance)
        {
            GameObject ele = GameObject.Instantiate(assetBundleInstance.LoadAsset<GameObject>("Slider 2"));
            ele.transform.SetParent(parent.transform);

            Slider slider = ele.transform.Find("Slider 1").GetComponent<Slider>();
            slider.minValue = min;
            slider.maxValue = max;

            var sliderEvent = new Slider.SliderEvent();
            sliderEvent.AddListener(onValueChanged);
            slider.onValueChanged = sliderEvent;

            return ele;
        }

    }

}