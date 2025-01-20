
using System.Data;
using DataBase;

public class Professor : DataBaseObject
{
    public int Id {get; set;}
    public string Nome { get; set;}
    public string Formacao {get; set;}

    protected override void LoadFrom(string[] data)
    {
        this.Id = int.Parse(data[0]);
        this.Nome = data[1];
        this.Formacao = data[2];
    }

    protected override void LoadFromSqlRow(DataRow data)
    {
        throw new NotImplementedException();
    }

    protected override string[] SaveTo() => new string[]
    {
        this.Id.ToString(),
        this.Nome,
        this.Formacao
    };

    protected override string SaveToSql()
    {
        throw new NotImplementedException();
    }
}