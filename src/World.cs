using System.Text;
namespace Collision
{
    public partial class World
    {
        private Random random = new Random();
        private Object[] worldSpace = new Object[30];
        Sprite[] sprites = new Sprite[10];
        private CollisionHandler collisionHandler;
        public World(CollisionHandler collisionHandler)
        {
            this.collisionHandler = collisionHandler;
            InitialSprites();
            SetSpriteAtRandomPosition();
        }

        public void Move(int x1, int x2)
        {
            ValidateMove(x1, x2);
        }

        private void ValidateMove(int x1, int x2)
        {
            if (worldSpace[x1] is null) return;
            if (worldSpace[x2] is null)
            //swap the two objects
            {
                var temp = worldSpace[x1];
                worldSpace[x2] = temp;
                worldSpace[x1] = null;
            }
            if (worldSpace[x1] is Sprite) collisionHandler.HandleResult(ref worldSpace[x1], ref worldSpace[x2]);
        }



        void InitialSprites()
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = GetRandomTypeOfSprite();
            }
        }

        void SetSpriteAtRandomPosition()
        {
            var numbers = Enumerable.Range(0, worldSpace.Length).OrderBy(x => random.Next()).Take(sprites.Length).ToList();
            for (int i = 0; i < sprites.Length; i++)
            {
                worldSpace[numbers[i]] = sprites[i];
            }
        }

        Sprite GetRandomTypeOfSprite()
        {
            int spriteType = random.Next(0, 3);
            Sprite sprite = null;
            switch (spriteType)
            {
                case 0:
                    sprite = new Water();
                    break;
                case 1:
                    sprite = new Fire();
                    break;
                case 2:
                    sprite = new Hero();
                    break;
            }
            return sprite;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < worldSpace.Length; i++)
            {
                stringBuilder.Append(worldSpace[i] is null ? "_" : worldSpace[i].ToString());
            }
            return stringBuilder.ToString();
        }

    }
}