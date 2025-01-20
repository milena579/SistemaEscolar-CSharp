using System.Data;
using DataBase;

namespace Model;

public class Disciplina : DataBaseObject
{
    public int Id {get; set;}

    public string Nome {get; set;}
    public int IdProfessor {get; set;}
    protected override void LoadFrom(string[] data)
    {
        this.Id = int.Parse(data[0]);
        this.Nome = data[0];
        this.IdProfessor = int.Parse(data[1]);
    }

    protected override void LoadFromSqlRow(DataRow data)
    {
        throw new NotImplementedException();
    }

    protected override string[] SaveTo()  => new string[]
    {
        this.Id.ToString(),
        this.Nome,
        this.IdProfessor.ToString()
    };

    protected override string SaveToSql()
    {
        throw new NotImplementedException();
    }
}