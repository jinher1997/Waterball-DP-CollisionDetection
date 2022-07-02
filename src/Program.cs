namespace Collision
{
    class Program
    {
        static void Main(string[] args)
        {
            CollisionHandler collisionHandler = new FireHeroCollisionHandler(null);
            var world = new World(collisionHandler);
            Console.WriteLine(world.ToString());
            world.Move(0, 1);
             Console.WriteLine(world.ToString());
        }
    }
}