namespace _02.Blobs.Entities.Attacks
{
    public class PutridFart : Attack
    {
        public override void Execute(Blob attacker, Blob target)
        {
            target.Respond(attacker.Damage);
        }
    }
}