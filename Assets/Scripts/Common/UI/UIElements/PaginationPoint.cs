using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIElements { 
public class PaginationPoint : VisualElement
    {
        private const string PointStyleClassName = "pagenatoin__point";
        private const string ActivePointClassName = "pagenatoin__point--active";
        
        private bool _active = false;
        public bool Active { get => _active;  }
        public PaginationPoint()
        {
            AddToClassList(PointStyleClassName);
        }

        public void Unactivate()
        {
            if (!Active)
            {
                return;
            }
            RemoveFromClassList(ActivePointClassName);
            _active = false;
        }

        public void Activate()
        {
            if (Active)
            {
                return;
            }
            AddToClassList(ActivePointClassName);
            _active = true;
        }
    }
}
