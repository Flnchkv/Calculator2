using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class Class1
    {
        public double Accum;
        public double Operand;
        public enum State { First, Second };
        public State state = State.First;
        public string NumberText;

        public void Plus()
        {
            if (state == State.First)
            {
                Accum = double.Parse(NumberText);
                NumberText = "";
                state = State.Second;
            }
            else
            {
                Operand = double.Parse(NumberText);
                Accum += Operand;
                NumberText = Accum.ToString();
                state = State.First;
            }
        }

        public void Minus()
        {
            if (state == State.First)
            {
                Accum = double.Parse(NumberText);
                NumberText = "";
                state = State.Second;
            }
            else
            {
                Operand = double.Parse(NumberText);
                Accum -= Operand;
                NumberText = Accum.ToString();
                state = State.First;
            }
        }
    }
}
