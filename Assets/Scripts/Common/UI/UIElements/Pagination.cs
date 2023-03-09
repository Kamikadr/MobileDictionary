using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIElements
{
    public class Pagination : VisualElement
    {
        private const string PaginationStyleClassName = "pagenation";
        private int _amountOfPoints = 0;
        private List<PaginationPoint> _points;
        private int _currentPointIndex = 0;
        protected int AmountOfPoints 
        {
            get => _amountOfPoints;       
            set  {
                if (value >= 0 & value - _amountOfPoints != 0)
                {
                    RegisterPaginationPoints(value);
                    _amountOfPoints = value;
                }
                else
                {
                    AmountOfPoints = 0;
                }
            }
        }
        public List<PaginationPoint> Points { get => _points; }
        public Pagination()
        {
            _points = new List<PaginationPoint>();
            AddToClassList(PaginationStyleClassName);
        }
        public void ChangeActivePage(int index)
        {
            if(index < 0 || index >= _points.Count)
            {
                return;
            }

            ChangeActivePoint(index);
        }

        private void ChangeActivePoint(int index) 
        {
            _points[_currentPointIndex].Unactivate();
            _points[index].Activate();
            _currentPointIndex = index;
        }
        private void RegisterPaginationPoints(int num)
        {
            contentContainer.Clear();
            _points.Clear();

            for (var i = 0; i < num; i++)
            {
                var point = new PaginationPoint();
                _points.Add(point);
                contentContainer.Add(point);
            }

            if (_points.Count > 0)
                _points[_currentPointIndex].Activate();
        }



        public new class UxmlFactory : UxmlFactory<Pagination, UxmlTraits>
        {
        }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private readonly UxmlIntAttributeDescription _amountOfPointsAttribute = new()
            { name = "amount-of-points", defaultValue = 3 };


            public override void Init(VisualElement visualElement, IUxmlAttributes bag, CreationContext context)
            {
                base.Init(visualElement, bag, context);

                var pagination = (Pagination)visualElement;
                pagination.AmountOfPoints = _amountOfPointsAttribute.GetValueFromBag(bag, context);
            }
        }
    }
}