namespace P04_Hospital
{
    using System;
    using System.Linq;

    public class Engine
    {
        private Hospital hospital;

        public Engine(Hospital hospital)
        {
            this.hospital = hospital;
        }

        public void Run()
        {
            var command = Console.ReadLine();

            while (command != "Output")
            {
                var commandParts = command.Split();

                var departament = commandParts[0];
                var firstName = commandParts[1];
                var secondName = commandParts[2];
                var patient = commandParts[3];

                var doctorFullName = firstName + " " + secondName;

                this.hospital.AddDoctor(firstName, secondName);
                this.hospital.AddDepartment(departament);
                this.hospital.AddPatient(doctorFullName, departament, patient);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                var commandParts = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandParts.Length == 1)
                {
                    var departmentName = commandParts[0];
                    var department = this.hospital.Departments.FirstOrDefault(x => x.Name == departmentName);

                    Console.WriteLine(department);
                }
                else if (commandParts.Length == 2)
                {
                    bool isRoom = int.TryParse(commandParts[1], out int targetRoom);

                    if (isRoom)
                    {
                        var departmentName = commandParts[0];
                        var room = this.hospital.Departments.FirstOrDefault(x => x.Name == departmentName).Rooms[targetRoom - 1];

                        Console.WriteLine(room);
                    }
                    else
                    {
                        var doctorName = commandParts[0] + " " + commandParts[1];
                        var doctor = this.hospital.Doctors.FirstOrDefault(x => x.FullName == doctorName);

                        Console.WriteLine(doctor);
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
