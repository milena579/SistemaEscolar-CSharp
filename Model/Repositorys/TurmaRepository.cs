
using Model.Repository;

namespace Model;

public class TurmaRepository : IRepository<Turma>
{
    List<Turma> turmas = [];

    public TurmaRepository(){
        
    }
    public List<Turma> All => turmas;

    public void Add(Turma obj) => this.turmas.Add(obj);

    public string findByID(int findByID)
    {
        for(int i = 0; i < turmas.Count; i++){
            if(findByID == turmas[i].Id){
                return turmas[i].Nome;
            }
        }   
        return null;
    }
}