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


    public class SameCollisionHandler : CollisionHandler
    {
        public SameCollisionHandler(CollisionHandler next) : base(next)
        {
            this.next = next;
        }
        public override void HandleResult(ref object x1, ref object x2)
        {
            if (x1.GetType() == x2.GetType())
            {
                Console.WriteLine("Move failed");
            }
            else
            {
                next.HandleResult(ref x1, ref x2);
            }
        }
    }


    public class FireHeroCollisionHandler : CollisionHandler
    {
        public FireHeroCollisionHandler(CollisionHandler next) : base(next)
        {
            this.next = next;
        }

        public override void HandleResult(ref object x1, ref object x2)
        {
            
            if(x1 is Fire && x2 is Hero)
            {
                x1 = null;
                x1 = x2;
                // (Hero)x1
            }
            else
            {
                next.HandleResult(ref x1, ref x2);
            }
        }
    }


}