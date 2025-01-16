using DataBase;

namespace Model;

public class Turma : DataBaseObject{
    public int Id {get; set;}
    public string Nome { get; set;}
    public List<string> Materias {get; set;} = new List<string>();
    public List<string> Alunos {get; set;} = new List<string>();

    protected override void LoadFrom(string[] data)
    {
        this.Nome = data[0];
        this.Materias = data[1].Split(",").ToList();
        this.Alunos = data[2].Split(",").ToList();
    }

    protected override string[] SaveTo() => new string[]
    {
        this.Nome,
        string.Join(",", Materias),
        string.Join(",", Alunos)
    };
}