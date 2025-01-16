
using Model.Repository;

namespace Model;

public class DisciplinaRepository : IRepository<Disciplina>
{
    List<Disciplina> disciplinas = [];

    public DisciplinaRepository(){
        
    }
    public List<Disciplina> All => disciplinas;

    public void Add(Disciplina obj) => this.disciplinas.Add(obj);

    public string findByID(int findByID)
    {
        for(int i = 0; i < disciplinas.Count; i++){
            if(findByID == disciplinas[i].Id ){
                return disciplinas[i].Nome;
            }
        }   
        return null;
    }
}