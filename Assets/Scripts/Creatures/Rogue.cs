namespace Creatures
{
    public bool HasUncannyDodge;
    
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
        return Dexterity + Dice.dice.Roll(3, 6);
    }

   
    public new void TakeDamage(int damage)
    {
        if(HasUncannyDodge)
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
            return Dexterity + Dice.dice.Roll(3, 6);
        }

   public override void ShortRest()
    {
        base.ShortRest();
        
    }
}
