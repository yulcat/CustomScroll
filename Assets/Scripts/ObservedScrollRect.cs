using System;
using UnityEngine;
using UnityEngine.UI;

namespace RectTest
{
    [AddComponentMenu("UI/Observed Scroll Rect", 37)]
    [SelectionBase]
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    public class ObservedScrollRect : ScrollRect
    {
        public static event Action<ObservedScrollRect> OnAdd;
        public static event Action<ObservedScrollRect> OnRemove;

        protected override void Start()
        {
            base.Start();
            OnAdd?.Invoke(this);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            OnRemove?.Invoke(this);
        }
    }
}