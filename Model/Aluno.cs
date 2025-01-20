using System.Data;
using DataBase;

namespace Model;

public class Aluno : DataBaseObject{
    public int Id {get; set;}

    public string Nome { get; set;}
    public int Idade {get; set;}

    protected override void LoadFrom(string[] data)
    {
        this.Id = int.Parse(data[0]);
        this.Nome = data[0];
        this.Idade = int.Parse(data[1]);
    }

    protected override void LoadFromSqlRow(DataRow data)
    {
        this.Id =  int.Parse(data[0].ToString());
        this.Nome =  (data[1].ToString());
        this.Idade =  int.Parse(data[2].ToString());
    }

    protected override string[] SaveTo() => new string[]
    {
        this.Id.ToString(),
        this.Nome,
        this.Idade.ToString()
    };

    protected override string SaveToSql() => $"INSERT INTO [Aluno] VALUES ('{Id}', {Idade}, {Nome})";
}