using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using CW2.StudentsAndStudies;

namespace CW2.Repositories;

public class FileRepository
{
    public static async Task<IEnumerable<Student>> GetStudentsAsync(string path)
    {
        
        var students = new List<Student>();
        var result = await File.ReadAllLinesAsync(path);


        foreach (var student in result)
        {

            var splitted = student.Split(",");
            if (splitted.Length != 9) {
                using StreamWriter file = new("../../../Data/log.txt", append: true);
                await file.WriteLineAsync("Za mało atrybutów");
                continue;
            }

            try
            {
                var newStudent = new Student()
                {
                    IndexNumber = splitted[4],
                    Fname = splitted[0],
                    Lname = splitted[1],
                    Birthdate = DateTime.Parse(splitted[5]),
                    Email = splitted[6],
                    MothersName = splitted[7],
                    FathersName = splitted[8]
                };

                var studies = new List<Studies>();

                studies.Add(new Studies()
                {
                    Name = splitted[2],
                    Mode = splitted[3]
                });
                newStudent.Studies = studies;
                students.Add(newStudent);
            }catch(Exception e){}
        } 
        

        return students;
    }

    public static async Task<bool> SaveStudentsAsync(IEnumerable<Student> students, string path)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };
        var jsonString = JsonSerializer.Serialize(new
        {
            CreatedTime = DateTime.Now,
            Author = "Mikołaj Sadownik",
            Students = students
        }, options);
        try
        {
            using var sw = new StreamWriter(path);
            await sw.WriteAsync(jsonString);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        
        return true;
    }
}