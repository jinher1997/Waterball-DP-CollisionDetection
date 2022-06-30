namespace Collision
{
    public abstract class CollisionHandler
    {
        protected CollisionHandler next;
        public CollisionHandler(CollisionHandler next)
        {
            this.next = next;
        }
        public abstract void HandleResult(ref object x1, ref object x2);
    }




    public class FireCollisionHandler : CollisionHandler
    {
        public FireCollisionHandler(CollisionHandler next) : base(next)
        {
            this.next = next;
        }

        public override void HandleResult(ref object x1, ref object x2)
        {
            throw new NotImplementedException();
        }
    }


}