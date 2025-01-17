
using Model.Repository;
using DataBase;
namespace Model;

public class DisciplinaRepository : IRepository<Disciplina>
{
   DB<Disciplina> banco = DB<Disciplina>.App;

    public List<Disciplina> All => banco.All;

    public void Add(Disciplina obj) {
        var disciplina = banco.All;
        disciplina.Add(obj);
        banco.Save(disciplina);
    }

    public string findByID(int findByID)
    {
        var disciplinas = banco.All;
        
        for(int i = 0; i < disciplinas.Count; i++){
            if(findByID == disciplinas[i].Id ){
                return disciplinas[i].Nome;
            }
        }   
        return null;
    }
}