using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace Doors
{
    public class DoorSim
    {
        private readonly Choosy _choosy;
        public DoorSim(Choosy choosy)
        {
            _choosy = choosy;
            DoorSet = GetNewDoorSet();
        }

        public List<Door> DoorSet { get; set; }
        
        public bool RunDoorSimulation()
        {
            return ChooseDoor();
        }

        private bool ChooseDoor()
        {
            ContestentPick();
            EliminateUnpickedDoor();
            RepickDoorAfterElimination();
            return DoorSet.Any(x => x.Picked && x.HasPrize);
        }

        private void RepickDoorAfterElimination()
        {
            var door = DoorSet.FirstOrDefault(x => !x.Picked && !x.Eliminated);
            UnpickAllDoors();
            door.PickThisDoor();
        }

        private void EliminateUnpickedDoor()
        {
            var doorsToEliminate = DoorSet.Where(x => !x.HasPrize && !x.Picked).ToList();
            if (doorsToEliminate.Count() > 1)
            {
                doorsToEliminate[_choosy.Choose(2)].EliminateThisDoor();
            }
            else
            {
                doorsToEliminate[0].EliminateThisDoor();
            }
        }

        private void ContestentPick()
        {
            DoorSet[_choosy.Choose()].PickThisDoor();
        }

        private void UnpickAllDoors()
        {
            DoorSet.ForEach(x => x.UnPickThisDoor());
        }

        private List<Door> GetNewDoorSet()
        {
            var doorSet = new List<Door>();
            for (int i = 0; i < 3; i++)
            {
                doorSet.Add(new Door());
            }

            doorSet[_choosy.Choose()].SetDoorPrize();

            return doorSet;
        }
    }
}