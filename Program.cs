using CW2.Repositories;
using CW2.StudentsAndStudies;

var students = await FileRepository.GetStudentsAsync(args[0]);
var uniqueStudents = new List<Student>();
using StreamWriter file = new("../../../Data/log.txt", append: true);

foreach (var student in students)
{
    var prevSudent = uniqueStudents.FirstOrDefault(s =>
        s.IndexNumber == student.IndexNumber &&
        s.Fname == student.Fname &&
        s.Lname == student.Lname
    );
    if(prevSudent == null)
        uniqueStudents.Add(student);
    else
    {
        var studiesOfUser = prevSudent.Studies.ToList();
        var currentStudentStudies = student.Studies.ToList()[0];
        var isDuplicate = 
            studiesOfUser.Any(s => s.Mode == currentStudentStudies.Mode && 
                                   s.Name == currentStudentStudies.Name);

        if (isDuplicate)
        {
            
            await file.WriteLineAsync("Linia jest duplikatem");
        }
            
        else
        {
            studiesOfUser.Add(currentStudentStudies);
            prevSudent.Studies = studiesOfUser;
        }
    }
}

await FileRepository.SaveStudentsAsync(students, args[1]);
