#include <iostream>
#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#define R 10
#define C 10

using namespace std;
void resetTable(int[][C],int,int);
void setRandomShipPosition(int[][C],int,int);
int main()
{
    int grid[R][C];
    bool isFinished=false;
    int r,c,shipR,shipC;
    int selection=0;
    srand(time(NULL));
    do{
        resetTable(grid,R,C);
        shipR=rand()%R;
        shipC=rand()%C;
        setShipPosition(grid,shipR,shipC);
        do
        {
            do
            {
                cout<<"Inserisci x: ";
                cin>>r;
            }while(r<1&&r>R)
            do
            {
                cout<<"Inserisci y: ";
                cin>>c;
            }while(c<1&&c>C)
            switch(makeMove(grid,r,c))
            {
                case -1://sbagliato
                    break;
                case 0: //giusto
                    break;
                case 1: //fuoco
                    break;
                case 2: //fuochino
                    break,
            }


        }while(!isFinished);

    }while(selection!=-1);
    return 0;
}
void resetTable(int tab[][C],int r,int c)
{
    for(int i=0;i<r;i++)
    {
        for(int j=0;j<c;j++)
        {
            tab[i][j]=0;
        }
    }

}
void setShipPosition(int tab[][C],int r,int c)
{
    tab[r][c]=1;
}
int makeMove(int tab[][C],r,c)
{
    if(tab[r][c]!=2&&tab[r][c]!=3)
    {
        tab[r][c]+=2;
        if(tab[r][c]==3)
        {
            return 0;
        }
        else
        {
            if(distanceFromShip()<=3)
            {
                return 1;
            }
            else
            {
                if(distanceFromShip()<=5)
                {
                    return 2;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
int distanceFromShip(int r,int c,int shipR,int shipC)
{

    return
}

