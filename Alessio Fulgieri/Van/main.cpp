#include <iostream>
#include <stdlib.h>
#include "Entity.h"
#include <time.h>
#include <vector>
using namespace std;

const Entity baseVanHelsing("Van Helsing",100,100,10,10);
const Entity baseDracula("Dracula",50,50,20,20);
const Entity baseServant("Servant",12,30,12,10);
const Entity baseGhost("Ghost",100,12,2,20);

int main()
{
    bool isGameEnd = false;
    bool isFighting = false;

    short probDracula = 0;
    short mainState;
    short playerChoice = 0;
    short action = 0;

    Entity vanHelsing=baseVanHelsing;
    Entity dracula=baseDracula;

    Vector<Enemy> enemies;

    srand(time(NULL));

    do{
        if(vanHelsing.isAlive()&&!dracula.isAlive())
        {
            mainState=0;
        }
        else
        {
            if(!vanHelsing.isAlive())
            {
                mainState=1;
            }
            else
            {
                mainState = 2;
            }
        }
        switch(mainState)
        {
            //vittoria
            case 0:
                system("cls");
                cout<<"Complimenti hai sconfitto dracula!"<<endl;
                system("pause");
                isGameEnd=true;
                break;
            //sconfitta
            case 1:
                system("cls");
                cout<<"Che peccato, sei stato ucciso!"<<endl;
                system("pause");
                isGameEnd=true;
                break;
            //scegli un azione
            case 2:

                do
                {
                    system("cls");
                    cout<<"Cosa vuoi fare?"<<endl<<"1. Vai a caccia"<<endl<<"2. Riposati"<<endl;
                    cin>>playerChoice;
                }while(playerChoice!=1||playerChoice!=2);

                do{
                    switch(playerChoice)
                    {
                        //caccia
                        case 1:
                            playerChoice=3;
                            isFighting=true;
                            if(rand()%100+1<=probDracula)
                            {
                                playerChoice++;
                            }
                            break;
                        //riposo
                        case 2:
                            if(rand()%100+1<=70)
                        \   {
                                vanHelsing.heal(rand()%5+6);
                            }
                            else
                            {
                                playerChoice=3;
                                isFighting=true;
                            }
                            break;
                        //normal encounter
                        case 3:
                            if(enemies.isEmpty())
                            {
                                enemies=generateEncounter();
                            }
                            else
                            {
                                do
                                {
                                    system("cls");
                                    vanHelsing.printStatus();
                                    cout<<endl;

                                    for(int i=0;i<enemies.size();i++)
                                    {
                                        enemies[i].printStatus();
                                        cout<<endl;
                                    }

                                    cout<<"Cosa vuoi fare?"<<endl<<"1. Attacca"<<endl"2: Intimidisci"<<endl;
                                    cin>>action;

                                }while(action!=1||action!=2);
                                //attacco
                                if(action==1)
                                {
                                    for(int i=0;i<enemies.size();i++)
                                    {
                                        entities[i].damage(vanHelsing.getAttack());
                                    }

                                    for(int i=0,int alive=0;alive!=entities.size()&&i<entities.size();i++)
                                    {
                                        if(!entities[i].isAlive())
                                        {
                                            entities.erase(enemies.begin()+i);
                                        }
                                        else
                                        {
                                            alive++;
                                        }
                                    }
                                }
                                //intimidisco
                                if(action==2)
                                {
                                    for(int i=0;i<enemies.size();i++)
                                    {
                                        entities[i].scare(vanHelsing.getIntimidation());
                                    }

                                    for(int i=0,int alive=0;alive!=entities.size()&&i<entities.size();i++)
                                    {
                                        if(!entities[i].isAlive())
                                        {
                                            entities.erase(enemies.begin()+i);
                                        }
                                        else
                                        {
                                            alive++;
                                        }
                                    }
                                }
                                //van viene attaccato!!!
                                if(rand()%1)
                                {
                                    for(int i=0;i<enemies.size();i++)
                                    {
                                        vanHelsing.damage(enemies[i].getAttack());
                                    }
                                }
                                else
                                {
                                    for(int i=0;i<enemies.size();i++)
                                    {
                                        vanHelsing.scare(enemies[i].getIntimidation());
                                    }
                                }
                                cout<<endl;
                                system("pause");
                                system("cls");

                                if(!vanHelsing.isAlive()||enemies.size()==0)
                                {
                                    cout<<"Il Combattimento è terminato"<<endl;
                                    system("pause");
                                    isFighting=false;
                                    playerChoice=0;
                                    probdDracula+=10;
                                    delete enemies;
                                }
                            }
                            break;
                        //dracula
                        case 4:
                            do{
                                system("cls");
                                vanHelsing.printStatus();
                                cout<<endl;

                                dracula.printStatus();
                                cout<<endl;

                                cout<<"Cosa vuoi fare?"<<endl<<"1. Attacca"<<endl"2: Intimidisci"<<endl;
                                cin>>action;

                            }while(action!=1||action!=2);

                            if(action==1)
                            {
                                dracula.damage(vanHelsing.getAttack());
                            }
                            if(action=2)
                            {
                                dracula.scare(vanHelsing.getIntimidation());
                            }
                            if(dracula.isAlive())
                            {
                                if(rand()%1)
                                {
                                    vanHelsing.damage(dracula.getAttack());
                                }
                                else
                                {
                                    vanHelsing.scare(dracula.getIntimidation());
                                }
                            }
                            else
                            {
                                isFighting=false;
                            }
                            if(!vanHelsing.isAlive())
                            {
                                isFighting=false;
                            }
                    }
                }while(isFighting);
                break;

        }

    }while(!isGameEnd);


    return 0;
}

Vector<Enemy>& generateEncounter()
{
    Vector<Enemy> enemies();
    if(rand()%1)
    {
        enemies.push_back(baseGhost);
        enemies.push_back(baseGhost);
        enemies.push_back(baseGhost);
        return enemies;
    }
    else
    {
        enemies.push_back(baseServant);
        enemies.push_back(baseServant);
        enemies.push_back(baseServant);
        return enemies;
    }
}
