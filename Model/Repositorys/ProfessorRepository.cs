namespace Model.Repository;
using DataBase;
public class ProfessorRepository : IRepository<Professor>{

    DB<Professor> banco =  DB<Professor>.App;
   
    public List<Professor> All => banco.All;

    public void Add(Professor obj) {
        var professor = banco.All;
        professor.Add(obj);
        banco.Save(professor);
    }

    public string findByID(int findByID)
    {
        var professores = banco.All;

        for(int i = 0; i < professores.Count; i++){
            if(findByID == professores[i].Id ){
                return professores[i].Nome;
            }
        }   
        return null;
    }
}