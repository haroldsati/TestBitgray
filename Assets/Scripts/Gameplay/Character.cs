using UnityEngine;
using System.Collections;

namespace Gameplay.Detail
{
    public enum Faction
    {
        Ally = 0,
        Enemy = 1
    }

    public abstract class Character : MonoBehaviour
    {
        public virtual void TakeDamage(int damage, Collider hit)
        {
        }
    }
}