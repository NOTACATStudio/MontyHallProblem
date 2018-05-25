namespace Doors
{
    public class Door
    {
        public void PickThisDoor()
        {
            Picked = true;
        }

        public void UnPickThisDoor()
        {
            Picked = false;
        }

        public void SetDoorPrize()
        {
            HasPrize = true;
        }

        public void EliminateThisDoor()
        {
            Eliminated = true;
        }
        
        public bool Picked { get; private set; }
        public bool HasPrize { get; private set; }
        public bool Eliminated { get; private set; }
    }
}