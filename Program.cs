int[][] camera = new int[][] {
    new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
    new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
    new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
     new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
    new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
    new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
};

string[] cores = { "\u001b[40m", "\u001b[44m", "\u001b[41m", "\u001b[47m" };

int[] playerPos = new int[] { 2, 3 };
int[] senhaInputPos = new int[] { 4, 0 };
int[] enigma = new int[] { 0, 0 };

Console.Title = "Jogo";

void mensagem()
{
    Console.Clear();
    Console.Write("TU1NTUNNWFhY\n\nB8^2\n");

    Console.Write("Aperte qualquer coisa para sair");
    string resp = Console.ReadLine();

    if (resp != null)
    {
        Console.Clear();
        Jogo();
    }
}
void pin()
{
    Console.Clear();
    Console.Write("Digite a senha:");
    string resp = Console.ReadLine();
    if (resp == "4930")
    {
        Console.Clear();
        Console.WriteLine("Parabéns, você terminou o Jogo!");
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Senha errada");
        Jogo();
    }
}

void interacoes()
{
    int distanciaEn = playerPos[1] - enigma[1];
    int distanciaPW = playerPos[1] - senhaInputPos[1];
    bool colisionEn = false;
    bool colisionPW = false;

    if (distanciaEn <= 1 && playerPos[0] == enigma[0])
    {
        colisionEn = true;
        mensagem();
    }
    if (distanciaPW <= 1 && playerPos[0] == senhaInputPos[0])
    {
        colisionPW = true;
        pin();
    }
    if (!colisionEn && !colisionPW)
    {
        Console.Clear();
        Jogo();
    }
}

void CondicaoSC(bool condicao, int coluna, int linha = 0)
{
    if (condicao)
    {
        playerPos[1] += coluna;
        playerPos[0] += linha;
        camera[playerPos[0] + -linha][playerPos[1] + -coluna] = 1;
    }
    Console.Clear();
    Jogo();
}

void Jogo()
{
    camera[playerPos[0]][playerPos[1]] = 2;
    camera[senhaInputPos[0]][senhaInputPos[1]] = 3;
    camera[enigma[0]][enigma[1]] = 3;

    foreach (int[] item in camera)
    {
        string str = "";
        foreach (int i in item)
        {
            str += $@"{cores[i]}  " + "\u001b[0m";
        }
        Console.WriteLine(str);
        str = "";
    }
    string resp = Console.ReadLine();
    switch (resp)
    {
        case "a":
            CondicaoSC(playerPos[1] != 0, -1);
            break;
        case "d":
            CondicaoSC(playerPos[1] != 7, 1);
            break;
        case "w":
            CondicaoSC(playerPos[0] != 0, 0, -1);
            break;
        case "s":
            CondicaoSC(playerPos[0] != 5, 0, 1);
            break;
        case "e":
            interacoes();
            break;
        default:
            Console.Clear();
            Jogo();
            break;
    }
}

Jogo();