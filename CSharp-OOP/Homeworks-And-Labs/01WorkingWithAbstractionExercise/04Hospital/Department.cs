namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Department
    {
        public Department(string name)
        {
            this.Name = name;

            this.Rooms = new List<Room>();

            this.CreateRooms();
        }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }

        public void AddPatientInRoom(Patient patient)
        {
            var currentRoom = this.Rooms.Where(x => !x.IsFull).FirstOrDefault();

            if (currentRoom != null)
            {
                currentRoom.AddPatient(patient);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var room in this.Rooms)
            {
                foreach (var patient in room.Patients)
                {
                    result.AppendLine(patient.Name);
                }
            }

            return result.ToString().TrimEnd();
        }

        private void CreateRooms()
        {
            for (int i = 0; i < 20; i++)
            {
                this.Rooms.Add(new Room());
            }
        }
    }
}
