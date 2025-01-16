namespace Model.Repository;

public class ProfessorFakeRepository : IRepository<Professor>{
    List<Professor> professores = [];

    public ProfessorFakeRepository(){
        professores.Add(new(){Nome =  "Marluza", Formacao =  "Letras"});
    }

    public List<Professor> All => professores;

    public void Add(Professor obj) => this.professores.Add(obj);
}