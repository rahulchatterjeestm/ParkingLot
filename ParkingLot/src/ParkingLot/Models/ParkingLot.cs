﻿using System;
using System.Collections.Generic;

namespace ParkingLot.Models
{
    public class ParkingLot
    {
        private const int maxCapacity = 10000;
        public int Capacity { get; private set; }
        public Dictionary<int, Slot> Slots { get; private set; }

        public ParkingLot(int capacity)
        {
            if(capacity>maxCapacity || capacity<0)
            {
                throw new System.Exception("Invalid capacity given for paring lot"); //Todo def excpetion
            }

            this.Capacity = capacity;
            this.Slots = new Dictionary<int, Slot>();
        }

        private Slot GetSlot(int slotNum)
        {
            if(slotNum > this.Capacity || slotNum < 0)
            {
                throw new Exception();//Todo make eception class
            }

            if(!this.Slots.ContainsKey(slotNum))
            {
                this.Slots[slotNum] = new Slot(slotNum);
            }

            return this.Slots[slotNum];
        }

        public Slot Park(Car car, int slotNum)
        {
            Slot slot = GetSlot(slotNum);
            if(!slot.IsSlotFree)
            {
                throw new Exception(); //todo
            }

            slot.AssingCar(car);
            return slot;
        }

        public Slot MakeSlotFree(int slotNum)
        {
            var slot = GetSlot(slotNum);
            slot.UnassignCar();
            return slot;
        }

    }
}
