using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMvvmToolkit.Common.Interfaces;

public class MeaningItemData : ICollectionItemData
{
    public Guid Id { get; } = Guid.NewGuid();
}
