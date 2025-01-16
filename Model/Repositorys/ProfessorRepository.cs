namespace Model.Repository;

public class ProfessorRepository : IRepository<Professor>{
    List<Professor> professores = [];

    public ProfessorRepository(){
        professores.Add(new(){Nome =  "Marluza", Formacao =  "Letras"});
    }

    public List<Professor> All => professores;

    public void Add(Professor obj) => this.professores.Add(obj);

    public string findByID(int findByID)
    {
        for(int i = 0; i < professores.Count; i++){
            if(findByID == professores[i].Id ){
                return professores[i].Nome;
            }
        }   
        return null;
    }
}