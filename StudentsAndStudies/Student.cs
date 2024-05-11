namespace CW2.StudentsAndStudies;

public class Student
{
    public string _IndexNumber;

    public string IndexNumber
    {
        get { return $"s{_IndexNumber}"; }
        set { this._IndexNumber = value; }
    }
    public string Fname { get; set; }
    public string Lname { get; set; }
    public DateTime Birthdate { get; set; }
    public string Email { get; set; }
    public string MothersName { get; set; }
    public string FathersName { get; set; }
    public IEnumerable<Studies> Studies { get; set; }


    public override bool Equals(object obj)
    {
        var StudentObj = obj as Student;
        if (StudentObj == null) return false;
        return StudentObj._IndexNumber == this._IndexNumber &&
               StudentObj.Fname == this.Fname &&
               StudentObj.Lname == this.Lname;
    }

    public override int GetHashCode()
    {
        return StringComparer
            .CurrentCultureIgnoreCase
            .GetHashCode($"{this._IndexNumber} {this.Lname} {this.Fname}");
    }
}
