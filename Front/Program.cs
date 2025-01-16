using static System.Console;
using Model;
using Model.Repository;
using System.ComponentModel.Design;

IRepository<Aluno> alunoRepo = null;
IRepository<Professor> profRepo = null;
IRepository<Disciplina> discRepo = null;
IRepository<Turma> turmaRepo = null;

alunoRepo =  new AlunoRepository();
profRepo =  new ProfessorFakeRepository();
discRepo =  new DisciplinaFakeRepository();
turmaRepo =  new TurmaFakeRepository();


List<Turma> turmas = new List<Turma>();

static void verProfs(IRepository<Professor> profRepo)
{
    var profs =  profRepo.All;
    foreach (var prof in profs){
        WriteLine($"""
        ID: {prof.Id} - Nome: {prof.Nome} - Formação: {prof.Formacao} 
        -------------------------------
    """);
    }
}

static void verAlunos(IRepository<Aluno> alunoRepo)
{
    var alunos =  alunoRepo.All;
    foreach (var alu in alunos){
        WriteLine($"""
        ID: {alu.Id} - Nome: {alu.Nome} -  Idade: {alu.Idade}
        -------------------------------
    """);
    }
}

static void verMaterias(IRepository<Disciplina> discRepo)
{
    var materias =  discRepo.All;
    // materias.Count();
    foreach (var materia in materias){
        WriteLine($"""
        ID: {materia.Id} - {materia.Nome}
        -------------------------------
    """);
    }
}

static void verTurmas(List<Turma> turmas, IRepository<Disciplina> discRepo, IRepository<Aluno> alunoRepo ){
    if(turmas.Count == 0){
        Write("Não há nenhuma turma criada ainda!");
    }
    else{
        WriteLine("Turmas Existentes");

        for(int i = 0; i < turmas.Count; i++){
            WriteLine("ID - " + (i+1) + " - " + turmas[i].Nome);
        }

        WriteLine("Digite o ID da turma que deseja acessar, caso queira sair pressione 0: ");

        int tecla = int.Parse(ReadLine()) - 1;

        if(tecla == -1){
            
        }

        if(tecla >= 0 && tecla < turmas.Count){
            verTurma(tecla, turmas, discRepo, alunoRepo);
        } else{
            WriteLine("Opcao inválida!");
            verTurmas(turmas, discRepo, alunoRepo);
        }
    }
}

static void verTurma(int turma, List<Turma> turmas, IRepository<Disciplina> discRepo, IRepository<Aluno> alunoRepo ){

    Turma turmaEscolhida =  turmas[turma];

    WriteLine("Nome da turma: " + turmaEscolhida.Nome);

    WriteLine("Materias:");
    foreach(var materiaa in turmaEscolhida.Materias){
        WriteLine(materiaa);
        string materia =  discRepo.findByID(int.Parse(materiaa));
        WriteLine(materia);
    }

    WriteLine("Alunos:");
    foreach(var alunoo in turmaEscolhida.Alunos){
        WriteLine(alunoo);
        string aluno =  alunoRepo.findByID(int.Parse(alunoo));
        WriteLine(aluno);
    }
}

static int tamMaterias(IRepository<Disciplina> discRepo){
    var materias =  discRepo.All;
    int tamanho = 0;
    foreach (var materia in materias){
       tamanho++;
    }
    return tamanho;
}

static int tamAlunos(IRepository<Aluno> alunoRepo){
    var alunos =  alunoRepo.All;
    int tamanho = 0;
    foreach (var aluno in alunos){
       tamanho++;
    }
    return tamanho;
}

static int tamProf(IRepository<Professor> profRepo){
    var profs =  profRepo.All;
    int tamanho = 0;
    foreach (var prof in profs){
       tamanho++;
    }
    return tamanho;
}
       
while (true){
    try
    {
        Clear();
        
        WriteLine(""" 
        1 - Cadastrar Professor
        2 - Cadastar Aluno
        3 - Cadastrar Materia
        4 - Cadastrar Turma
        5 - Ver Professores
        6 - Ver Alunos
        7 - Ver Materias
        8 - Ver Turmas
        """);

        WriteLine("Escolha uma opção: ");
        int option = int.Parse(ReadLine());

        switch (option){
            case 1:
                Professor professor =  new();

                professor.Id = tamProf(profRepo);

                WriteLine("Insira o nome do professor: ");
                professor.Nome =  ReadLine();

                WriteLine("Insira a formacao do professor: ");
                professor.Formacao =  ReadLine();

                profRepo.Add(professor);

                WriteLine("Professor cadastrado com sucesso!");
                break;
            case 2:
                Aluno aluno =  new();

                aluno.Id = tamAlunos(alunoRepo);

                WriteLine("Insira o nome do aluno: ");
                aluno.Nome =  ReadLine();

                WriteLine("Insira a idade do aluno: ");
                aluno.Idade =  int.Parse(ReadLine());

                alunoRepo.Add(aluno);

                WriteLine("Aluno cadastrado com sucesso!");
                break;

            case 3:
                Disciplina materia =  new();

                materia.Id = tamMaterias(discRepo);

                WriteLine("Insira o nome da materia: ");
                materia.Nome =  ReadLine();

                verProfs(profRepo);
                WriteLine("Insira o id do professor: ");
                materia.IdProfessor =  int.Parse(ReadLine());

                discRepo.Add(materia);

                WriteLine("Materia cadastrada com sucesso!");
                break;
            case 4:
                Turma turma =  new();

                WriteLine("Insira o nome da turma: ");
                turma.Nome =  ReadLine();
                
                verMaterias(discRepo);

                WriteLine("Insira o id da(s) materia(s) separadas por VÍRGULAS: ");
                string entradaMaterias = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entradaMaterias)) {
                    var materias = entradaMaterias.Split(',').Select(m => m.Trim()).ToList();
                    turma.Materias.AddRange(materias);
                } else {
                    WriteLine("Nenhuma matéria inserida.");
                }

                verAlunos(alunoRepo);

                WriteLine("Insira o nome dos alunos separados por VÍRGULAS: ");
                string entradaAlunos = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entradaAlunos)) {
                    var alunos = entradaAlunos.Split(',').Select(m => m.Trim()).ToList();
                    turma.Alunos.AddRange(alunos);
                } else {
                    WriteLine("Nenhum aluno inserido.");
                }

                turmaRepo.Add(turma);
                turmas.Add(turma);

                WriteLine("Truma cadastrada com sucesso!");

                break;

            case 5: 
                WriteLine("-----PROFESSORES-----");
                verProfs(profRepo);
                var profs =  profRepo.All;
                break;
            
            case 6:
               WriteLine("-----ALUNOS-----");
               verAlunos(alunoRepo);
                break;
            case 7:
                WriteLine("-----MATERIAS-----");
                verMaterias(discRepo);
                break;
            case 8:
                WriteLine("-----TURMAS-----");
                verTurmas(turmas, discRepo, alunoRepo);
                break;
            default:
                break;
        }
    }
    catch 
    {
        WriteLine("Algo deu errado, por favor contate a TI");
   
    }

    WriteLine("Pressione qualquer tecla para continuar");
    ReadKey(true);
}

