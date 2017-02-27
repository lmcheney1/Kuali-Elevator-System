using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    class Program
    {
        static void Main(string[] args) // Main will control the movement of the elevators for now
        {
            int floorNum = 1;
            Elevator elev1 = new Elevator(); // for expansion, we can set up more than one elevator
            Console.WriteLine("This elevator can go to floors 1 through 5. What floor would you like to go to?");
            floorNum = Convert.ToInt16(Console.ReadLine());
            elev1.RequestElevator(floorNum);
        }
    }
    public class Elevator
    {
        bool doorsOpen;
        int currentFloor;
        int maxFloor = 5;
        int minFloor = 1;
        bool moving;
        int tripCount;
        int floorCount;

        public Elevator()
        {
            doorsOpen = false;
            currentFloor = 1;
            moving = false;
            tripCount = 0;
            floorCount = 0;
        }

        public int GoingUp()
        {
            moving = false;
            if (currentFloor >= minFloor && currentFloor < maxFloor)
            {
                ++currentFloor;
                moving = true;
                Console.WriteLine("Going UP to floor {0}", currentFloor);
                ++floorCount;
                ++tripCount;
            }
            else
            {
                Console.WriteLine("Elevator can not go UP; at floor {0}", currentFloor);
            }
            return currentFloor;
        }
        public int GoingDown()
        {
            moving = false;
            if (currentFloor > minFloor && currentFloor <= maxFloor)
            {
                --currentFloor;
                moving = true;
                Console.WriteLine("Going DOWN to floor {0}", currentFloor);
                ++floorCount;
                ++tripCount;
            }
            else
            {
                Console.WriteLine("Elevator can not go DOWN; at floor {0}", currentFloor);
            }
            return currentFloor;
        }
        public void CloseDoors()
        {
            if (!moving)
            {
                doorsOpen = false;
                Console.WriteLine("Closing elevator doors.");
            }
        }
        public void OpenDoors()
        {
            if (!moving)
            {
                doorsOpen = true;
                Console.WriteLine("Opening elevator doors.");
            }
        }
        public void RequestElevator(int n) // n = floor
        {
            int newFloor;
            if (currentFloor > n)
                newFloor = GoingDown();
            else if (currentFloor < n)
                newFloor = GoingUp();
        }
        public void MaintenanceMode()
        {
            moving = false;
        }
    }
}
