using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PotionCombo",menuName = "DontDrop")]
public class PotionCombo : ScriptableObject
{
    public PotionCombo.Entry[] m_recipes;

    [Serializable]
    public class Entry : IWeight
    {
        public IngredientType[] ingredients;
        
        public int m_basePointsMultiplier = 1;
        public int m_additionalPoints;
        
        public float m_weight;

        public float Weight
        {
            get
            {
                return this.m_weight;
            }
            
        }
    }
}
