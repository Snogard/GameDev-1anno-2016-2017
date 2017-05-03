#include <iostream>
#include <stdlib.h>
#include <stdio.h>
#include <string>
#define PLAYER 3
using namespace std;
struct giocatore
{
    string nome;
    int punteggio;
};
int main()
{
    struct giocatore leaderboard[10];
    char buffer[20];
    int media=0;
    for(int i=0;i<PLAYER;i++)
    {
        system("cls");
        cout<<"Inserisci punteggio Giocatore "<<i+1<<endl;
        sprintf(buffer,"Giocatore %d",i);
        leaderboard[i].nome="";
        leaderboard[i].nome.append(buffer);
        cin>>leaderboard[i].punteggio;
        media+=leaderboard[i].punteggio;
    }
    media/=PLAYER;
    for(int i=PLAYER-1;i>-1;i--)
    {
        cout<<leaderboard[i].nome<<" Punteggio: "<<leaderboard[i].punteggio<<endl;
    }

    cout<<"Media: "<<media;

    return 0;
}

