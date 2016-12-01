#include <vector>
#include <string>
#include <algorithm>
#include <iostream>
#include <stdlib.h>
#include <time.h>
#define R 5
#define C 5
#define TRAPS 3
#define TREASURES 1
using namespace std;

void setVector(vector<int> &vect,int number);
vector<int>* generateDungeon(int r,int c,int traps,int treasures);
void printDungeon(const vector<int> &grid);
void pauseAndClear();
void spawnTreasures(vector<int> &grid,int numberOfTreasures);
void spawnTraps(vector<int> &grid,int numberOfTraps);
int spawnPlayer(vector<int> &grid);

enum identifier{EMPTY,TREASURE=1,TRAP=5,HERO=7};
enum direction{UP,DOWN,LEFT,RIGHT};
int playerPosition;

int main()
{

    vector<int> *grid;
    bool isPlaying=true;
    srand(time(NULL));
    grid=generateDungeon(R,C,TRAPS,TREASURES);
    do
    {
        printDungeon(*grid);
        pauseAndClear();

        //chiedi cosa fare

        isPlaying=controllStatus(movePlayer(*grid,UP));
    }while(isPlaying);
    return 0;
}
bool controllStatus(int foundThing)
{
    switch(foundThing)
    {
        case TREASURE:
            break;
        case TRAP:
            break;
        case EMPTY:
            break;
    }
}
int movePlayer(vector<int> &grid,int direction)
{
    switch(direction)
    {
        case UP:

            if(playerPosition-5<0)
            {
                return -1
            }
            else
            {
                grid[playerPosition]=0;
                playerPosition-=C;
                int ret grid[playePosition];
                grid[playerPosition]=HERO;
                return ret;
            }
            break;
        case DOWN:

            break;
        case LEFT:

            break;
        case RIGHT:

            break;
    }
}
void pauseAndClear()
{
    system("pause");
    system("cls");
}
void printDungeon(const vector<int> &grid)
{
    for(int i=0;i<(C+2);i++)
    {
        cout<<"-";
    }
    cout<<endl;
    for(int i=0;i<R;i++)
    {
        cout<<"|";
        for(int j=0;j<C;j++)
        {
            cout<<grid[i*C+j];
        }
        cout<<"|"<<endl;
    }
    for(int i=0;i<(C+2);i++)
    {
        cout<<"-";
    }
    cout<<endl;
}
vector<int>* generateDungeon(int r,int c,int traps,int treasures)
{
    vector<int> *grid;
    grid = new vector<int>(R*C);

    setVector(*grid,0);

    spawnTraps(*grid,traps);

    spawnTreasures(*grid,treasures);

    playerPosition=spawnPlayer(*grid);

    return grid;
}
void spawnTreasures(vector<int> &grid,int numberOfTreasures)
{
    int pos;
    for(int i=0;i<numberOfTreasures;i++)
    {
        do
        {
            pos=rand()%grid.size();
        }while(grid[pos]!=0);
        grid[pos]=TREASURE;
    }
}
void spawnTraps(vector<int> &grid,int numberOfTraps)
{
    int pos;
    for(int i=0;i<numberOfTraps;i++)
    {
        do
        {
            pos=rand()%grid.size();
        }while(grid[pos]!=0);
        grid[pos]=TRAP;
    }
}
int spawnPlayer(vector<int> &grid)
{
    int pos;
    do
    {
        pos=rand()%grid.size();
    }while(grid[pos]!=0);
    grid[pos]=HERO;
    return pos;
}
void setVector(vector<int> &vect,int number)
{
    for(int i=0;i<vect.size();i++)
    {
        vect[i]=number;
    }
}
