namespace Creatures
{
    public int MaxSpellPoints;
    public int CurrentSpellPoints;
    

    public override void ShortRest()
    {
        base.ShortRest();
        CurrentSpellPoints += 6;
        if (CurrentSpellPoints > MaxSpellPoints)
        {
            this.Actions[0].Use(target);
        }

        public override void BonusAct(string bonusAction, Creature target)
        {

        }
        public override void FreeAct(string freeAction, Creature target)
        {
        }

        public override void ShortRest()
        {
            base.ShortRest();
            CurrentSpellPoints += 6;
            if (CurrentSpellPoints > MaxSpellPoints)
            {
                CurrentSpellPoints = MaxSpellPoints;
            }
        }
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
            return Dexterity;
        }

        internal override int GetSpellAttackBonus()
        {
            return Intelligence + ProficiencyBonus;
        }

    }
}
