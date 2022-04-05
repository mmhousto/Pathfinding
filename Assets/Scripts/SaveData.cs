
namespace Com.GCTC.Imprecision
{
    [System.Serializable]
    public class SaveData
    {
        public string playerId;
        public int level;
        public int xpPoints;
        public int coins;
        public float currentPositionX, currentPositionY, currentPositionZ;

        public SaveData(string id)
        {
            playerId = id;
            level = 1;
            xpPoints = 0;
            coins = 0;
            currentPositionX = 0;
            currentPositionY = 1.3f;
            currentPositionZ = 0;
        }

        public SaveData(Player player)
        {
            playerId = player.playerId;
            level = player.level;
            xpPoints = player.xpPoints;
            coins = player.coins;
            currentPositionX = player.currentPosition.x;
            currentPositionY = player.currentPosition.y;
            currentPositionZ = player.currentPosition.z;
        }

    }
}
