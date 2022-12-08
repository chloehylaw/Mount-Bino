namespace Creatures
{
    public bool HasChannelDivinity;
    public int MaxSpellPoints;
    public int CurrentSpellPoints;
   
    public override void Die()
    {
        throw new System.NotImplementedException();
    }


        public override void EnterDying()
        {
            throw new System.NotImplementedException();
        }


        public override int GetDamageBonus()
        {
            return Strength;
        }

        public new int GetSpellSaveDC()
        {
            return 8 + Wisdom + ProficiencyBonus;
        }

        //public override void TakeDamage(int damage)
        //{
        //    CurrentHealth -= damage;
        //}

        internal override int GetSpellAttackBonus()
        {
            return Wisdom + ProficiencyBonus;
        }

        // Start is called before the first frame update
        void Start()
        {
        
    }
    public override void ShortRest()
    {
        base.ShortRest();
        HasChannelDivinity = true;
    }
    
    }
}
