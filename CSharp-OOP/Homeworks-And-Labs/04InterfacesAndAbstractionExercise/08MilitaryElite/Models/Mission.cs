namespace MilitaryElite.Models
{
    using System;
    using Contracts;
    using Enumerations;
    using Exceptions;

    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.ParseState(state);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissionException();
            }

            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
        }

        private void ParseState(string stateStr)
        {
            var isParsed = Enum.TryParse(stateStr, out State state);

            if (!isParsed)
            {
                throw new InvalidStateException();
            }

            this.State = state;
        }
    }
}
