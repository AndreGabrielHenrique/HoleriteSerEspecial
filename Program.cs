int opcao=0;
string separador=new string('-',60);
System.Console.WriteLine(separador);
Console.ForegroundColor=ConsoleColor.Blue;
System.Console.WriteLine("Bem vindo ao sistema de geração de holerites da Ser Especial.");
Console.ResetColor();
while(opcao==0)
{
    System.Console.WriteLine(separador);
    Console.ForegroundColor=ConsoleColor.Yellow;
    System.Console.WriteLine("1) Gerar holerite");
    System.Console.WriteLine("2) Encerrar sistema");    
    opcao=int.Parse(Console.ReadLine());
    Console.ResetColor();
    switch(opcao)
    {
        case 1:
            processaHolerite();
            opcao=0;
            break;
        case 2:
            System.Console.WriteLine(separador);
            Console.ForegroundColor=ConsoleColor.DarkYellow;
            System.Console.WriteLine("Muito obrigado.");
            Console.ResetColor();
            System.Console.WriteLine(separador);
            break;
    }
    Console.ReadKey();
    Console.Clear();
}
static void processaHolerite()
{
    string separador=new string('-',60);
    System.Console.WriteLine(separador);
    Console.ForegroundColor=ConsoleColor.DarkGray;
    System.Console.WriteLine("Informe valor do salário");
    double salario=double.Parse(Console.ReadLine());
    Console.ResetColor();
    System.Console.WriteLine(separador);
    Console.ForegroundColor=ConsoleColor.DarkBlue;
    System.Console.WriteLine("Informe as horas trabalhadas");
    int horas=int.Parse(Console.ReadLine());
    Console.ResetColor();
    System.Console.WriteLine(separador);
    Console.ForegroundColor=ConsoleColor.DarkMagenta;
    System.Console.WriteLine("Informe as horas extras trabalhadas");
    int horasextras=int.Parse(Console.ReadLine());
    Console.ResetColor();
    double valorHora=CalculaValorHora(horas,salario);
    double adiantamento=CalculaAdiantamento(salario);
    double adicionalNoturno=CalculaAdicionalNoturno(valorHora);
    double valeTransporte=CalculaValeTransporte(salario);
    double horaExtra=CalculaHoraExtra(horasextras,adicionalNoturno);
    double INSS=CalculaINSS(salario);
    double IR=CalculaIR(salario);
    double salarioBruto=salario+adicionalNoturno+horaExtra;
    double totalDescontos=IR+INSS+valeTransporte+adiantamento+50;
    double salarioLiquido=salarioBruto-totalDescontos;
    ImprimeHolerite(salarioBruto,IR,INSS,totalDescontos,salarioLiquido,adicionalNoturno,valeTransporte,horaExtra,adiantamento);
}

static void ImprimeHolerite(double salarioBruto,
double IR,
double INSS,
double totalDescontos,
double salarioLiquido,
double adicionalNoturno,
double valeTransporte,
double horaExtra,
double adiantamento)
{
    string separador=new string('-',60);
    System.Console.WriteLine(separador);
    Console.ForegroundColor=ConsoleColor.Cyan;
    System.Console.WriteLine($"Salário Bruto:                   {salarioBruto.ToString("C")}");
    System.Console.WriteLine($"Adicional Noturno:               {adicionalNoturno.ToString("C")}");
    System.Console.WriteLine($"Horas Extraordinárias (50%):     {horaExtra.ToString("C")}");
    System.Console.WriteLine($"Vale Transporte:                 {valeTransporte.ToString("C")}");
    System.Console.WriteLine($"IRRF:                            {IR.ToString("C")}");
    System.Console.WriteLine($"INSS:                            {INSS.ToString("C")}");
    System.Console.WriteLine($"Contribuição Assistencial:       {50.ToString("C")}");
    System.Console.WriteLine($"Adiantamento Quinzenal:          {adiantamento.ToString("C")}");
    Console.ResetColor();
    System.Console.WriteLine(separador);
    Console.ForegroundColor=ConsoleColor.Green;
    System.Console.WriteLine($"Total Descontos:                 {totalDescontos.ToString("C")}");
    System.Console.WriteLine($"Salário Líquido:                 {salarioLiquido.ToString("C")}");
    Console.ResetColor();
    System.Console.WriteLine(separador);
}

static double CalculaValorHora(int horas,double salario)=>salario/horas;
static double CalculaAdicionalNoturno(double valorHora)
{
    return valorHora+0.20;    
}
static double CalculaAdiantamento(double salario)=>salario*0.40;
static double CalculaValeTransporte(double salario)=>salario*0.06;
static double CalculaHoraExtra(int horasextras,double adicionalNoturno)
{
    return (adicionalNoturno+0.50)*horasextras;
}
static double CalculaINSS(double salario)
{
    string separador=new string('-',60);
    if(salario<0)
    {
        System.Console.WriteLine(separador);
        Console.ForegroundColor=ConsoleColor.Red;
        System.Console.WriteLine("Salário não pode ser menor que zero");
        Console.ResetColor();
        return 0;
    }
    if(salario<=1412)
        return salario*0.075;
    else if(salario>1413&&salario<=2666)
        return salario*0.09;
    else if(salario>2667&&salario<=4000)
        return salario*0.12;
    else if(salario>4001&&salario<=7786)
        return salario*0.14;
    return 0;
}
static double CalculaIR(double salario)
{
    string separador=new string('-',60);
    if(salario<0)
    {
        System.Console.WriteLine(separador);
        Console.ForegroundColor=ConsoleColor.Red;
        System.Console.WriteLine("Salário não pode ser menor que zero");
        Console.ResetColor();
        return 0;
    }
    if(salario<=1903)
        return 0;
    else if(salario>1904&&salario<=2866)
        return salario*0.075;
    else if(salario>2867&&salario<=3751)
        return salario*0.15;
    else if(salario>3752&&salario<=4664)
        return salario*0.225;
    else if(salario>4665)
        return salario*0.275;
    return 0;
}