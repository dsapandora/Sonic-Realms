﻿using Hedgehog.Core.Actors;
using UnityEngine;

namespace Hedgehog.Core.Triggers
{
    /// <summary>
    /// Helper class for creating areas that react to player events.
    /// </summary>
    [RequireComponent(typeof(AreaTrigger))]
    public class ReactiveArea : MonoBehaviour
    {
        protected AreaTrigger AreaTrigger;
        protected bool RegisteredEvents;

        public virtual void Awake()
        {
            AreaTrigger = GetComponent<AreaTrigger>();
        }

        public virtual void OnEnable()
        {
            if (AreaTrigger.CollisionRules != null) Start();
        }

        public virtual void Start()
        {
            if (RegisteredEvents) return;

            if (!AreaTrigger.CollisionRules.Contains(IsInsideArea))
                AreaTrigger.CollisionRules.Add(IsInsideArea);
            AreaTrigger.OnAreaEnter.AddListener(OnAreaEnter);
            AreaTrigger.OnAreaStay.AddListener(OnAreaStay);
            AreaTrigger.OnAreaExit.AddListener(OnAreaExit);

            RegisteredEvents = true;
        }

        public virtual void OnDisable()
        {
            if (!RegisteredEvents) return;

            AreaTrigger.CollisionRules.Remove(IsInsideArea);
            AreaTrigger.OnAreaEnter.RemoveListener(OnAreaEnter);
            AreaTrigger.OnAreaStay.RemoveListener(OnAreaStay);
            AreaTrigger.OnAreaExit.RemoveListener(OnAreaExit);

            RegisteredEvents = false;
        }

        public virtual bool IsInsideArea(HedgehogController controller)
        {
            return AreaTrigger.DefaultCollisionRule(controller);
        }

        public virtual void OnAreaEnter(HedgehogController controller)
        {
            
        }

        public virtual void OnAreaStay(HedgehogController controller)
        {
            
        }

        public virtual void OnAreaExit(HedgehogController controller)
        {
            
        }
    }
}