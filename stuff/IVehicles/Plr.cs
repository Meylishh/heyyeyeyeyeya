using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using stuff.IVehicles;



namespace stuff.IVehicles
{
    public class Main
    {
        List<IInput> inputs = new List<IInput>()
        {
            new InputTouch(),
            new InputWebgl()
        };

        private Plr plr = new();
        
        void Update()
        {
            foreach (var input in inputs)
            {
                if (input.isAttackRequested)
                {
                    plr.Attack();
                }
                if (input.isJumpRequested)
                {
                    plr.Jump();
                }
                if (input.isMoveRequested)
                {
                    plr.Move();
                }
            }
        }  
    }
    
    public class Plr
    {
        public void Jump()
        {
            
        }
        public void Move()
        {
            
        }
        public void Attack()
        {
            
        }
    }

    public interface IInput
    {
        bool isJumpRequested { get; }
        bool isAttackRequested { get; }
        bool isMoveRequested { get; }
    }

    public class InputTouch: IInput
    {
        public bool isJumpRequested { get; }
        public bool isAttackRequested { get; }
        public bool isMoveRequested { get; }
    }
    public class InputWebgl: IInput
    {
        public bool isJumpRequested { get; }
        public bool isAttackRequested { get; }
        public bool isMoveRequested { get; }
    }
}